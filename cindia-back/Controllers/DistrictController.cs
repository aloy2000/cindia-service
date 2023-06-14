using cindia_back.Models.Dto;
using cindia_back.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cindia_back.Controllers;
[Route("api/[controller]")]


public class DistrictController : Controller
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
         IEnumerable<DistrictDto> allDistricts = await  _districtRepository.GetDistrict();
         _responseDto.Result = allDistricts;
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
         var districtDto = await _districtRepository.GetDistrictById(id);
         _responseDto.Result = districtDto;
      }
      catch (Exception e)
      {
         _responseDto.IsSuccess = false;
         _responseDto.ErrorMessage = new List<string>() { e.ToString() };
      }

      return _responseDto;
   }
   
   [HttpPost]
   public async Task<object> Post([FromBody] DistrictDto districtDto)
   {
      try
      {
         var districtCreated = await _districtRepository.CreateUpdateDistrict(districtDto);
         _responseDto.Result = districtCreated;
      }
      catch (Exception e)
      {
         _responseDto.IsSuccess = false;
         _responseDto.ErrorMessage = new List<string>() { e.ToString() };
      }

      return _responseDto;
   }
   
   [HttpDelete]
   public async Task<object> Delete(int districtId)
   {
      try
      {
         var result = await _districtRepository.DeleteDistrict(districtId);
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