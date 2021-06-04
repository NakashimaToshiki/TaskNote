using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaskNote.Platform
{
    public static class TestServiceCollectionExtentions
    {
        public static IServiceCollection UseTest(this IServiceCollection services, [CallerMemberName] string testName = "")
        {
            return services
                .UseTestOptions(new TestOptions(testName))
                .AddHttpTest()
                ;
        }

        public static IServiceCollection AddHttpTest(this IServiceCollection services)
        {
            /*
#if DEBUG
            services.AddHttpClient(_ => _.AddConfiguration<MockHttpClientServices>());
#else
            services.AddHttpClient(_ => _.AddProvider<Rest.RestHttpClientServices>());
#endif
            */
            return services
                ;
        }
    }
}
