using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace SlimEndpoints;

/// <summary>
/// The base interface for all endpoints.
/// </summary>
public interface IEndpoint
{
    /// <summary>
    /// The name of the endpoint. This is used to generate the OpenAPI documentation.
    /// </summary>
    public static abstract string EndpointName { get; }

    /// <summary>
    /// Configures the endpoint on the given <paramref name="builder"/>. This method is called by the <see cref="SlimEndpointsExtensions.Map{TEndpoint}"/> method.
    /// </summary>
    /// <param name="builder">The <see cref="IEndpointRouteBuilder"/> to configure the endpoint on.</param>
    /// <param name="route">The route the endpoint is reachable at.</param>
    /// <returns>The <see cref="RouteHandlerBuilder"/> to allow fluent chaining.</returns>
    public static abstract RouteHandlerBuilder ConfigureEndpoint(IEndpointRouteBuilder builder, [RouteTemplate] string route);
}
