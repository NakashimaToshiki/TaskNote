
/** WebApiの基底クラス */
class apiBase {

    /**
     * コンストラクタ
     * @param {string} path urlパス
     */
    constructor(path) {
        this.url = 'https://localhost:44320/api' + '/' + path;
    }

    /**
     * 識別文字の末尾にアンダーバーを付与する
     * @param {string} firstName 識別文字
     * @returns {string} 識別文字
     */
    convetFirstName(firstName) {
        if (firstName == undefined || firstName == '') return firstName = '';
        else return firstName + '_';
    }

    /**
     * WebApi通信エラー発生時のメッセージ表示
     * 基底はダイアログ表示なので、変更したい場合はオーバーライドして下さい。
     * @param {string} message
     */
    apiAlert(message) {
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
    apiGetAlert(statusCode) {
        if (statusCodeConvertToBoolen(statusCode)) return;
        if (statusCode == 404) apiAlert('対象のデータがサーバに見つかりませんでした。');
        else apiAlert(statusCode + 'エラー\r\n' + 'データの取得に失敗');
    }

    /**
     * Postメソッドのエラーハンドリング
     * @param {number} statusCode ステータスコード
     */
    apiPostAlert(statusCode) {
        if (statusCodeConvertToBoolen(statusCode)) return;
        if (statusCode == 409) apiAlert('既に対象のデータがサーバに存在するため作成に失敗しました。');
        else apiAlert(statusCode + 'エラー\r\n' + 'データの作成に失敗');
    }

    /**
     * Patchメソッドのエラーハンドリング
     * @param {number} statusCode ステータスコード
     */
    apiPatchAlert(statusCode) {
        if (statusCodeConvertToBoolen(statusCode)) return;
        if (statusCode == 404) apiAlert('対象のデータがサーバに見つからず更新に失敗しました。');
        else apiAlert(statusCode + 'エラー\r\n' + 'データの更新に失敗');
    }

    /**
     * Deleteメソッドのエラーハンドリング
     * @param {number} statusCode ステータスコード
     */
    apiDeleteAlert(statusCode) {
        if (statusCodeConvertToBoolen(statusCode)) return;
        if (statusCode == 404) apiAlert('対象のデータがサーバに見つからず削除に失敗しました。');
        else apiAlert(statusCode + 'エラー\r\n' + 'データの削除に失敗');
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
     * オーバーライドして使います
     * @returns {any} Jsonデータ
     */
    getJsonFromHtml() {
        return {
        };
    }

    /**
     * JsonデータでHTMLを反映
     * オーバーライドして使います
     * @param {any} jsonBody Jsonデータ
     */
    setJsonToHtml(jsonBody) {
    }

    /**
     * Jsonデータをサーバから取得してHTMLに反映する
     * @param {string} path urlパス
     */
    apiGet(path) {
        fetch(this.url + '/' + path, {
            method: 'GET',
        })
            .then(response => response.json())
            .then(data => {
                if (data.status != undefined) this.apiGetAlert(data.status);
                else this.jsonSubscribe(data);
            })
            ;
    }

    /**
     * Jsonデータをサーバに送信して更新
     * @param {any} jsonBody Jsonデータ
     */
    apiPatch(jsonBody = this.getJsonFromHtml()) {
        fetch(this.url, {
            method: 'PATCH',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(jsonBody)
        })
            .then(response => response.json())
            .then(data => {
                if (data.status != undefined) this.apiPatchAlert(data.status);
                else this.jsonSubscribe(data);
            })
            ;
    }

    /**
     * 対象データをサーバから削除
     * @param {string} path urlパス
     */
    apiDelete(path) {
        fetch(this.url + '/' + path, {
            method: 'DELETE'
        })
            .then(data => {
                this.apiDeleteAlert(data.status)
            })
            ;
    }

    /**
     * データをサーバに追加
     * @param {any} jsonBody Jsonデータ
     */
    apiPost(jsonBody = this.getJsonFromHtml()) {
        fetch(this.url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(jsonBody)
        })
            .then(response => response.json())
            .then(data => {
                if (data.status != undefined) this.apiPostAlert(data.status)
                else this.jsonSubscribe(data);
            })
            ;
    }
}
