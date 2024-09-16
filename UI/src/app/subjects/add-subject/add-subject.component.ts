import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SubjectService } from '../subject.service';
import { Teacher } from '../../models/Teacher';
import { Class } from '../../models/Class';

@Component({
  selector: 'app-add-subject',
  templateUrl: './add-subject.component.html',
  styleUrl: './add-subject.component.css'
})
export class AddSubjectComponent implements OnInit {
  subjectForm!: FormGroup;
  submitted = false;
  teachers: Teacher[] = [];   // Explicitly type teachers as an array of Teacher
  classes: Class[] = [];      // Explicitly type classes as an array of Class

  constructor(private fb: FormBuilder, private subjectService: SubjectService) { }

  ngOnInit(): void {
    this.subjectForm = this.fb.group({
      name: ['', Validators.required],
      language: ['', Validators.required],
      teacherId: ['', Validators.required],
      classId: ['', Validators.required]
    });

    // Fetch teachers and classes for the dropdowns
    this.subjectService.getTeachers().subscribe((data: Teacher[]) => {
      this.teachers = data;
    });

    this.subjectService.getClasses().subscribe((data: Class[]) => {
      this.classes = data;
    });
  }

  // Use a method to explicitly cast form controls to FormControl
  getControl(controlName: string): FormControl {
    return this.subjectForm.get(controlName) as FormControl;
  }

  onSubmit() {
    this.submitted = true;

    if (this.subjectForm.invalid) {
      return;
    }

    const formData = new FormData();
    formData.append('name', this.getControl('name').value);
    formData.append('language', this.getControl('language').value);
    formData.append('teacherId', this.getControl('teacherId').value);
    formData.append('classId', this.getControl('classId').value);

    this.subjectService.addSubject(formData).subscribe(response => {
      console.log('Subject added successfully');
    });
  }
}