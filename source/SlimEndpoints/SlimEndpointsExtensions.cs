using System.Net;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace SlimEndpoints;

public static class SlimEndpointsExtensions
{
    public static IEndpointRouteBuilder Map<TEndpoint>(this IEndpointRouteBuilder builder, [RouteTemplate] string route = "/") where TEndpoint : IEndpoint
    {
        TEndpoint.ConfigureEndpoint(builder, route)
            .WithName(TEndpoint.EndpointName);

        return builder;
    }

    public static RouteHandlerBuilder ProducesInternalServerError(this RouteHandlerBuilder builder, string? contentType = null) =>
        builder.ProducesProblem((int)HttpStatusCode.InternalServerError, contentType);

    public static RouteHandlerBuilder ProducesNotFound(this RouteHandlerBuilder builder, string? contentType = null) =>
        builder.ProducesProblem((int)HttpStatusCode.NotFound, contentType);
}
