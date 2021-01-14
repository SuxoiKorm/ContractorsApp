async function test() {
    let url = '/api/counterparty/';
    let response = await fetch(url);
    if (response.ok) {
        let json = await response.json();
        alert(json[0].Name);
    } else {
        alert("Ошибка HTTP: " + response.status);
    }
}
test();