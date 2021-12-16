
class taskEditorApiTask extends apiTask {
    constructor(firstName = '') {
        super(firstName)
    }

    jsonSubscribe(jsonBody) {
        super.jsonSubscribe(jsonBody);
        window.alert('dekita');
    }
}


function onButtonClick() {

    let api = new taskEditorApiTask('');
    api.apiPatch();
    /*
    apiTaskPatch();


    apiTaskGet(1);*/
}




