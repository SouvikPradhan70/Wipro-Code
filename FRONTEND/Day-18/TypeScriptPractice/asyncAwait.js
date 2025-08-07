 // Step 1: Define async getUser function
        async function getUser() {
            const userDiv = document.getElementById("userinfo");
            userDiv.innerHTML = "Loading user data from API.....";

            // Step 2: Fetch data asynchronously from a sample API
            try {
                const response = await fetch('https://jsonplaceholder.typicode.com/users/1');

                // Step 3: Check if response is ok
                if (!response.ok) {
                    throw new Error("Network response was not ok");
                }

                // Step 4: Convert response to JSON
                const user = await response.json();

                // Step 5: Update UI with fetched data
                userDiv.innerHTML = `
                    <h3>User Info:</h3>
                    <p><strong>Name:</strong> ${user.name}</p>
                    <p><strong>Email:</strong> ${user.email}</p>
                `;
            } catch (error) {
                // Step 6: Handle error if any
                userDiv.innerHTML = `<p style="color:red;">Error: ${error.message}</p>`;
            }
        }