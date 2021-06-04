using System;
using System.Collections.Generic;
using System.Text;

namespace TaskNote.Storage
{
    public class ApplicationStorage
    {
        private readonly IFileInfoFacade _facade;

        public ApplicationStorage(IFileInfoFacade facade)
        {
            this._facade = facade ?? throw new ArgumentNullException(nameof(facade));
        }

    }
}
