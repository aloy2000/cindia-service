using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Amazon.Textract;
using Amazon.Textract.Model;
using Amazon.Runtime;
using cindia_back.utils;
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
            CultureInfo frenchCulture = new CultureInfo("fr-FR");
            
            foreach (var block in responseBlockText)
            {
                textListFromBlock.Add(block.Text);
            }

            foreach (var text in textListFromBlock)
            {
                if (text.Contains("Nom"))
                {
                    responseKeyValue["Name"] = ExtractAllCharacterAfterOccurence(text, "Nom");
                }

                if (text.Contains("Prenoms"))
                {
                    responseKeyValue["LastName"] = ExtractAllCharacterAfterOccurence(text, "Prenoms");
                }

                if (!Equals(StringToDateTest(text, dateFormat), false))
                {
                    responseKeyValue["birth"] = StringToDateTest(text, dateFormat);
                }

            }

            return Ok(responseKeyValue);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"An error occured: {e.Message}");
        }
    }
}