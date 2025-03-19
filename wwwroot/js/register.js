document.querySelector("form").addEventListener("submit", async function (event) {
    event.preventDefault(); // Ngăn chặn reload trang

    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    let confirm = document.getElementById("confirm").value;

    if (password !== confirm) {
        alert("Mật khẩu nhập lại không khớp!");
        return;
    }

    let data = {
        email: email,
        password: password,
        confirmPassword: confirm
    };

    console.log(data);
    try {
        let response = await fetch("http://localhost:5116/api/auth/register", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });

        let result = await response.json();
        if (response.ok) {
            alert(result.message); 
            // window.location.href = "/login"; // Chuyển hướng sang trang đăng nhập
        } else {
            alert(result.message);
        }
    } catch (error) {
        console.error("Lỗi:", error);
    }
});
