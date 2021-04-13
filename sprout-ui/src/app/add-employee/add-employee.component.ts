import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeModel } from '@app/_models/employee';
import { EmployeeService } from '@app/_services/employee.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.less']
})
export class AddEmployeeComponent implements OnInit {
  employeeForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router,
  ) { }
  ngOnInit() {
      this.employeeForm = this.formBuilder.group({
        name: ['', Validators.required],
        birthdate: ['', Validators.required],
        tin: ['', Validators.required],
        employeeType: [0, Validators.required],
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
// convenience getter for easy access to form fields
get f() { return this.employeeForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.employeeForm.invalid) {
        return;
    }

    this.loading = true;
    let employee = new EmployeeModel();
      employee.name = this.employeeForm.get('name').value;
      employee.birthDate = this.employeeForm.get('birthdate').value;
      employee.tin = this.employeeForm.get('tin').value;
      employee.employeeType = Number(this.employeeForm.get('employeeType').value);

    this.employeeService.createEmployee(employee)
        .subscribe(
            data => {
                this.router.navigate([this.returnUrl]);
            },
            error => {
                this.error = error;
                this.loading = false;
            });
}

}
