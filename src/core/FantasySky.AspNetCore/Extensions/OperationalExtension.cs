using FantasySky.Core.Operation;

using Microsoft.AspNetCore.Http;

namespace FantasySky.AspNetCore.Extensions;

public static class OperationalExtension
{
    public static Operational<TParameter> CreateOperational<TParameter>(this HttpContext httpContext, TParameter parameter)
        => new(parameter);
}
