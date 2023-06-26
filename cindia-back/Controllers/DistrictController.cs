using cindia_back.Models.Dto;
using cindia_back.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cindia_back.Controllers;

[Route("api/[controller]")]
public class DistrictController: Controller
{
    private readonly IDistrictRepository _districtRepository;
    private ResponseDto _responseDto;

    public DistrictController(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
        _responseDto = new ResponseDto();
    }

    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            var districts = await _districtRepository.GetDistrict();
            _responseDto.Result = districts;
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
            var district = await _districtRepository.GetDistrictById(id);
            _responseDto.Result = district;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }
        return _responseDto;
    }
    
    [HttpDelete]
    public async Task<object> Delete(int id)
    {
        try
        {
            var result = await _districtRepository.DeleteDistrict(id);
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