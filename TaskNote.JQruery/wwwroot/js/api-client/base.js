
const _apiBaseUrl = 'https://localhost:44320/api';

// Api通信時の基底のアラートを宣言します

function statusCodeConvertToBoolen(statusCode) {
    return (200 <= statusCode && statusCode < 300);
}

function apiGetAlert(statusCode) {
    if (statusCodeConvertToBoolen(statusCode)) return;
    if (statusCode == 404) window.alert('対象のデータがサーバに見つかりませんでした。');
    else window.alert(statusCode + 'エラー\r\n' + 'データの取得に失敗');
}

function apiPostAlert(statusCode) {
    if (statusCodeConvertToBoolen(statusCode)) return;
    if (statusCode == 409) window.alert('既に対象のデータがサーバに存在するため作成に失敗しました。');
    else window.alert(statusCode + 'エラー\r\n' + 'データの作成に失敗');
}

function apiPatchAlert(statusCode) {
    if (statusCodeConvertToBoolen(statusCode)) return;
    if (statusCode == 404) window.alert('対象のデータがサーバに見つからず更新に失敗しました。');
    else window.alert(statusCode + 'エラー\r\n' + 'データの更新に失敗');
}

function apiDeleteAlert(statusCode) {
    if (statusCodeConvertToBoolen(statusCode)) return;
    if (statusCode == 404) window.alert('対象のデータがサーバに見つからず削除に失敗しました。');
    else window.alert(statusCode + 'エラー\r\n' + 'データの削除に失敗');
}
