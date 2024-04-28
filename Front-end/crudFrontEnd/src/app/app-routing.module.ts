import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { EmployeeListComponent } from './components/employee/employee-list/employee-list.component';
import { EmployeeCreateComponent } from './components/employee/employee-create/employee-create.component';
import { EmployeeUpdateComponent } from './components/employee/employee-update/employee-update.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  {title:'CRUD | Front-End', path:'', component:HomeComponent},
  {title:'Employee', path:'employee', component:EmployeeComponent,
    children:[
      {title:'List Employee', path:'', component:EmployeeListComponent},
      {title:'Create Employee', path:'create', component:EmployeeCreateComponent},
      {title:'Update Employee', path:'update', component:EmployeeUpdateComponent}
    ]
  },
  {title:'Login', path:'login', component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
