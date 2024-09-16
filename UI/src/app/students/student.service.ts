import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Class } from '../models/Class';
import { Student } from '../models/Student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private apiUrl = 'https://localhost:7273/api/students';

  constructor(private http: HttpClient) { }

  // Get all students class-wise
  getStudentsClassWise(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/list`);
  }

  // Add a new student
  addStudent(formData: FormData): Observable<any> {
    return this.http.post<any>(this.apiUrl, formData);
  }

  // Get available classes for student dropdown
  getClasses(): Observable<Class[]> {
    return this.http.get<Class[]>('https://localhost:7273/api/class');
  }

  // Search for students by name
  searchStudents(name: string): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.apiUrl}/search?name=${name}`);
  }
 
}
