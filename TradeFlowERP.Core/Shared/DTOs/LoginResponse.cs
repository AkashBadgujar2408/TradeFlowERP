using System;
using System.Collections.Generic;
using System.Text;

namespace TradeFlowERP.Core.Shared.DTOs;

public class LoginResponse
{
    public string? Token { get; init; }
    public LoggedInUserDTO? User { get; init; }
}