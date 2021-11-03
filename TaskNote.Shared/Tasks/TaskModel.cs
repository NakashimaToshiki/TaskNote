using System;
using System.ComponentModel.DataAnnotations;

namespace TaskNote.Tasks
{
    public class TaskModel : TaskShortModel
    {
        [Display(Name = "Upload")]
        [DisplayFormat(DataFormatString = "{0:G}")]
        public DateTime UpdateDate { get; set; }

        [Display(Name = "内容")]
        public string Description { get; set; }

        public TaskModel()
        {
        }

        public override string ToString() => this.ToStringProperties();
    }
}
