import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { HttpClient } from '@angular/common/http';
import { Teacher } from '../models/Teacher';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  private apiUrl = 'https://localhost:7273/api/teachers';

  constructor(private http: HttpClient) { }
  
 // Get all teachers
 getTeachers(): Observable<Teacher[]> {
  return this.http.get<Teacher[]>(this.apiUrl);
}

// Add a new teacher
addTeacher(formData: FormData): Observable<any> {
  return this.http.post<any>(this.apiUrl, formData);
}
}
