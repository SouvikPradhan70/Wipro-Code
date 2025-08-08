import { Component } from '@angular/core'; //importing the component decorator

@Component({ //defing meta data as components
  selector: 'app-hello', //it defines how the component is used in template
  imports: [], 
  templateUrl: './hello.html', //it specifies html associated file
  styleUrl: './hello.css' //defines style
})
export class Hello {
  //this defines the angular class logic
  message="Hello angular";

}
