namespace TaskNote.Http.Client.HttpUrls
{
    public class ProductUrl : IHttpUrl
    {
        public virtual string SaverDomain => $"http://staging.task.nakashima.toshiki.jp";

        // メモ：ルートパラメータEndPointはasp.net coreでも[Http
        // HttpClietnだと{}に囲まれた文字を置き換えるメソッドがないので、自分で作る必要性がある？
        // 文字リテラルで置き換えてもいいけど、asp.net coreサイドでも
        // [HttpGet("[action]/{productId}}]属性でルートパラメータを指定するので、
        // サーバサイドと共通化するならTask.Note.Httpに移動したほうがいいかも
        public string SessionEndPoint => "credential/verfication";

        public virtual string TaskEndPoint => "{user_id}/task";

        public string LogEndPoint => "{user_id}/log";

        public string ConfigEndPoint => "{user_id}/config";
    }
}
