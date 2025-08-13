import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Course } from '../course.model';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './course-list.html',
  styleUrls: ['./course-list.css']
})
export class CourseList {
  @Input() courses: Course[] = [];
  @Output() courseSelected = new EventEmitter<Course>();

  selectCourse(course: Course) {
    this.courseSelected.emit(course);
  }
}
