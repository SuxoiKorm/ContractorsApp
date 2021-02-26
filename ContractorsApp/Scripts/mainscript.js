let myList = document.getElementById("mainList");

async function getConractors(lm, off) {
    //console.log(myList);
    let url = "/api/counterparty/?limit="+lm+"&offset="+off
    fetch(url)
        .then(function (response) { return response.json(); })
        .then(function (data) {
            for (var i = 0; i < data.length; i++) {
                var adr = data[i].Address;
                if (data[i].Address == null) {
                    adr = '';
                }
                //console.Write("l")
                var listItem = document.createElement('li');
                listItem.onclick = async function () {
                    let form = document.forms.editinputForm;
                    let objectUrl = '/api/counterparty/' + this.id;
                    let response = await fetch(objectUrl);
                    let object = await response.json();
                    let nameElem = form.name;
                    let phoneElem = form.phone;
                    let addressElem = form.address;
                    form.id = this.id;
                    nameElem.value = object.Name;
                    phoneElem.value = object.Phone;
                    addressElem.value = object.Address;
                };
                //console.log(data[i].Name);
                listItem.id = data[i].Id;
                listItem.innerHTML = data[i].Name + ' ' + data[i].Phone + ' ' + adr;
                //console.log(myList);
                myList.appendChild(listItem);
            }
        });
}
function sendForm() {

    /*let validate = true;

    var name = $('.validate-input input[name="name"]');
    var phone = $('.validate-input input[name="phone"]');
    var address = $('.validate-input input[name="address"]');


    if ($(name).val().trim() == '') {
        showValidate(name);
        validate = false;
    }
    if ($(phone).val().trim() == '') {
        showValidate(phone);
        validate = false;

    }
    if ($(address).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
        showValidate(address);
        validate = false;
        
    }*/
    
    let form = document.forms.editinputForm;
    let id = form.id;
    //console.log(id);
    let body = {
        Name: form.name.value,
        Phone: form.phone.value,
        Address: form.address.value
    }
    if (id == 0) {
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
    }
    else {
        fetch("/api/counterparty/"+id,
            {
                method: "PUT",
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': '*/*'
                },
                body: JSON.stringify(body)
            })
            .then(function (res) { return res.json(); })
            .then(function (data) { alert(JSON.stringify(data)) })
    }
    /*console.log(document.getElementsByName("fileUpload"));

    console.log(document.getElementsByName("fileUpload").value)*/

    let fileInput = document.getElementsByName("fileUpload");

    console.log(fileInput[0].files[0]);
    
    let file = fileInput[0].files[0];

    if (fileInput[0].files[0] > 0) {
        let formData = new FormData();

        //console.log(document.getElementsByName("fileUpload").value)
        console.log(file);

        formData.append('file', file);

        console.log(file);
        console.log(formData);

        fetch('/api/File', { method: "POST", body: formData })
    }
    

    location.reload();
}
function writePages() {
    let mainArt = document.getElementById("mainArticle");
    let url = "/api/counterparty/";
    fetch(url)
        .then(function (response) { return response.json(); })
        .then(function (data) {
            let pages = Math.ceil(data.length / 10)
            for (var i = 0; i < pages; i++) {
                let btn = document.createElement('button');
                //console.log(i);
                //console.log(i * 10);
                let pageLink = i * 10;
                btn.onclick = async function () {
                    myList.innerHTML = "";
                    getConractors(10, pageLink);
                }
                btn.appendChild(document.createTextNode(i+1));
                mainArt.appendChild(btn);
            }
        });   
}
getConractors(10, 0)
writePages();