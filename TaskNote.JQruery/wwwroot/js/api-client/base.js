
/** WebApi接続先Url */
const _apiBaseUrl = 'https://localhost:44320/api';

// Api通信時の基底のアラートを宣言します

/**
 * WebApi通信エラー発生時のメッセージ表示
 * 基底はダイアログ表示なので、変更したい場合はオーバーライドして下さい。
 * @param {string} message
 */
function apiAlert(message) {
    window.alert(message);
}

/**
 * ステータスコードをBoolen型に変換します
 * @param {number} statusCode ステータスコード
 * @returns 200番台はtrueそれ以外はfalse
 */
function statusCodeConvertToBoolen(statusCode) {
    return (200 <= statusCode && statusCode < 300);
}

/**
 * Getメソッドのエラーハンドリング
 * @param {number} statusCode ステータスコード
 */
function apiGetAlert(statusCode) {
    if (statusCodeConvertToBoolen(statusCode)) return;
    if (statusCode == 404) apiAlert('対象のデータがサーバに見つかりませんでした。');
    else apiAlert(statusCode + 'エラー\r\n' + 'データの取得に失敗');
}

/**
 * Postメソッドのエラーハンドリング
 * @param {number} statusCode ステータスコード
 */
function apiPostAlert(statusCode) {
    if (statusCodeConvertToBoolen(statusCode)) return;
    if (statusCode == 409) apiAlert('既に対象のデータがサーバに存在するため作成に失敗しました。');
    else apiAlert(statusCode + 'エラー\r\n' + 'データの作成に失敗');
}

/**
 * Patchメソッドのエラーハンドリング
 * @param {number} statusCode ステータスコード
 */
function apiPatchAlert(statusCode) {
    if (statusCodeConvertToBoolen(statusCode)) return;
    if (statusCode == 404) apiAlert('対象のデータがサーバに見つからず更新に失敗しました。');
    else apiAlert(statusCode + 'エラー\r\n' + 'データの更新に失敗');
}

/**
 * Deleteメソッドのエラーハンドリング
 * @param {number} statusCode ステータスコード
 */
function apiDeleteAlert(statusCode) {
    if (statusCodeConvertToBoolen(statusCode)) return;
    if (statusCode == 404) apiAlert('対象のデータがサーバに見つからず削除に失敗しました。');
    else apiAlert(statusCode + 'エラー\r\n' + 'データの削除に失敗');
}
