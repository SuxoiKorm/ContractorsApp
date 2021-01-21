var myList = document.querySelector('ul');
let url = '/api/counterparty/';
fetch(url)
    .then(function (response) { return response.json(); })
    .then(function (data) {
        for (var i = 0; i < data.length; i++) {
            var adr = data[i].Address;
            if (data[i].Address == null) {
                adr = '';
            }
            var listItem = document.createElement('li');
            listItem.onclick = async function () {
                let form = document.forms.editinputForm;
                let objectUrl = '/api/counterparty/' + this.id;
                let response = await fetch(objectUrl);
                let object = await response.json();
                let nameElem = form.name;
                let phoneElem = form.phone;
                let addressElem = form.address;
                nameElem.value = object.Name;
                phoneElem.value = object.Phone;
                addressElem.value = object.Address;
            };
            listItem.id = data[i].Id;         
            listItem.innerHTML = data[i].Name + ' ' + data[i].Phone + ' ' + adr;
            myList.appendChild(listItem);
        }
    });
function sendForm() {
    let form = document.forms.editinputForm;
    var body = {
        Name: form.name.value,
        Phone: form.phone.value,
        Address: form.address.value
    }
    fetch("/api/counterparty/",
        {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
                'Accept': '*/*'
            },
            body: JSON.stringify(body)
        })
        .then(function (res) { return res.json(); })
        .then(function (data) { alert(JSON.stringify(data)) })
    location.reload();
}