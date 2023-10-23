using cindia_back.Models.Dto;
using cindia_back.Repository;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class DemandeController : Controller
{
    private readonly IDemandeRepository _demandeRepository;
    private readonly ResponseDto _responseDto;

    public DemandeController(IDemandeRepository demandeRepository)
    {
        _demandeRepository = demandeRepository;
        _responseDto = new ResponseDto();
    }

    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            var demandes = await _demandeRepository.GetDemandes();
            _responseDto.Result = demandes;
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
            var demande = await _demandeRepository.GetDemandeById(id);
            _responseDto.Result = demande;
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
            var result = await _demandeRepository.DeleteDemande(id);
            _responseDto.Result = result;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }
        return _responseDto;
    }

    [HttpPost]
    public async Task<object> Post([FromBody] DemandeDto demandeDto)
    {
        try
        {
            var demandeCreated = await _demandeRepository.CreateUpdateDemande(demandeDto);
            _responseDto.Result = demandeCreated;
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.ErrorMessage = new List<string>() { e.ToString() };
        }

        return _responseDto;
    }
}