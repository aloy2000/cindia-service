using cindia_back.Models.Dto;
using cindia_back.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cindia_back.Controllers;

[Route("api/[controller]")]
public class SectionController: Controller
{
    private readonly ISectionRepository _sectionRepository;
    private readonly ResponseDto _responseDto;
    
    public SectionController(ISectionRepository sectionRepository)
    {
        _sectionRepository = sectionRepository;
        _responseDto = new ResponseDto();
    }
    
    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            var sections = await _sectionRepository.GetSection();
            _responseDto.Result = sections;
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
            var section = await _sectionRepository.GetSectionById(id);
            _responseDto.Result = section;
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
            var result = await _sectionRepository.DeleteSection(id);
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