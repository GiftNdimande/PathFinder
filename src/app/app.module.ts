import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Pages/auth/login/login.component';
import { RegisterComponent } from './Pages/auth/register/register.component';
import { CourseListComponent } from './Pages/courses/course-list/course-list.component';
import { UserDashboardComponent } from './Pages/dashboard/user-dashboard/user-dashboard.component';
import { NavbarComponent } from './Navigations/navbar/navbar.component';
import { AdminDashboardComponent } from './Pages/dashboard/admin-dashboard/admin-dashboard.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddCourseComponent } from './Pages/courses/add-course/add-course.component';
import { UpdateCourseComponent } from './Pages/courses/update-course/update-course.component';
import { CourseDetailsComponent } from './Pages/courses/course-details/course-details.component';
import { LearnershipListComponent } from './Pages/Learnships/learnership-list/learnership-list.component';
import { AddLearnershipComponent } from './Pages/Learnships/add-learnership/add-learnership.component';
import { LearnershipDetailsComponent } from './Pages/Learnships/learnership-details/learnership-details.component';
import { UpdateLearnershipComponent } from './Pages/Learnships/update-learnership/update-learnership.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CourseListComponent,
    UserDashboardComponent,
    NavbarComponent,
    AdminDashboardComponent,
    AddCourseComponent,
    UpdateCourseComponent,
    CourseDetailsComponent,
    LearnershipListComponent,
    AddLearnershipComponent,
    LearnershipDetailsComponent,
    UpdateLearnershipComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    MatIconModule,
    MatPaginatorModule,
    FormsModule
  ],
  providers: [
    provideClientHydration(),
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
