using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using Amazon.Textract;
using Amazon.Textract.Model;
using Amazon.Runtime;
using static cindia_back.utils.Utils;


namespace cindia_back.Controllers;

[Route("api/[controller]")]
public class CinAnalysController:Controller
{
    private readonly IAmazonTextract _textract;
    private readonly AWSCredentials _credentials;

    public CinAnalysController(IAmazonTextract textract, AWSCredentials credentials)
    {
        _textract = textract;
        _credentials = credentials;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessDocument(IFormFile? fileUpload)
    {
        try
        {
            Console.WriteLine("File uploaded" + fileUpload);
            if (fileUpload == null || fileUpload.Length <= 0)
            {
                return BadRequest("No cin uploaded");
            }

            var tempFilePath = Path.GetTempFileName();
            await using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await fileUpload.CopyToAsync(stream);
            }
            var imageBytes = await System.IO.File.ReadAllBytesAsync(tempFilePath);

            var request = new DetectDocumentTextRequest()
            {
                Document = new Document()
                {
                    Bytes = new MemoryStream(imageBytes)
                }
            };

            var response = await _textract.DetectDocumentTextAsync(request);
            var responseBlockText = response.Blocks.FindAll(block => block.BlockType.Value == "LINE");
            var textListFromBlock = new List<string>();
            var responseKeyValue = new Dictionary<string, object>();
            var dateFormat = "dd MMMM yyyy";
            
            foreach (var block in responseBlockText)
            {
                textListFromBlock.Add(block.Text);
            }

            var i = 0;
            foreach (var text in textListFromBlock)
            {
                if (text.Contains("Nom"))
                {
                    responseKeyValue["name"] = ExtractAllCharacterAfterOccurence(text, "Nom");
                }

                if (text.Contains("Prenoms"))
                {
                    responseKeyValue["lastName"] = ExtractAllCharacterAfterOccurence(text, "Prenoms");
                }

                if (!Equals(StringToDateTest(text, dateFormat), false))
                {
                    responseKeyValue["birth"] = StringToDateTest(text, dateFormat);
                }

                if (text.Contains("Tao/") || text.Contains("TAO/"))
                {
                    var textSplitArray = text.Split(" ");
                    responseKeyValue["birthplace"] = textSplitArray.Last() + " " + textListFromBlock[i + 1] ;
                }

                if (!Equals(ParseStringToNumber(text), false))
                {
                    if (responseKeyValue.ContainsKey("numCIN"))
                    {
                        responseKeyValue["numCIN"] = responseKeyValue["numCIN"] + ParseStringToNumber(text).ToString();
                    }
                    else
                    {
                        responseKeyValue["numCIN"] = ParseStringToNumber(text).ToString();
                    }
                }

                if (text.Contains("FONENANA"))
                {
                    if (text.Contains("Domicile"))
                    {
                        responseKeyValue["address"] = ExtractAllCharacterAfterOccurence(text, "Domicile") + " " +
                                                      textListFromBlock[i + 1];
                    }
                    else
                    {
                        responseKeyValue["address"] = ExtractAllCharacterAfterOccurence(text, "FONENANA") + " " +
                                                      textListFromBlock[i + 1];
                    }
                }

                if (text.Contains("Profession"))
                {
                    responseKeyValue["job"] = ExtractAllCharacterAfterOccurence(text, "Profession");
                }

                if (text.Contains("Arrondissement"))
                {
                    responseKeyValue["district"] = ExtractAllCharacterAfterOccurence(text, "Arrondissement");
                }

                if (text.Contains("RAY NITERAKA"))
                {
                    if (text.Contains("Père"))
                    {
                        responseKeyValue["fatherName"] = ExtractAllCharacterAfterOccurence(text, "Père");
                    }
                    else
                    {
                        responseKeyValue["fatherName"] = ExtractAllCharacterAfterOccurence(text, "/");
                    }
                } 
                if (text.Contains("RENY NITERAKA"))
                {
                    if (text.Contains("Mère"))
                    {
                        responseKeyValue["motherName"] = ExtractAllCharacterAfterOccurence(text, "Mère");
                    }
                    else
                    {
                        responseKeyValue["motherName"] = ExtractAllCharacterAfterOccurence(text, "/");
                    }
                }

                if (text.Contains("NATAO TAO"))
                {
                    if (text.Contains("Fait à"))
                    {
                        responseKeyValue["doneAt"] = ExtractAllCharacterAfterOccurence(text, "Fait à");
                    }
                    else
                    {
                        responseKeyValue["doneAt"] = ExtractAllCharacterAfterOccurence(text, "TAO");
                    }
                }
                if (text.Contains("TAMIN'NY"))
                {
                    if (text.Contains("Le"))
                    {
                        Console.WriteLine("tafiditra ato ve io");
                        responseKeyValue["on"] = ExtractAllCharacterAfterOccurence(text, "TAMIN'NY/Le");
                    }
                    else
                    {
                        responseKeyValue["on"] = ExtractAllCharacterAfterOccurence(text, "/");
                    }
                }
                i++;
            }

            /*var finalResponse = new ArrayList();
            finalResponse.Add(textListFromBlock);
            finalResponse.Add(responseKeyValue);*/
            
            return Ok(responseKeyValue);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"An error occured: {e.Message}");
        }
    }
}