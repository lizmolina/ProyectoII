import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { ProjectComponent } from './project/project.component';
import { UserComponent } from './user/user.component';
import { RegisterComponent } from './register/register.component';


const routes: Routes = [
  { path: '', component: LoginComponent , pathMatch: 'full'},
  { path: 'register', component: RegisterComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'user', component: UserComponent, pathMatch: 'full' },
  { path: 'project', component:  ProjectComponent, pathMatch: 'full' },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
