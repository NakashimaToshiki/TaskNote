namespace TaskNote.Http.Client.HttpUrls
{
    public class MockUrl : ProductUrl
    {
        public virtual string LocalHost => "http://localhost:8083";

        public override string SaverDomain => LocalHost;
    }
}
