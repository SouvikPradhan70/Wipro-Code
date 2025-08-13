import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { Course } from './course.model';
import { CourseList } from './course-list/course-list';
import { CourseDetails } from './course-details/course-details';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, FormsModule, CourseList, CourseDetails],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  courses: Course[] = [
    { id: 1, title: "Angular", description: "Angular A-Z" },
    { id: 2, title: "Python", description: "Python A-Z" },
    { id: 3, title: "Java", description: "Java A-Z" }
  ];

  selectedCourse?: Course;

  onCouseSelected(course: Course) {
    this.selectedCourse = { ...course };
  }
}
