
/**
 * データモデルのベースクラスを提供します
 * */
class ModelBase {

    /**
     * コンストラクタ
     * @param {string} prefix 接頭辞
     * @param {string} suffix 接尾辞
     */
    constructor(prefix = '', suffix = '') {
        if (prefix == undefined || prefix == '') this.prefix = '';
        else this.prefix = prefix = '_';
        if (suffix == undefined || suffix == '') this.suffix = '';
        else this.suffix = '_' + suffix;
    }

    /**
     * prefix + name + suffixのIDに一致するHTMLの要素を取得します。
     * @param {string} name id名
     */
    getDocument(name) {
        return $('#' + this.prefix + name + this.suffix);
    }

    /**
     * HTMLのvalue属性値からJsonデータを生成
     * オーバーライドして使用して下さい
     * @returns {any} Jsonデータ
     * */
    getJsonFromHtml() {
        return {};
    }
}

/** 
 * WebApiの基底クラス 
 * */
class RootApiBase {

    /**
     * コンストラクタ
     * @param {string} path urlパス
     */
    constructor(path) {
        this.url = 'https://localhost:44320/' + path;
    }

    /**
     * WebApi通信エラー発生時のメッセージ表示
     * 基底はダイアログ表示なので、変更したい場合はオーバーライドして下さい。
     * @param {string} message
     */
    alert(message) {
        window.alert(message);
    }

    /**
     * ステータスコードをBoolen型に変換します
     * @param {number} statusCode ステータスコード
     * @returns 200番台はtrueそれ以外はfalse
     */
    statusCodeConvertToBoolen(statusCode) {
        return (200 <= statusCode && statusCode < 300);
    }

    /**
     * Getメソッドのエラーハンドリング
     * @param {number} statusCode ステータスコード
     */
    getAlert(statusCode) {
        if (this.statusCodeConvertToBoolen(statusCode)) return;
        if (statusCode == 404) alert('対象のデータがサーバに見つかりませんでした。');
        else this.alert(statusCode + 'エラー\r\n' + 'データの取得に失敗');
    }

    /**
     * Postメソッドのエラーハンドリング
     * @param {number} statusCode ステータスコード
     */
    postAlert(statusCode) {
        if (this.statusCodeConvertToBoolen(statusCode)) return;
        if (statusCode == 409) this.alert('既に対象のデータがサーバに存在するため作成に失敗しました。');
        else this.alert(statusCode + 'エラー\r\n' + 'データの作成に失敗');
    }

    /**
     * Patchメソッドのエラーハンドリング
     * @param {number} statusCode ステータスコード
     */
    patchAlert(statusCode, title = '', errors) {
        if (this.statusCodeConvertToBoolen(statusCode)) return;
        let mes = title;
        if (errors != undefined) {
            errors.Description.forEach(description => {
                mes += description;
            });
        }
        if (statusCode == 404) this.alert('対象のデータがサーバに見つからず更新に失敗しました。');
        else {
            this.alert(statusCode + 'エラー\r\n' + 'データの更新に失敗\r\n' + mes);
        }
    }

    /**
     * Deleteメソッドのエラーハンドリング
     * @param {number} statusCode ステータスコード
     */
    deleteAlert(statusCode) {
        if (this.statusCodeConvertToBoolen(statusCode)) return;
        if (statusCode == 404) this.alert('対象のデータがサーバに見つからず削除に失敗しました。');
        else this.alert(statusCode + 'エラー\r\n' + 'データの削除に失敗');
    }

    /**
     * 資源の所在を生成
     * @param {string} path urlパス
     * @param {any} params リクエストパラメータ
     * @returns {string} url
     */
    getHref(path, params) {
        var href = this.url;
        if (path != undefined && path != '') {
            href += '/' + path;
        }
        if (params != undefined) {
            var search = new URLSearchParams(params);
            href += '?' + search.toString();
        }
        return href;
    }

    /**
     * サーバにリソースの表現を要求します
     * @param {string} path urlパス
     * @param {string} params リクエストパラメータ
     * @returns {Promise}
     */
    async get(path, params) {
        let response = await fetch(this.getHref(path, params), {
            method: 'GET',
        });
        let data = await response.json();
        if (!response.ok) this.getAlert(data.status);
        return data;
    }

    /**
     * サーバにリソースの削除を要求します
     * @param {string} path urlパス
     * @param {any} params リクエストパラメータ
     * @returns {Promise}
     */
    async delete(path, params) {
        let response = await fetch(this.getHref(path, params), {
            method: 'DELETE',
        });
        let data = await response.json();
        if (!response.ok) this.deleteAlert(data.status);
        return data;
    }

    /**
     * サーバにリソースの修正を要求します
     * @param {any} jsonBody リソース内容
     * @param {string} path urlパス
     * @param {any} params リクエストパラメータ
     * @returns {Promise}
     */
    async patch(jsonBody, path, params) {
        let response = await fetch(this.getHref(path, params), {
            method: 'PATCH',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(jsonBody)
        });
        let data = await response.json();
        
        if (!response.ok) {
            this.patchAlert(data.status, data.title, data.errors);
        }
        return data;
    }

    /**
     * サーバにリソースの追加を要求します
     * @param {any} jsonBody リソース内容
     * @param {string} path urlパス
     * @param {any} params リクエストパラメータ
     * @returns {Promise}
     */
    async post(jsonBody, path, params) {
        let response = await fetch(this.getHref(path, params), {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'RequestVerificationToken': $('input:hidden[name="__RequestVerificationToken"').val(),
            },
            body: JSON.stringify(jsonBody)
        });
        let data = await response.json();
        if (!response.ok) this.postAlert(data.status);
        return data;
    }
}

/**
 * WebApiサーバにリクエストを送信する
 * */
class ApiBase extends RootApiBase {

    /**
     * コンストラクタ
     * @param {string} path urlパス
     */
    constructor(path) {
        super('api/' + path);
    }

    /**
     * サーバにリソースの追加を要求します
     * @param {any} jsonBody リソース内容
     * @param {string} path urlパス
     * @param {any} params リクエストパラメータ
     * @returns {Promise}
     */
    async post(jsonBody, path, params) {
        let response = await fetch(this.getHref(path, params), {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(jsonBody)
        });
        let data = await response.json();
        if (!response.ok) this.postAlert(data.status);
        return data;
    }
}
