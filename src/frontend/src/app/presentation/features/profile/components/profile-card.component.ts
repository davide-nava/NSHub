import { Component, computed, input } from '@angular/core';
import { Employee, ScreenColCount } from '@core/models';
import { DxFormModule } from 'devextreme-angular/ui/form';

const BASE_IMG_URL = 'https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/';

@Component({
  selector: 'app-profile-card',
  templateUrl: './profile-card.component.html',
  styleUrl: './profile-card.component.scss',
  imports: [DxFormModule],
})
export class ProfileCardComponent {
  readonly employee = input.required<Employee>();
  readonly colCountByScreen = input<ScreenColCount>({
    xs: 1,
    sm: 2,
    md: 3,
    lg: 4,
  });

  readonly avatarUrl = computed(() => `${BASE_IMG_URL}${this.employee().Picture}`);
}

