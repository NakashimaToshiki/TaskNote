using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskNote.Http.Client
{
    public static class HttpClientServiceCollectionExtentions
    {
        public static IServiceCollection AddHttpClient(this IServiceCollection services, Action<IHttpClientServicesBuilder> configure)
        {
            configure(new HttpClientServicesBuilder(services));
            return services;
        }
    }
}
