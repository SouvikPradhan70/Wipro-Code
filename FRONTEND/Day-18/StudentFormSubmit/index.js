document.getElementById("studentForm").addEventListener("submit",function(e){
    e.preventDefault() //stop from submitting imidiatly


    //checking name 
    var name=document.getElementById("fullname").value;
    if(name.length<3){
        window.alert("Your name should be more than 3 char!!")
    }

    //checking for contact
    var contact=document.getElementById("phone").value;
    if(contact.length>10||contact.length<10){
        window.alert("Phone number shoud be 10 digit...")
    }
    //getting the email
    var email= document.getElementById("email").value;

    var studentData={
        FullName:name,
        Email:email,
        Phone:contact
    }

    alert("Student Data saved:\n"+JSON.stringify(studentData,null,2));


    document.getElementById("fullname").value="";
    document.getElementById("email").value="";
    document.getElementById("phone").value="";
})


