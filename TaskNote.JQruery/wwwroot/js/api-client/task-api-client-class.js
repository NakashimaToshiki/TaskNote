
/**
 * タスクモデルのベースクラスを提供します
 * */
class TaskModel extends ModelBase {

    /**
     * コンストラクタ
     * @param {string} prefix 接頭辞
     * @param {string} suffix 接尾辞
     */
    constructor(prefix = '', suffix = '') {
        super(prefix, suffix);

        this.id = super.getDocument('Id');
        this.description = super.getDocument('Description');
        this.isCompleted = super.getDocument('IsCompleted');
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
        //this.isCompleted.val(jsonBody.isCompleted);
    }
}

/**
 * Taskデータを取得するWebApi
 * */
class ApiTask extends ApiBase {

    constructor() {
        super('Task');
    }

    /**
     * サーバにタスクの表現を要求します
     * @param {number} id プライマリキー
     * @returns {Promise}
     */
    get(id) {
        return super.get(id);
    }

    /**
     * サーバにタスクの修正を要求します
     * @param {any} jsonBody リソース
     * @returns {Promise}
     */
    patch(jsonBody) {
        super.patch(jsonBody);
    }

    /**
     * サーバにタスクの削除を要求します
     * @param {number} id プライマリキー
     * @returns {Promise}
     */
    delete(id) {
        return super.delete(id);
    }
}
