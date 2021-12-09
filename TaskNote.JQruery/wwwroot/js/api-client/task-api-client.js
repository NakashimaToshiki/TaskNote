
const _apiTaskUrl = _apiBaseUrl + "/Task"

function apiTaskGet(id) {
    let ret;
    fetch(_apiTaskUrl + '/' + id, {
        method: 'GET',
    })
        .then(response => response.json())
        .then(data => {
            apiGetAlert(data.status)
        })
        ;
    return ret;
}

function apiTaskPatch(jsonBody) {
    fetch(_apiTaskUrl, {
        method: 'PATCH',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(jsonBody)
    })
        .then(response => response.json())
        .then(data => {
            apiPatchAlert(data.status)
            return statusCodeConvertToBoolen(data.status);
        })
        ;
}

function apiTaskDelete(id) {
    fetch(_apiTaskUrl + '/' + id, {
        method: 'DELETE'
    })
        .then(response => response.json())
        .then(data => {
            apiDeleteAlert(data.status)
            return statusCodeConvertToBoolen(data.status);
        })
        ;
}

function apiTaskPost(jsonBody) {
    fetch(_apiTaskUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(jsonBody)
    })
        .then(response => response.json())
        .then(data => {
            apiPostAlert(data.status)
            return statusCodeConvertToBoolen(data.status);
        })
        ;
}