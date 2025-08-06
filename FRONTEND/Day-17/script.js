document.getElementById("admissionForm").addEventListener("submit", function(e) {
    e.preventDefault();

    const name = document.getElementById("name").value.trim();
    const email = document.getElementById("email").value.trim();
    const contact = document.getElementById("contact").value.trim();
    const course = document.getElementById("course").value;

    let alertBox = document.getElementById("alertBox");
    alertBox.innerHTML = ""; // Clear previous messages

    let isValid = true;

    if (!name || !email || !contact || course === "-- Select --") {
        alertBox.innerHTML = `<div class="alert alert-danger">All fields are required!</div>`;
        isValid = false;
    } 
    else if (!email.includes("@")) {
        alertBox.innerHTML = `<div class="alert alert-warning">Invalid email format!</div>`;
        isValid = false;
    } 
    else if (!/^\d{10}$/.test(contact)) {
        alertBox.innerHTML = `<div class="alert alert-warning">Contact number must be 10 digits!</div>`;
        isValid = false;
    }

    if (isValid) {
        alertBox.innerHTML = `<div class="alert alert-success">Form submitted successfully!</div>`;

        document.getElementById("submittedData").innerHTML = `
            <div class="card p-3 shadow-sm">
                <h5>Submitted Details:</h5>
                <p><strong>Name:</strong> ${name}</p>
                <p><strong>Email:</strong> ${email}</p>
                <p><strong>Contact:</strong> ${contact}</p>
                <p><strong>Course:</strong> ${course}</p>
            </div>
        `;

        // Clear form
        document.getElementById("admissionForm").reset();
    }
});
