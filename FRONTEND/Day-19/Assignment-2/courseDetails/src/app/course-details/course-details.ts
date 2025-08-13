import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Course } from '../course.model';

@Component({
  selector: 'app-course-details',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './course-details.html',
  styleUrls: ['./course-details.css']
})
export class CourseDetails {
  @Input() course!: Course;
  @Output() courseChange = new EventEmitter<Course>();

  onCourseChange() {
    this.courseChange.emit(this.course);
  }
}
