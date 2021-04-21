using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskNote.Http.Client
{
    public interface IHttpClientServicesBuilder
    {
        IServiceCollection Services { get; }
    }

    public class HttpClientServicesBuilder : IHttpClientServicesBuilder
    {
        public HttpClientServicesBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public IServiceCollection Services { get; }
    }

    public static class HttpClientServicesExtentions
    {
        public static void AddConfiguration<TServices>(this IHttpClientServicesBuilder builder) where TServices : IHttpClientServices
        {
            var instance = (TServices)Activator.CreateInstance(typeof(TServices));
            instance.Configure(builder.Services);
        }
        public static void AddConfiguration<TServices>(this IHttpClientServicesBuilder builder, IHttpUrl options) where TServices : IHttpClientServices
        {
            builder.AddConfiguration<TServices>();
            builder.Services.AddSingleton(options);
        }
    }
}
