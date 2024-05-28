using Auth0.ManagementApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace userservice.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganisationController : ControllerBase
{
    private readonly Auth0Service _auth0Service;

    public OrganisationController(Auth0Service auth0Service)
    {
        _auth0Service = auth0Service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrganization([FromBody] OrganizationCreateRequest createRequest)
    {
        var managementApiClient = await _auth0Service.GetManagementApiClientAsync();
        var organization = await managementApiClient.Organizations.CreateAsync(createRequest);
        return Ok(organization);
    }

    [HttpGet("{organizationId}")]
    public async Task<IActionResult> GetOrganization(string organizationId)
    {
        var managementApiClient = await _auth0Service.GetManagementApiClientAsync();
        var organization = await managementApiClient.Organizations.GetAsync(organizationId);
        return Ok(organization);
    }

    // [HttpGet]
    // public async Task<IActionResult> GetOrganizations()
    // {
    //     var managementApiClient = await _auth0Service.GetManagementApiClientAsync();
    //     var organizations = await managementApiClient.Organizations.GetAllAsync();
    //     return Ok(organizations);
    // }

    [HttpPut("{organizationId}")]
    public async Task<IActionResult> UpdateOrganization(string organizationId, [FromBody] OrganizationUpdateRequest updateRequest)
    {
        var managementApiClient = await _auth0Service.GetManagementApiClientAsync();
        var organization = await managementApiClient.Organizations.UpdateAsync(organizationId, updateRequest);
        return Ok(organization);
    }
}
