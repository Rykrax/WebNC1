document.querySelector("form").addEventListener("submit", function (event) {
    event.preventDefault(); // Ngăn gửi form để kiểm tra dữ liệu

    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    let remember = document.getElementById("form2Example31").checked;

    console.log("Email:", email);
    console.log("Mật khẩu:", password);
    console.log("Nhớ mật khẩu:", remember);
});
