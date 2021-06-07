namespace TaskNote.Models.TaskModels
{
    public class MissingTaskModel : TaskModel
    {
        public static MissingTaskModel Instance { get; } = new MissingTaskModel();

        private MissingTaskModel() : base("Missing Title", "Missing Description", false)
        {
            
        }
    }
}
