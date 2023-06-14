using cindia_back.Models.Dto;
using cindia_back.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cindia_back.Controllers;
[Route("api/[controller]")]


public class SectionController : Controller
{
    private readonly ISectionRepository _sectionRepository;
    private readonly ResponseDto _responseDto;

    public SectionController(ISectionRepository sectionRepository)
    {
        _sectionRepository = sectionRepository;
        _responseDto = new ResponseDto();
    }
    // GET
    [HttpGet]
    public async Task<object> GetSections()
    {
        try
        {
            IEnumerable<SectionDto> allSections = await  _sectionRepository.GetSection();
            _responseDto.Result = allSections;
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
    public async Task<object> GetSectionById(int id)
    {
        try
        {
            var setiontDto = await _sectionRepository.GetSectionById(id);
            _responseDto.Result = setiontDto;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }
    [HttpPost]
    public async Task<object> Post([FromBody] SectionDto sectionDto)
    {
        try
        {
            var sectionCreated = await _sectionRepository.CreateUpdateSection(sectionDto);
            _responseDto.Result = sectionCreated;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }

    [HttpDelete]
    public async Task<object> Delete(int sectionId)
    {
        try
        {
            var result = await _sectionRepository.DeleteSection(sectionId);
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