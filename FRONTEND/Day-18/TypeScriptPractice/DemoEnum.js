//step-1:declare enum which will work as a type with fix value bellow
var Direction;
(function (Direction) {
    Direction[Direction["Up"] = 0] = "Up";
    Direction[Direction["Down"] = 1] = "Down";
    Direction[Direction["Left"] = 2] = "Left";
    Direction[Direction["Right"] = 3] = "Right"; //3
})(Direction || (Direction = {}));
//step-2:using enum in a function
function move(direction) {
    console.log("Moving: ".concat(Direction[direction]));
    //here in above line Direction[direction] this is a reverse mapping
} //Direction[3]-->"Right"
move(Direction.Right); //Output: Moving: Right
var randomValue;
//Any disable all type chacking
//ex we can use it when we are not sure about the type,during migration or dynamic json handling.
randomValue = "Hello";
console.log(randomValue); //hello
randomValue = 42;
randomValue = { key: "value" };
//Tuple implementation
var user;
user = ["Souvik", 69];
console.log("Name:".concat(user[0], " , Age:").concat(user[1]));
