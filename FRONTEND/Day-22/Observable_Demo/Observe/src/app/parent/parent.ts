import { Component,OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import{DataService} from '../data-service';

@Component({
  selector: 'app-parent',
  standalone:true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './parent.html',
  styleUrls:['./parent.css']
})
export class Parent implements OnInit{
  posts:any[]=[];

  constructor(private dataService:DataService){}
  ngOnInit(): void {
      this.dataService.getPosts().subscribe(data=>{this.posts=data;

      });
  }

}
