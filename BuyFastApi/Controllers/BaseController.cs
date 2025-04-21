using BuyFastApi.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace BuyFastApi.Controllers;
[Authorize]
[ApiController]
public abstract class BaseController<TRequest,TUpdate,TResponse> : ControllerBase where TRequest :class where TResponse : class where TUpdate : class
{
    protected readonly ILogger<ControllerBase> _logger;
    protected readonly IGenericService<TRequest, TUpdate, TResponse> _services;
    public BaseController(ILogger<ControllerBase> logger,IGenericService<TRequest, TUpdate, TResponse> services)
    {
        _logger = logger;
        _services = services;
    }

    [HttpGet]
    public virtual ActionResult<IEnumerable<TResponse>> GetAll()
    {
        try
        {
            var getAll = _services.GetAll();
            if (getAll is not null)
                return Ok(getAll);
            return Ok("You have not data");
        }
        catch (Exception ex)
        {
            throw new Exception($"You have exception:{ex.Message} in the Controller Method GetAll");
        }
    }

    [HttpGet("Id")]
    public virtual ActionResult<TResponse> GetById(Guid id)
    {
        try
        {
            var getById = _services.GetById(id);
            if (getById is null)
                return Ok("You have not data");
            return Ok(getById);
        }
        catch (Exception ex)
        {
            throw new Exception($"You have exception:{ex.Message} in the Method GetById");
        }
    }

    [HttpPost]
    public virtual ActionResult<string> Create([FromBody] TRequest request)
    {
        try
        {
            return _services.Create(request);
        }
        catch (MySqlException)
        {
            return $"Didn't save data {request}";
        }
        catch (Exception ex)
        {
            throw new Exception($"You have exception:{ex.Message} in the Method Create");
        }
    }

    [HttpPut]
    public virtual ActionResult<string> Update(TUpdate updateRequest)
    {
        try
        {
            return _services.Update(updateRequest);
        }
        catch (Exception ex)
        {
            throw new Exception($"You have exception:{ex.Message} in the  Method Update");
        }
    }

    [HttpDelete]
    public ActionResult<string> Delete(Guid id)
    {
        try
        {
            return _services.Delete(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"You have exception:{ex.Message} in the Method Delete");
        }
    }
}