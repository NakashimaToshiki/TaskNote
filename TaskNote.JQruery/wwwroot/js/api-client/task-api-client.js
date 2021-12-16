
/** 接続先Url */
const _apiTaskUrl = _apiBaseUrl + "/Task"

/**
 * サーバからタスクデータを取得してHTMLに反映する
 * @param {any} id キー
 * @param {string} firstName htmlのid名に付与する文字列
 */
function apiTaskGet(id, firstName = '') {
    fetch(_apiTaskUrl + '/' + id, {
        method: 'GET',
    })
        .then(response => response.json())
        .then(data => {
            if (data.status != undefined) apiGetAlert(data.status);
            else taskSubscribe(data, firstName);
        })
        ;
}

/**
 * サーバにタスクデータを送信して更新
 * @param {any} jsonBody Jsonデータ
 * @param {string} firstName htmlのid名に付与する文字列
 */
function apiTaskPatch(jsonBody = htmlTaskGetter(), firstName = '') {
    fetch(_apiTaskUrl, {
        method: 'PATCH',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(jsonBody)
    })
        .then(response => response.json())
        .then(data => {
            if (data.status != undefined) apiPatchAlert(data.status);
            else taskSubscribe(data, firstName);
        })
        ;
}

/**
 * サーバのタスクデータを削除
 * @param {number} id 削除対象キー  
 */
function apiTaskDelete(id) {
    fetch(_apiTaskUrl + '/' + id, {
        method: 'DELETE'
    })
        .then(data => {
            apiDeleteAlert(data.status)
        })
        ;
}

/**
 * サーバにタスクデータを追加
 * @param {any} jsonBody Jsonデータ
 * @param {string} firstName htmlのid名に付与する文字列
 */
function apiTaskPost(jsonBody = htmlTaskGetter(), firstName = '') {
    fetch(_apiTaskUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(jsonBody)
    })
        .then(response => response.json())
        .then(data => {
            if (data.status != undefined) apiPostAlert(data.status)
            else taskSubscribe(data, firstName);
        })
        ;
}

/**
 * レスポンスのストリームをJsonとして解釈した場合に呼び出されるメソッド
 * @param {any} jsonBody Jsonデータ
 * @param {string} firstName htmlのid名に付与する文字列
 */
function taskSubscribe(jsonBody, firstName = '') {
    htmlTaskSetter(jsonBody, firstName);
    taskChangeEvent(jsonBody);
}

/**
 * HTMLからタスクデータを取得
 * @param {string} firstName htmlのid名に付与する文字列
 * @returns {any} Jsonデータ
 */
function htmlTaskGetter(firstName = '') {
    if (firstName != '') firstName = firstName + '_';
    return {
        Id: $('#' + firstName + 'Id').val(),
        Description: $('#' + firstName + 'Description').val(),
        IsCompleted: false,
    };
}

/**
 * HTMLにタスクデータを反映
 * @param {any} jsonBody Jsonデータ
 * @param {string} firstName htmlのid名に付与する文字列
 */
function htmlTaskSetter(jsonBody, firstName = '') {
    if (firstName != '') firstName = firstName + '_';
    $('#' + firstName + 'Id').val(bodyBody.id);
    $('#' + firstName + 'Description').val(bodyBody.Description);
    $('#' + firstName + 'IsCompleted').val(bodyBody.IsCompleted);
}

/**
 * WebApiからJsonBodyを受信した場合に呼び出すカスタムイベント
 * オーバーライドして使用して下さい
 * @param {any} jsonBody Jsonデータ
 */
function taskChangeEvent(jsonBody) {

}
