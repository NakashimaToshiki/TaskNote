namespace TaskNote.Http.Client
{
    // 必要があればDomainとEndpointで分離が検討できる？

    public interface IHttpUrl
    {
        // メモ：Urlセグメントによるバージョン管理は辞めたほうがいいHttpヘッダーにバージョン番号を付与するのがベスト
        //string Version01 { get; }

        string SaverDomain { get; }

        string TaskEndPoint { get; }
    }
}
