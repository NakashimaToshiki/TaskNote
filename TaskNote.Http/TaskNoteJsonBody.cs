using System;

namespace TaskNote.Http
{
    public class TaskNoteJsonBody : IJsonBody
    {
        public DateTime date;

        public int titile;

        public string context;
    }
}
