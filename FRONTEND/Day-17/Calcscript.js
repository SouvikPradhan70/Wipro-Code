function calculate(){
    //step-1:get the input values
    const num1=parseFloat(document.getElementById('num1').value);
    const num2=parseFloat(document.getElementById('num2').value);
    const operation=document.getElementById('operation').value;

    const errorElement=document.getElementById('error');
    const resultElement=document.getElementById('result');


    //step-2:input validation
    if (isNaN(num1)||isNaN(num2)) {
        errorElement.textContent="Something went wrong";    
    }
    //step-3:calculation logic
    let result;
    switch(operation){
        case 'add':
            result=num1+num2;
            break;
        case 'sub':
            result=num1-num2;
            break;
        case 'mul':
            result=num1*num2;
            break;
        case 'div':
            if(num2==0){
                errorElement.textContent="Cannot devide by ZEROOOO!!";
                return;
            }
            result=num1/num2;
            break;
        
        default:
            errorElement.textContent="Invalid things are happening!!";
            return;

    }


    //step-4:Display result

    resultElement.textContent="Result: "+result;
}