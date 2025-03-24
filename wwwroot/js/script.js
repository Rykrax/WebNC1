const baseAPI = "http://localhost:5116/api/";
const userAPI = baseAPI + "users/";
const bankAPI = baseAPI + "banks/";
const transactionAPI = baseAPI + "transactions/";
const authAPI = baseAPI + "auth/";

// console.log(baseAPI, userAPI, bankAPI);

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

let alertMessage = (status, message) => {
    if (status === 400) {
        alert(message);
    }
};

let handleCreateUser = () => {
    // e.preventDefault();
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
        let successAlert = document.getElementById("successAlert");
        let errorAlert = document.getElementById("errorAlert");
        console.log(user.message);
        if (user.status === 400) {
            errorAlert.innerHTML = user.message;
            errorAlert.classList.remove("d-none");
            successAlert.classList.add("d-none");
        }
        if (user.status === 200) {
            successAlert.innerHTML = user.message;
            successAlert.classList.remove("d-none");
            errorAlert.classList.add("d-none");
            setTimeout(() => {
                window.location.href = "/login";
            }, 3000);
        }
        //  else {
        //     errorAlert.classList.add("d-none");
        //     if (user.status === 200) {
        //         successAlert.innerHTML = user.message;
        //         successAlert.classList.remove("d-none");
        //         errorAlert.classList.add("d-none");
        //     }
        // }
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
    document.querySelector('#register').addEventListener('submit', handleCreateUser);
};

start();