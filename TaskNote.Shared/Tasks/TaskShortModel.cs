using System.ComponentModel.DataAnnotations;

namespace TaskNote.Tasks
{
    /// <summary>
    /// 一覧表示するための簡易モデル
    /// </summary>
    public class TaskShortModel : IDataClass
    {
        public int Id { get; set; }

        [Display(Name = "タイトル")]
        public string Title { get; set; }

        public TaskShortModel()
        {

        }

        public override string ToString() => this.ToStringProperties();
    }
}
