

function onAddTask() {
    let api = new ApiTask();
    //api.post();

    //let ul = $('#ul');
    var ul = document.getElementById('ul');
    var li = document.createElement('li');
    var text = document.createTextNode('abc');
    li.appendChild(text);
    ul.appendChild(li);
}