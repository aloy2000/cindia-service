using Microsoft.AspNetCore.Mvc;
using Amazon.Textract;
using Amazon.Textract.Model;
using cindia_back.Models;
using Amazon.Runtime;


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
    public async Task<IActionResult> ProcessDocument([FromForm] FileUpload fileUpload)
    {
        try
        {
            if (fileUpload?.File is null || fileUpload.File.Length <= 0)
            {
                return BadRequest("No cin uploaded");
            }

            using var stream = fileUpload.File.OpenReadStream();
            var request = new StartDocumentTextDetectionRequest()
            {
                DocumentLocation = new DocumentLocation()
                {
                    S3Object = new S3Object
                    {
                        Bucket = "my-example-bucket",
                        Name = "cin"
                    }
                }
            };
            var response = await _textract.StartDocumentTextDetectionAsync(request);
            var jobId = response.JobId;
            return Ok(jobId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}