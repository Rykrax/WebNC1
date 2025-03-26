let LoginAPI = "http://localhost:5116/api/auth/login";
let successAlert = document.getElementById("successAlert");
let errorAlert = document.getElementById("errorAlert");

let clearInput = () => {
    document.getElementById("email").value = "";
    document.getElementById("password").value = "";
};

let showAlert = (status, message) => {
    if (status === 401) {
        errorAlert.innerHTML = message;
        errorAlert.classList.remove("d-none");
        successAlert.classList.add("d-none");
    }
    if (status === 200) {
        successAlert.innerHTML = message;
        successAlert.classList.remove("d-none");
        errorAlert.classList.add("d-none");
    }
}

let login = (data, callback) => {
    console.time("API Response Time"); // Bắt đầu đo thời gian
    let options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }

    fetch(LoginAPI, options)
        .then(response => {
            console.timeEnd("API Response Time"); // Kết thúc đo thời gian
            return response.json();
        })
        .then(callback)
        .catch(error => console.error("Lỗi khi gửi request:", error));
};

let handleLogin = (data) => {
    login(data, (user) => {
        console.log(user.message);
        showAlert(user.status, user.message);
        if (user.status === 200) {
            clearInput();
            setTimeout(() => {
                window.location.href = "/";
            }, 3000);
        }
    });
};

// document.querySelector("form").addEventListener("submit", (event) => {
//     event.preventDefault(); 

//     let email = document.getElementById("email").value;
//     let password = document.getElementById("password").value;
//     let remember = document.getElementById("remember").checked;


//     console.log("Email:", email);
//     console.log("Mật khẩu:", password);
//     console.log("Nhớ mật khẩu:", remember);

//     let data = {
//         email: email,
//         password: password
//     }

//     login(data, (user) => {
//         console.log(user.message);
//         showAlert(user.status, user.message);
//         if (user.status === 200) {
//             clearInput();
//             setTimeout(() => {
//                 window.location.href = "/";
//             }, 3000);
//         }
//     });
// });

