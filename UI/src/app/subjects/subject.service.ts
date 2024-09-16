import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Teacher } from '../models/Teacher';
import { Class } from '../models/Class';
import { Subject } from '../models/Subject';
import { SubjectWithTeacher } from '../models/SubjectWithTeacher';



@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  private apiUrl = 'https://localhost:7273/api/subjects';

  constructor(private http: HttpClient) { }
  // Get all subjects along with teachers
  // getSubjectsWithTeachers(): Observable<Subject[]> {
  //   return this.http.get<Subject[]>(this.apiUrl);
  // }
  getSubjectsWithTeachers(): Observable<SubjectWithTeacher[]> {
    return this.http.get<SubjectWithTeacher[]>(`${this.apiUrl}/with-teachers`);
  }
  // Add a new subject
  addSubject(formData: FormData): Observable<any> {
    return this.http.post<any>(this.apiUrl, formData);
  }

  // Get available teachers and classes for subject dropdown
  getTeachers(): Observable<Teacher[]> {
    return this.http.get<Teacher[]>('https://localhost:7273/api/teachers');
  }

  getClasses(): Observable<Class[]> {
    return this.http.get<Class[]>('https://localhost:7273/api/class');
  }

 
}
