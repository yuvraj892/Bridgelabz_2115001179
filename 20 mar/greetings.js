document.addEventListener("DOMContentLoaded", function () {
    fetchGreetings();
});

function fetchGreetings() {
    const token = localStorage.getItem("jwtToken");

    if (!token) {
        alert("Unauthorized! Please log in again.");
        window.location.href = "index.html"; 
        return;
    }

    fetch("https://localhost:7161/HelloGreeting/all", {
        method: "GET",
        headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json"
        }
    })
    .then(response => {
        if (!response.ok) {
            throw new Error("Failed to fetch greetings.");
        }
        return response.json();
    })
    .then(data => {
        console.log("API Response:", data); 
        
        if (!Array.isArray(data.data)) {
            throw new Error("Expected an array but received: " + JSON.stringify(data));
        }

        populateTable(data.data);
    })
    .catch(error => {
        console.error("Error:", error);
        alert("Error fetching greetings.");
    });
}

function populateTable(greetings) {
    const tableBody = document.querySelector("#greetings-table tbody");
    tableBody.innerHTML = "";

    greetings.forEach(greeting => {
        const row = document.createElement("tr");
        row.innerHTML = `
            <td>${greeting.id}</td>
            <td>${greeting.message}</td>
             <td>
                <button onclick="updateGreeting(${greeting.id})" style="background-color: green; color: white;">Update</button>
                <button onclick="deleteGreeting(${greeting.id})" style="background-color: red; color: white;">Delete</button>
            </td>
        `;
        tableBody.appendChild(row);
    });
}

function addGreeting() {
    alert("Add Greeting functionality will be implemented here.");
}

function updateGreeting(id) {
    alert("Update Greeting for ID: " + id);
}

function deleteGreeting(id) {
    alert("Delete Greeting for ID: " + id);
}
