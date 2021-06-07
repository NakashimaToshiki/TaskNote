using System.ComponentModel.DataAnnotations;

namespace TaskNote.Platform
{
    public class TaskListItemViewModel : BindableBase
    {
        public string _text = "";

        [Required(ErrorMessage = "Nullは非許容です", AllowEmptyStrings = true)]
        public string Text
        {
            get => _text;
            set { SetProperty(ref _text, value); }
        }

        private bool _isCompleted;
        public bool IsCompleted
        {
            get => _isCompleted;
            set { SetProperty(ref _isCompleted, value); }
        }

        public TaskListItemViewModel()
        {

        }
    }
}
