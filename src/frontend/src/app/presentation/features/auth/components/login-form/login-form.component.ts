import { Component, inject, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { LoginCredentials } from '@core/models';
import { AuthService } from '@core/services';
import { DxButtonModule } from 'devextreme-angular/ui/button';
import { DxFormModule } from 'devextreme-angular/ui/form';
import { DxLoadIndicatorModule } from 'devextreme-angular/ui/load-indicator';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.scss',
  imports: [RouterLink, DxFormModule, DxButtonModule, DxLoadIndicatorModule],
})
export class LoginFormComponent {
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

  readonly loading = signal<boolean>(false);
  formData: LoginCredentials = {
    email: '',
    password: '',
    rememberMe: false,
  };

  async onSubmit(e: Event): Promise<void> {
    e.preventDefault();
    const { email, password } = this.formData;
    this.loading.set(true);

    const result = await this.authService.logIn(email, password);
    if (!result.isOk) {
      this.loading.set(false);
      notify(result.message || 'Authentication failed', 'error', 2000);
    }
  }

  onCreateAccountClick = (): void => {
    this.router.navigate(['/create-account']);
  };
}

