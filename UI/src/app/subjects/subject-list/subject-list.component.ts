import { Component, OnInit } from '@angular/core';
import { SubjectWithTeacher } from '../../models/SubjectWithTeacher';
import { SubjectService } from '../subject.service';

@Component({
  selector: 'app-subject-list',
  templateUrl: './subject-list.component.html',
  styleUrl: './subject-list.component.css'
})
export class SubjectListComponent  implements OnInit{
  subjectsWithTeachers: SubjectWithTeacher[] = [];

  constructor(private subjectService: SubjectService) { }

  ngOnInit(): void {
    this.loadSubjectsWithTeachers();
  }

  loadSubjectsWithTeachers(): void {
    this.subjectService.getSubjectsWithTeachers().subscribe(
      (data) => {
        this.subjectsWithTeachers = data;
        console.log("subject with teachers")
      },
      (error) => {
        console.error('Failed to load subjects with teachers', error);
      }
    );
  }
}
