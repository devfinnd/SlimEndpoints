using System.Net;
using System.Net.Mime;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace SlimEndpoints;

/// <summary>
/// Extension methods for <see cref="IEndpointRouteBuilder"/> facilitating the configuration of endpoints.
/// </summary>
public static class SlimEndpointsExtensions
{
    /// <summary>
    /// Maps the given <typeparamref name="TEndpoint"/> to the given <paramref name="builder"/> at the given <paramref name="route"/>.
    /// </summary>
    /// <param name="builder">The <see cref="IEndpointRouteBuilder"/> to configure the endpoint on.</param>
    /// <param name="route">The route the endpoint is reachable at.</param>
    /// <typeparam name="TEndpoint">The Endpoint to configure.</typeparam>
    /// <returns>The <see cref="IEndpointRouteBuilder"/> to allow fluent chaining.</returns>
    public static IEndpointRouteBuilder Map<TEndpoint>(this IEndpointRouteBuilder builder, [RouteTemplate] string route = "/") where TEndpoint : IEndpoint
    {
        TEndpoint.ConfigureEndpoint(builder, route)
            .WithName(TEndpoint.EndpointName);

        return builder;
    }

    /// <summary>
    /// Configures endpoint metadata to produce <see cref="ProblemDetails"/> for <see cref="HttpStatusCode.InternalServerError"/>. Useful for OpenAPI documentation.
    /// </summary>
    /// <param name="builder">The <see cref="RouteHandlerBuilder"/> to configure the endpoint on.</param>
    /// <param name="contentType">The content type of the <see cref="ProblemDetails"/>. Defaults to <see cref="MediaTypeNames.Application.ProblemJson"/>.</param>
    /// <returns>The <see cref="RouteHandlerBuilder"/> to allow fluent chaining.</returns>
    public static RouteHandlerBuilder ProducesInternalServerError(this RouteHandlerBuilder builder, string? contentType = MediaTypeNames.Application.ProblemJson) =>
        builder.ProducesProblem((int)HttpStatusCode.InternalServerError, contentType);

    /// <summary>
    /// Configures endpoint metadata to produce <see cref="ProblemDetails"/> for <see cref="HttpStatusCode.NotFound"/>. Useful for OpenAPI documentation.
    /// </summary>
    /// <param name="builder">The <see cref="RouteHandlerBuilder"/> to configure the endpoint on.</param>
    /// <param name="contentType">The content type of the <see cref="ProblemDetails"/>. Defaults to <see cref="MediaTypeNames.Application.ProblemJson"/>.</param>
    /// <returns>The <see cref="RouteHandlerBuilder"/> to allow fluent chaining.</returns>
    public static RouteHandlerBuilder ProducesNotFound(this RouteHandlerBuilder builder, string? contentType = MediaTypeNames.Application.ProblemJson) =>
        builder.ProducesProblem((int)HttpStatusCode.NotFound, contentType);
}
