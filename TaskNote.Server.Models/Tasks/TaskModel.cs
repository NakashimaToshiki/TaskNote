using System;
using System.ComponentModel.DataAnnotations;

namespace TaskNote.Server.Models.Tasks
{
    public class TaskModel : IModel
    {
        [Display(Name = "Upload")]
        [DisplayFormat(DataFormatString = "{0:G}")]
        public DateTime DateTime { get; set; }

        [Display(Name = "タイトル")]
        public string Title { get; set; }

        [Display(Name = "内容")]
        public string Description { get; set; }

        public TaskModel()
        {

        }

        public override string ToString() => this.ToStringProperties();
    }
}
