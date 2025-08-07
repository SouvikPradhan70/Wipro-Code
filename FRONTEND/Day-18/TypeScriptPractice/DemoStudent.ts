// enum
enum Department {
  Science = "Science",
  Commerce = "Commerce",
  Arts = "Arts"
}
//Interface 
interface StudentDetails {
    id: number;
    name:string;
    age:number;
    department: Department;//referring as enum 
}
//decorator
function LogCreation(constructor: Function) {
    console.log(`Student class created:${constructor.name} `);
}
//class & tuple
@LogCreation
class Student{
    private studentMap:Map<number,[string,number,Department]> = new Map();
    constructor() {
        console.log("Student System Initilized");
    }
    addStudent(student : StudentDetails): void{
        const {id,name,age,department} = student;
        this.studentMap.set(id,[name,age,department]);
    }
//itertor 
     printAllSudents(): void {
    for (const [id,[name,age,dept]] of this.studentMap.entries ()) {
    console.log(`ID: ${id}, Name: ${name}, Age: ${age}, Dept: ${dept}`);
}
 }
 
}
const s = new  Student();
s.addStudent({id:1, name:"Raj",age:20,department:Department.Science});
s.printAllSudents();