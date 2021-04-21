namespace TaskNote.Http.Client.HttpUrls
{
    public class StagingUrl : ProductUrl
    {
        public override string SaverDomain => $"http://staging.task.nakashima.toshiki.jp";
    }
}
