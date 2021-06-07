using System;
using System.ComponentModel.DataAnnotations;

namespace TaskNote.Platform
{
    public class TaskViewModel : BindableBase
    {
        public DateTime UpdateData
        {
            get => _updateData;
            set { SetProperty(ref _updateData, value); }
        }
        private DateTime _updateData;

        [Required(ErrorMessage = "Nullは非許容です", AllowEmptyStrings = true)]
        public string Title
        {
            get => _title;
            set { SetProperty(ref _title, value); }
        }
        private string _title;

        [Required(ErrorMessage = "Nullは非許容です", AllowEmptyStrings = true)]
        public string Description
        {
            get => _description;
            set { SetProperty(ref _description, value); }
        }
        private string _description;

        public bool IsCompleted 
        {
            get => _isCompleted;
            set { SetProperty(ref _isCompleted, value); }
        }

        private bool _isCompleted;

        public TaskViewModel()
        {

        }
    }
}
