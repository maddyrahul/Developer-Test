import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SubjectService } from '../../subjects/subject.service';
import { StudentService } from '../student.service';
import { Class } from '../../models/Class';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrl: './add-student.component.css'
})
export class AddStudentComponent implements OnInit {
  studentForm!: FormGroup;
  selectedFile: File | null = null;
  submitted = false;
  classes: Class[] = [];

  constructor(private fb: FormBuilder, private studentService: StudentService) { }

  ngOnInit(): void {
    this.studentForm = this.fb.group({
      name: ['', Validators.required],
      age: ['', Validators.required],
      classRollNumber: ['', Validators.required],
      classId: ['', Validators.required]
    });

    // Fetch available classes
    this.studentService.getClasses().subscribe((data: Class[]) => {
      this.classes = data;
    });
  }

  // Explicitly cast controls as FormControl for template binding
  getControl(controlName: string): FormControl {
    return this.studentForm.get(controlName) as FormControl;
  }

  get f() {
    return this.studentForm.controls;
  }

  onFileChange(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
    }
  }

  onSubmit() {
    this.submitted = true;

    if (this.studentForm.invalid) {
      return;
    }

    const formData = new FormData();
    formData.append('name', this.f['name'].value);
    formData.append('age', this.f['age'].value);
    formData.append('classRollNumber', this.f['classRollNumber'].value);
    formData.append('classId', this.f['classId'].value);

    if (this.selectedFile) {
      formData.append('image', this.selectedFile);
    }

    this.studentService.addStudent(formData).subscribe(response => {
      console.log('Student added successfully');
    });
  }
}
