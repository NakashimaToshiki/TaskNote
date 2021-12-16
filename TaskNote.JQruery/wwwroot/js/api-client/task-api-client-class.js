
/**
 * Taskデータを取得するWebApi
 * */
class apiTask extends apiBase {

    /**
     * コンストラクタ
     * @param {string} firstName 識別文字
     */
    constructor(firstName) {
        super("Task");
        firstName = super.convetFirstName(firstName);

        this.id = $('#' + firstName + 'Id');
        this.description = $('#' + firstName + 'Description');
        this.isCompleted = $('#' + firstName + 'IsCompleted');
    }

    /**
     * サーバからタスクデータを取得してHTMLに反映する
     * @param {number} id プライマリキー
     */
    apiGet(id) {
        super.apiGet(id);
    }

    /**
     * Jsonデータをサーバに送信して更新
     * @param {any} jsonBody Jsonデータ
     */
    apiPatch(jsonBody = this.getJsonFromHtml()) {
        super.apiPatch(jsonBody);
    }

    /**
     * 対象のタスクデータをサーバから削除
     * @param {number} id プライマリキー
     */
    apiDelete(id) {
        super.apiDelete(id);
    }

    /**
     * レスポンスのストリームをJsonとして解釈した場合に呼び出されるメソッド
     * @param {any} jsonBody Jsonデータ
     */
    jsonSubscribe(jsonBody) {
        this.setJsonToHtml(jsonBody);
    }

    /**
     * JsonデータをHTMLから取得
     * @returns {any} Jsonデータ
     */
    getJsonFromHtml() {
        return {
            Id: this.id.val(),
            Description: this.description.val(),
            IsCompleted: this.isCompleted.val(),
        };
    }

    /**
     * JsonデータでHTMLを反映
     * @param {any} jsonBody Jsonデータ
     */
    setJsonToHtml(jsonBody) {
        this.id.val(jsonBody.id);
        this.description.val(jsonBody.description);
        this.isCompleted.val(jsonBody.isCompleted);
    }
}
