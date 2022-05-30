const uri = 'api/Publics';
let publics = [];

function getPublics() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayPublics(data))
        .catch (error => console.error('Unable to get publics.', error));
}

function addPublic() {
    const addNameTextbox = document.getElementById('add-name');
    const addInfoTextbox = document.getElementById('add-info');

    const pub = {
        name: addNameTextbox.value.trim(),
        info: addInfoTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(pub)
    })
        .then(response => response.json())
        .then(() => {
            getPublics();
            addNameTextbox.value ='';
            addInfoTextbox.value ='';
        })
        .catch (error => console.error('Unable to add public.', error));
}

function deletePublic(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getPublics())
        .catch (error => console.error('Unable to delete public.', error));
}

function displayEditForm(id) {
    const pub = publics.find(pub => pub.id === id);

    document.getElementById('edit-id').value = pub.id;
    document.getElementById('edit-name').value = pub.name;
    document.getElementById('edit-desctiption').value = pub.info;
    document.getElementById('editForm').style.display = 'block';
}

function updatePublic() {
    const publicId = document.getElementById('edit-id').value;
    const pub = {
        id: parseInt(publicId, 10),
        name: document.getElementById('edit-name').value.trim(),
        info: document.getElementById('edit-info').value.trim()
    };

    fetch(`${uri}/${publicId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(pub)
    })
        .then(() => getPublics())
        .catch(error => console.error('Unable to update public.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayPublics(data) {
    const tBody = document.getElementById('publics');

    tBody.innerHTML ='';
    const button = document.createElement('button');
    data.forEach(pub => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${pub.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deletePublic(${pub.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(pub.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(pub.info);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    publics = data;
}