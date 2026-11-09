using System;
using System.Collections.Generic;
using System.Text;

namespace TradeFlowERP.Core.Shared.ServiceContracts;

public interface IAuthService
{
    Task<OperationResult<LoginResponse>> LoginAsync(LoginRequest request);
}