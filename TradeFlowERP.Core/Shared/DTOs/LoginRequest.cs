using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TradeFlowERP.Core.Shared.DTOs;

public class LoginRequest
{
    [Required]
    public string? Username { get; init; }

    [Required]
    public string? Password { get; init; }
}