using System;
using TaskNote.Entity;

namespace TaskNote.Http.Client.Arranges
{
    public interface ITaskJsonBodyParam
    {
        DateTime Dow { get; }

        string Titile { get; }

        string Context { get; }

        TaskModel Generate();
    }
}
