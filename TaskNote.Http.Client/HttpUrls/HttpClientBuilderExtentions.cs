namespace TaskNote.Http.Client.HttpUrls
{
    public static class HttpClientBuilderExtentions
    {
        public static void AddProvider<TServices>(this IHttpClientServicesBuilder builder) where TServices : IHttpClientServices
        {
#if DEBUG || RELEASE
            builder.AddConfiguration<TServices>(new ProductUrl());
#elif MOCK
            builder.AddConfiguration<TServices>(new MockUrl());
#elif STAGING
            builder.AddConfiguration<TServices>(new StagingUrl());
#endif
        }
    }
}
