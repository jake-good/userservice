using Auth0.ManagementApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace userservice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly Auth0Service _auth0Service;

    public UsersController(Auth0Service auth0Service)
    {
        _auth0Service = auth0Service;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var managementApiClient = await _auth0Service.GetManagementApiClientAsync();
        var users = await managementApiClient.Users.GetAllAsync(new GetUsersRequest());
        return Ok(users);
    }
}