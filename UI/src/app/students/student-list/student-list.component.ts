import { Component, OnInit } from '@angular/core';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrl: './student-list.component.css'
})
export class StudentListComponent implements OnInit {
  studentClassWiseList: any[] = [];  // Initialize as an empty array
  filteredStudentClassWiseList: any[] = [];  // Initialize as an empty array
  searchTerm: string = '';  // Initialize searchTerm

  constructor(private studentService: StudentService) {}

  ngOnInit(): void {
    this.loadStudentList();
  }

  // Load the full list of students class-wise
  loadStudentList(): void {
    this.studentService.getStudentsClassWise().subscribe(data => {
      this.studentClassWiseList = data ?? [];  // Use nullish coalescing
      this.filteredStudentClassWiseList = data ?? [];  // Use nullish coalescing
    });
  }

  // Search for students by name
  onSearch(): void {
    if (this.searchTerm.trim() === '') {
      this.filteredStudentClassWiseList = this.studentClassWiseList;
    } else {
      this.studentService.searchStudents(this.searchTerm).subscribe(filteredData => {
        this.filteredStudentClassWiseList = this.groupStudentsByClass(filteredData ?? []);  // Use nullish coalescing
      });
    }
  }

  // Group students by class
  private groupStudentsByClass(filteredStudents: any[]): any[] {
    const classMap = new Map<string, any[]>();

    filteredStudents.forEach(student => {
      const className = student?.className ?? 'Unknown';  // Use optional chaining and nullish coalescing
      if (!classMap.has(className)) {
        classMap.set(className, []);
      }
      classMap.get(className)!.push(student);  // Non-null assertion operator
    });

    const result: any[] = [];
    classMap.forEach((students, className) => {
      result.push({ className, students });
    });

    return result;
  }
}
