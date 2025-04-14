using AutoMapper;
using BuyFastApi.Abstracts;
using BuyFastApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyFastApi.Controllers;

[ApiController]
public abstract class BaseController<TEntityDto,TEntity> : ControllerBase where TEntity :class
{
    protected readonly ILogger<ControllerBase> _logger;
    protected readonly IEntityRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

    public BaseController(ILogger<ControllerBase> logger, IEntityRepository<TEntity> repository,IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public virtual async Task<IEnumerable<TEntity>> Get(int? from = null, int? size = null)
    {
        return await _repository.GetAllAsync(from, size);
    }

    [HttpGet("GetById")]
    [AllowAnonymous]
    public async Task<ActionResult> GetById(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return NotFound();

        return Ok(entity);
    }

    [HttpPost]
    public async Task<ActionResult> Create(TEntityDto user)
    {
        var mappedUser = _mapper.Map<TEntity>(user);
        var entity = await _repository.CreateAsync(mappedUser);
        if (entity == null)
            return BadRequest();

        return Ok(entity);
    }

    [HttpPut]
    public async Task<ActionResult> Update(Guid userId, TEntity user)
    {
        var _user = await _repository.UpdateAsync(userId, user);
        if (_user == null)
            return BadRequest();

        return Ok(_user);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(Guid userId)
    {
        var response = await _repository.DeleteAsync(userId);
        if (response)
            BadRequest();

        return Ok();
    }
}