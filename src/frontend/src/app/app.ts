import { Component, computed, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { AuthService, ScreenService, AppInfoService } from '@core/services';
import { FooterComponent } from '@shared/components';
import { UnauthenticatedContainerComponent } from '@features/auth';
import { SideNavOuterToolbarComponent } from '@presentation/layouts';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.scss',
  imports: [
    RouterOutlet,
    SideNavOuterToolbarComponent,
    FooterComponent,
    UnauthenticatedContainerComponent,
  ],
  host: {
    '[class]': 'hostClasses()',
  },
})
export class AppComponent {
  private readonly authService = inject(AuthService);
  private readonly screen = inject(ScreenService);

  readonly appInfo = inject(AppInfoService);

  readonly isAuthenticated = this.authService.isAuthenticated;

  readonly hostClasses = computed(() => {
    const sizes = this.screen.sizes();

    const sizeClassName = Object.keys(sizes)
      .filter((key) => sizes[key])
      .join(' ');

    return `${sizeClassName} app`;
  });
}
