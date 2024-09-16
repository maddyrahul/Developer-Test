import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { TeacherService } from '../teacher.service';

@Component({
  selector: 'app-add-teacher',
  templateUrl: './add-teacher.component.html',
  styleUrl: './add-teacher.component.css'
})
export class AddTeacherComponent implements OnInit {
  teacherForm!: FormGroup;
  selectedFile: File | null = null;
  submitted = false;

  constructor(private fb: FormBuilder, private teacherService: TeacherService) { }

  ngOnInit(): void {
    this.teacherForm = this.fb.group({
      name: ['', Validators.required],
      age: ['', Validators.required],
      sex: ['', Validators.required]
    });
  }

  // Use a getter to explicitly cast the form control as FormControl
  getControl(controlName: string): FormControl {
    return this.teacherForm.get(controlName) as FormControl;
  }

  onFileChange(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
    }
  }

  onSubmit() {
    this.submitted = true;

    if (this.teacherForm.invalid) {
      return;
    }

    const formData = new FormData();
    formData.append('name', this.getControl('name').value);
    formData.append('age', this.getControl('age').value);
    formData.append('sex', this.getControl('sex').value);

    if (this.selectedFile) {
      formData.append('image', this.selectedFile);
    }

    this.teacherService.addTeacher(formData).subscribe(response => {
      console.log('Teacher added successfully');
    });
  }
}