namespace TaskNote.Http.Client.HttpUrls
{
    public class ProductUrl : IHttpUrl
    {
        public virtual string SaverDomain => $"https://localhost:44318";

        // メモ：ルートパラメータEndPointはasp.net coreでも[Http
        // HttpClietnだと{}に囲まれた文字を置き換えるメソッドがないので、自分で作る必要性がある？
        // 文字リテラルで置き換えてもいいけど、asp.net coreサイドでも
        // [HttpGet("[action]/{productId}}]属性でルートパラメータを指定するので、
        // サーバサイドと共通化するならTask.Note.Httpに移動したほうがいいかも
        public string CredentialEndPoint => "api/credential";

        public virtual string TaskEndPoint => "api/task/{user_id}";

        public string LogEndPoint => "api​/ClientTraceLog/{user_id}";

        public string ConfigEndPoint => "config/{user_id}";
    }
}
