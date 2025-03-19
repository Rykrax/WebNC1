const baseAPI = "http://localhost:5116/api/";
const userAPI = baseAPI + "users/";
const bankAPI = baseAPI + "banks/";
const transactionAPI = baseAPI + "transactions/";
const authAPI = baseAPI + "auth/";

console.log(baseAPI, userAPI, bankAPI);

let createUser = (data, callback) => {
    let options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }
    
    fetch(authAPI + 'register', options)
        .then(response => response.json())
        .then(callback)
        .catch(error => console.error("Lỗi khi gửi request:", error));
};

let handleCreateUser = (e) => {
    e.preventDefault();
    console.log("vào handleCreateUser");
    let email = document.querySelector('#email').value;
    let password = document.querySelector('#password').value;
    let confirm = document.querySelector('#confirm').value;

    let data = {
        email: email,
        password: password,
        confirmPassword: confirm
    }
    console.log(data);
    createUser(data, (user) => {
        console.log(user);
    });
}

let getUsers = (callback) => {
    fetch(userAPI)
        .then(response => response.json())
        .then(callback)
};

let start = () => {
    getUsers((users) => {
        console.log(users);
    });
    document.querySelector('#register').addEventListener('click', handleCreateUser);
};

start();