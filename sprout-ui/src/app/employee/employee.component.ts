import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeModel } from '@app/_models/employee';
import { EmployeeService } from '@app/_services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.less']
})
export class EmployeeComponent implements OnInit {
  employees: EmployeeModel[];
  loading = false;
  currentEmployee: EmployeeModel;
  days: number = 0;
  employeeForm: FormGroup;
  salary: number;

  constructor(private formBuilder: FormBuilder,
    private employeeService: EmployeeService) { 

  }

  ngOnInit() {
      this.employeeForm = this.formBuilder.group({
        employeeId: ['', Validators.required],
        name: ['', Validators.required],
        birthdate: ['', Validators.required],
        tin: ['', Validators.required],
        employeeType: [0, Validators.required],
        days: [0, Validators.required]
    });

      this.employeeService.getEmployees().subscribe(employee => {
        this.loading = false;
        this.employees = employee;
    });
  }

  selectEmployee(employee) {
    this.employeeForm.setValue(employee);
    this.currentEmployee = employee;
    this.salary = 0;
  }

  getSalary() {
    this.employeeService.getSalary(this.employeeForm.value).subscribe(result => {
      this.salary = result;
    })
  }

}
