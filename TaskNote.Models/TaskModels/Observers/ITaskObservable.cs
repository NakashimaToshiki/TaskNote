using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskNote.Models.TaskModels.Observers
{
    public interface ITaskObservable
    {
        void TaskModelStatus(TaskModel value);
    }

    public class TaskObservable : IObservable<TaskModel>, ITaskObservable
    {
        private readonly CancellationTokenSource _cancellation;
        private readonly List<IObserver<TaskModel>> _observers;

        public TaskObservable(CancellationTokenSource cancellation)
        {
            _observers = new List<IObserver<TaskModel>>();
            _cancellation = cancellation ?? throw new ArgumentNullException(nameof(cancellation));
        }

        public IDisposable Subscribe(IObserver<TaskModel> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber<TaskModel>(_observers, observer);
        }

        public void TaskModelStatus(TaskModel value)
        {
            var po = new ParallelOptions
            {
                CancellationToken = _cancellation.Token
            };
            Parallel.ForEach(_observers, po, item =>
            {
                item.OnNext(value);
            });
        }
    }

    public class Unsubscriber<TaskModel> : IDisposable
    {
        private readonly List<IObserver<TaskModel>> _observers;
        private readonly IObserver<TaskModel> _observer;

        public Unsubscriber(List<IObserver<TaskModel>> observers, IObserver<TaskModel> observer)
        {
            _observers = observers ?? throw new ArgumentNullException(nameof(observers));
            _observer = observer ?? throw new ArgumentNullException(nameof(observer));
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
