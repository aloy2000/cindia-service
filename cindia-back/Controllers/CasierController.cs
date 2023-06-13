using cindia_back.Models;
using cindia_back.Models.Dto;
using cindia_back.Repository;
using Microsoft.AspNetCore.Mvc;


namespace cindia_back.Controllers;

[Route("api/[controller]")]
public class CasierController : Controller
{
    private readonly ICasierRepository _casierRepository;
    private ResponseDto _responseDto;

    public CasierController(ICasierRepository casierRepository)
    {
         _casierRepository = casierRepository;
         _responseDto = new ResponseDto();
    }

    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            IEnumerable<CasierDto> allCasiers = await  _casierRepository.GetCasiers();
            _responseDto.Result = allCasiers;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try
        {
            var casierDto = await _casierRepository.GetCasiersById(id);
            _responseDto.Result = casierDto;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }

    [HttpPost]
    public async Task<object> Post([FromBody] CasierDto casierDto)
    {
        try
        {
            var casierCreated = await _casierRepository.CreateUpdateCasier(casierDto);
            _responseDto.Result = casierCreated;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }

    [HttpDelete]
    public async Task<object> Delete(int casierId)
    {
        try
        {
            var result = await _casierRepository.DeleteCasier(casierId);
            _responseDto.Result = result;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }

}
