function showLogin() {
    document.getElementById("login-form").style.display = "block";
    document.getElementById("register-form").style.display = "none";

    document.getElementById("login-btn").classList.add("active");
    document.getElementById("register-btn").classList.remove("active");
}

function showRegister() {
    document.getElementById("register-form").style.display = "block";
    document.getElementById("login-form").style.display = "none";

    document.getElementById("register-btn").classList.add("active");
    document.getElementById("login-btn").classList.remove("active");
}


function handleRegister(event) {
    event.preventDefault(); 

    const firstName = document.getElementById("register-firstName").value;
    const lastName = document.getElementById("register-lastName").value;
    const email = document.getElementById("register-email").value;
    const password = document.getElementById("register-password").value;

    fetch("https://localhost:7161/api/user/register", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ firstName, lastName, email, password }),
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            alert("Registration Successful! Please log in.");
            showLogin(); 
        } else {
            alert("Registration Failed: " + data.message);
        }
    })
    .catch(error => {
        console.error("Error:", error);
        alert("An error occurred while registering.");
    });
}

function handleLogin(event) {
    event.preventDefault(); 

    const email = document.getElementById("login-email").value;
    const password = document.getElementById("login-password").value;

    fetch("https://localhost:7161/api/user/login", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, password }),
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {

            localStorage.setItem("jwtToken", data.data);

            window.location.href = "greetings.html";
        } else {
            alert("Login Failed: " + data.message);
        }
    })
    .catch(error => {
        console.error("Error:", error);
        alert("An error occurred while logging in.");
    });
}
