function getUser(){
    const userDiv=document.getElementById("userinfo");
    userDiv.innerHTML="Loading user data from promises";

    //use fetch with .then() and .catch()
    fetch('https://jsonplaceholder.typicode.com/users/2')
    .then((response)=>{
        if(!response.ok){
            throw new Error("Network error!!")
        }
        return response.json(); //converting to json 
    })
    .then((user)=>{
        //displyaing user data
        userDiv.innerHTML = `
                    <h3>User Info:</h3>
                    <p><strong>Name:</strong> ${user.name}</p>
                    <p><strong>Email:</strong> ${user.email}</p>
                `;

    })

    .catch((error)=>{
        userDiv.innerHTML = `<p style="color:red;">Error: ${error.message}</p>`;
    })
}