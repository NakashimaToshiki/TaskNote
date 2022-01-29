using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TaskNote.Entity
{
    /// <summary>
    /// 一覧表示するための簡易モデル
    /// </summary>
    public class TaskShortModel : IDataClass
    {
        public int Id { get; set; }

        [Display(Name = "タイトル")]
        public string Title { get; set; }

        public override string ToString() => this.ToStringProperties();
    }

    public class NullTaskShortModel : TaskShortModel
    {
        public static NullTaskShortModel Instance { get; } = new NullTaskShortModel()
        {
            Id = 0,
            Title = "null"
        };

        protected NullTaskShortModel()
        {
        }
    }

    public class TaskModel : TaskShortModel
    {
        public string Description { get; set; }

        public bool IsCompleted { get; set; } = false;

        [DisplayFormat(DataFormatString = "{0:G}")]
        public DateTime UpdateDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; }

        public override string ToString() => this.ToStringProperties();
    }

    public class NullTaskModel : TaskModel
    {
        public static NullTaskModel Instance { get; } = new NullTaskModel()
        {
            Id = 0,
            UpdateDate = DateTime.MinValue,
            Title = "null",
            Description = "null",
        };

        protected NullTaskModel()
        {
        }
    }
}
