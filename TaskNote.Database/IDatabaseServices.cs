﻿using Microsoft.Extensions.DependencyInjection;

namespace TaskNote.Database
{
    public interface IDatabaseServices
    {
        void Configure(IServiceCollection services);
    }
}
