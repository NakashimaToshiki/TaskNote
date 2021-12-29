
function onButtonClick() {

    let api = new ApiTask();
    let model = new TaskModel();

    api.patch(model.getJsonFromHtml());

//    api.get(1).then(data => { model.setJsonToHtml(data); });
}




