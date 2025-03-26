const userAPI = 'http://localhost:5116/api/users';
let listUsers = document.querySelector('#list-users-body');

let getUser = (callback) => {
    fetch(userAPI)
        .then(response => response.json())
        .then(callback)
};

let rendderUsers = (users) => {
    console.log(users);
    let htmls = users.map(user => {
        return `<tr class="user-item-${user.userID}">
            <td>${user.fullName}</td>
            <td>${user.cccd}</td>
            <td>${user.email}</td>
            <td>${user.balance}</td>
            <td><button onclick="handleDeleteUser('${user.phoneNumber}')">Xoá</button></td>
        </tr>`;
    });

    listUsers.innerHTML = htmls.join('');
}

let start = () => {
    getUser(rendderUsers);
}

start();