using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace SlimEndpoints;

public interface IEndpoint
{
    public static abstract string EndpointName { get; }
    public static abstract RouteHandlerBuilder ConfigureEndpoint(IEndpointRouteBuilder builder, [RouteTemplate] string route);
}
