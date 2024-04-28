import { Component } from '@angular/core';
import { ajLib } from '../../../../helpers/ajLib';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrl: './employee-create.component.css'
})
export class EmployeeCreateComponent {

  //Declaration
  loading: boolean = true;
  protected readonly ajLib = ajLib;
  EmployeeId: string | null = null;

  form: FormGroup = new FormGroup({
    EmployeeId: new FormControl(null),
    EmployeeName: new FormControl(null),
    EmployeeEmail: new FormControl(null),
    Password: new FormControl(null),
    Address: new FormControl(null)
  })

  constructor(){
    
  }

}
