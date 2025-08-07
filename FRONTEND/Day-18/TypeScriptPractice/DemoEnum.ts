//step-1:declare enum which will work as a type with fix value bellow
enum Direction{
    Up, //0
    Down, //1
    Left, //2
    Right //3
}
//step-2:using enum in a function
function move(direction:Direction){
    console.log(`Moving: ${Direction[direction]}`);
    //here in above line Direction[direction] this is a reverse mapping
} //Direction[3]-->"Right"

move(Direction.Right); //Output: Moving: Right

let randomValue: any;
//Any disable all type chacking
//ex we can use it when we are not sure about the type,during migration or dynamic json handling.
randomValue="Hello";
console.log(randomValue); //hello

randomValue=42;
randomValue={key:"value"};


//Tuple implementation
let user:[string,number];

user=["Souvik",69]
console.log(`Name:${user[0]} , Age:${user[1]}`);

