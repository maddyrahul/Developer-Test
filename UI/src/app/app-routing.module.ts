import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentListComponent } from './students/student-list/student-list.component';
import { AddStudentComponent } from './students/add-student/add-student.component';
import { AddTeacherComponent } from './teachers/add-teacher/add-teacher.component';
import { AddSubjectComponent } from './subjects/add-subject/add-subject.component';
import { SubjectListComponent } from './subjects/subject-list/subject-list.component';

const routes: Routes = [
  { path: '', redirectTo: '/students', pathMatch: 'full' },
  { path: 'students', component: StudentListComponent },
  { path: 'students/add', component: AddStudentComponent },
  { path: 'teachers/add', component: AddTeacherComponent },
  { path: 'subjects/add', component: AddSubjectComponent },
  { path: 'subject-list', component: SubjectListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
