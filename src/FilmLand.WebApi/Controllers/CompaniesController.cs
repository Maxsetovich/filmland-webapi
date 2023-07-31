using FilmLand.DataAccess.Utilities;
using FilmLand.Service.Dtos.Companies;
using FilmLand.Service.Interfaces.Companies;
using FilmLand.Service.Validators.Dtos.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmLand.WebApi.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _service;
    private readonly int maxPageSize = 30;
    public CompaniesController(ICompanyService service)
    {
        this._service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{companyId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long companyId)
        => Ok(await _service.GetByIdAsync(companyId));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] CompanyCreateDto dto)
    {
        var createValidator = new CompanyCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{companyId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long companyId, [FromForm] CompanyUpdateDto dto)
    {
        var updateValidator = new CompanyUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(companyId, dto));
        else return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{companyId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long companyId)
        => Ok(await _service.DeleteAsync(companyId));
}
