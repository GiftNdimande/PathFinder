import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrl: './course-list.component.scss'
})
export class CourseListComponent {
  courses = [
    { id: 1, name: 'Computer Science', code: 'BSc', institution: 'University of Pretoria' },
    { id: 2, name: 'Information Technology', code: 'BIT', institution: 'University of Johannesburg' },
    { id: 1, name: 'Informatics', code: 'BCOM', institution: 'University of Pretoria' },
    { id: 2, name: 'Information TKnowladge Systems', code: 'EBIT', institution: 'University of Johannesburg' },
    { id: 1, name: 'LAW', code: 'BA', institution: 'University of Pretoria' },
    { id: 2, name: 'Teaching', code: 'BED', institution: 'University of Johannesburg' },
  ];
  filteredCourses = [...this.courses];
  searchTerm = '';

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void { }

  applyFilter(searchTerm: any): void {
    this.filteredCourses = this.courses.filter(course =>
      course.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      course.code.toLowerCase().includes(searchTerm.toLowerCase()) ||
      course.institution.toLowerCase().includes(searchTerm.toLowerCase())
    );
  }

  viewCourse(id: number): void {
    console.log('View course', id);
  }

  openUpdateDialog(course: any): void {
    console.log('Edit course', course);
  }

  deleteCourse(id: number): void {
    console.log('Delete course', id);
  }

}
