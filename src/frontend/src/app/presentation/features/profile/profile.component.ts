import { Component, inject } from '@angular/core';
import { ScreenColCount } from '@core/models';
import { EmployeeDataService } from '@infrastructure/index';
import { ProfileCardComponent } from './components/profile-card.component';

@Component({
  selector: 'app-profile',
  template: `
    <h2>Profile</h2>
    <app-profile-card
      [employee]="employee()"
      [colCountByScreen]="colCountByScreen"
    ></app-profile-card>
  `,
  imports: [ProfileCardComponent],
})
export class ProfileComponent {
  private readonly employeeDataService = inject(EmployeeDataService);

  readonly employee = this.employeeDataService.employee;
  readonly colCountByScreen: ScreenColCount = {
    xs: 1,
    sm: 2,
    md: 3,
    lg: 4,
  };
}

