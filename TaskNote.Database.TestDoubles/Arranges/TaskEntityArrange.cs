using System;
using TaskNote.Entity.TaskItems;

namespace TaskNote.Entity.Arranges
{
    public interface ITaskEntityArrange : IDataClass
    {
        public int Id { get; }

        TimeSpan Offset { get; }

        string Title { get; }

        string Description { get; }

        TaskItem Generate();
    }

    public abstract class BaseTaskEntityArrange : ITaskEntityArrange
    {
        private readonly TaskEntityCreater _creater;

        public BaseTaskEntityArrange(TaskEntityCreater creater)
        {
            _creater = creater ?? throw new ArgumentNullException(nameof(creater));
        }

        public abstract int Id { get; }

        public abstract TimeSpan Offset { get; }

        public abstract string Title { get; }

        public abstract string Description { get; }

        public TaskItem Generate()
        {
            return _creater.Factory(Id, Title, Description);
        }

        public override string ToString() => this.ToStringProperties();
    }

    public class SampleEntityArrange : BaseTaskEntityArrange
    {
        public SampleEntityArrange(TaskEntityCreater creater) : base(creater)
        {
        }

        public override int Id => 1;

        public override TimeSpan Offset => throw new NotImplementedException();

        public override string Title => throw new NotImplementedException();

        public override string Description => throw new NotImplementedException();
    }
}
