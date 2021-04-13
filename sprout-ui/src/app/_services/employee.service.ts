import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Data } from '@angular/router';
import { ResponseModel } from '@app/_models/response';
import { environment } from '@environments/environment';
import { Subject, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EmployeeModel } from '../_models/employee';

@Injectable({ providedIn: 'root' })
export class EmployeeService {
  list: EmployeeModel[] = [];
    constructor(private http: HttpClient) {

    }

    createEmployee(model: EmployeeModel) {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json;'});
    
        return this.http.post<EmployeeModel[]>(`${environment.apiUrl}/api/Employee`, JSON.stringify(model), { headers });
    }

    getSalary(model: EmployeeModel) {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json;'});
    
        return this.http.post<number>(`${environment.apiUrl}/api/Employee/GetSalary`, JSON.stringify(model), { headers })
        .pipe(
            catchError(e => throwError(console.log(e)))
        );
    }
    
    getEmployees() {
        let headers = new HttpHeaders({ 'Content-Type': 'application/json;'});
    
        return this.http.get<EmployeeModel[]>(`${environment.apiUrl}/api/Employee`, { headers });
    }

}