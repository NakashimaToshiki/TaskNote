using TaskNote.Entity.TaskItems;
using TaskNote.Http.Client.Arranges;

namespace TaskNote.Models
{
    public static class ArrangeEqualEntityExtentions
    {
        public static bool EqualEntity(this ITaskJsonBodyParam me, TaskEntity entity)
        {
            return
                me.Titile == entity.Title;
        }
    }
}
