using System;

namespace TaskNote.Http.Client.Arranges
{
    public interface ITaskJsonBodyParam
    {
        DateTime Dow { get; }

        string Titile { get; }

        string Context { get; }

        TaskNoteJsonBody Generate();
    }
}
