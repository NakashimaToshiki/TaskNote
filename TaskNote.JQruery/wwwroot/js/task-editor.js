


function onButtonClick() {
    var json = {
        Id : $('#Id').val(),
        Description: $('#Description').val(),
        IsCompleted: false,
    };
    let status = apiTaskPatch(json);
}

