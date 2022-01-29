namespace TaskNote.Entity
{
    public class SexModel : IDataClass
    {
        public Sex Id { get; set; }

        public string Name { get; set; }

        public override string ToString() => this.ToStringProperties();
    }

    public enum Sex
    {
        None,
        Male,
        Female,
    }
}
