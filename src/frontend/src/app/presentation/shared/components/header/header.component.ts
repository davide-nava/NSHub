import { Component, inject, input, output } from '@angular/core';
import { Router } from '@angular/router';
import { UserMenuItem } from '@core/models';
import { AuthService } from '@core/services';
import { DxButtonModule } from 'devextreme-angular/ui/button';
import { DxToolbarModule } from 'devextreme-angular/ui/toolbar';
import { ThemeSwitcherComponent } from '../theme-switcher/theme-switcher.component';
import { UserPanelComponent } from '../user-panel/user-panel.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
  imports: [DxButtonModule, DxToolbarModule, UserPanelComponent, ThemeSwitcherComponent],
})
export class HeaderComponent {
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

  readonly menuToggleEnabled = input<boolean>(false);
  readonly title = input<string>('');
  readonly menuToggle = output<void>();

  readonly userMenuItems: UserMenuItem[] = [
    {
      text: 'Profile',
      icon: 'user',
      onClick: () => {
        this.router.navigate(['/profile']);
      },
    },
    {
      text: 'Logout',
      icon: 'runner',
      onClick: () => {
        this.authService.logOut();
      },
    },
  ];

  readonly toggleMenu = (): void => {
    this.menuToggle.emit();
  };
}

