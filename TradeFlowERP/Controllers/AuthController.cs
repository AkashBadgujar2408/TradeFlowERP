using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradeFlowERP.Core.Shared.DTOs;
using TradeFlowERP.Core.Shared.ServiceContracts;

namespace TradeFlowERP.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await authService.LoginAsync(request);
        if (!result.Success)
        {
            return Unauthorized(ApiResponse.Fail(result.Error!));
        }

        return Ok(result.Data);
    }
}
