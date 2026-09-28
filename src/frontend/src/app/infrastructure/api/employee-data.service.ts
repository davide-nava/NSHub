import { Injectable, signal } from '@angular/core';
import { Employee } from '@core/models';

const DEFAULT_EMPLOYEE: Employee = {
  ID: 7,
  FirstName: 'Sandra',
  LastName: 'Johnson',
  Prefix: 'Mrs.',
  Position: 'Controller',
  Picture: 'images/employees/06.png',
  BirthDate: new Date('1974/11/5'),
  HireDate: new Date('2005/05/11'),
  Notes:
    'Sandra is a CPA and has been our controller since 2008. She loves to interact with staff so if you`ve not met her, be certain to say hi.\r\n\r\nSandra has 2 daughters both of whom are accomplished gymnasts.',
  Address: '4600 N Virginia Rd.',
};

@Injectable({
  providedIn: 'root',
})
export class EmployeeDataService {
  private readonly employeeState = signal<Employee>(DEFAULT_EMPLOYEE);
  readonly employee = this.employeeState.asReadonly();

  async getProfile(): Promise<Employee> {
    return this.employeeState();
  }

  updateProfile(updated: Partial<Employee>): void {
    this.employeeState.update((prev) => ({ ...prev, ...updated }));
  }
}

