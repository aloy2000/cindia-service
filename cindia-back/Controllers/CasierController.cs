using cindia_back.Models;
using cindia_back.Models.Dto;
using cindia_back.Repository;
using Microsoft.AspNetCore.Mvc;


namespace cindia_back.Controllers;

[Route("api/[controller]")]
public class CasierController : Controller
{
    private readonly ICasierRepository _casierRepository;

    public CasierController(ICasierRepository casierRepository)
    {
         _casierRepository = casierRepository;
    }

    [HttpGet]
    public async Task<object> GetCasiers()
    {
        try
        {
            var allCasiers = await  _casierRepository.GetCasiers();
            return allCasiers;
        }
        catch (Exception e)
        {
            return NotFound();
        }
       
    }


}

public interface IHttpActionResult
{
}