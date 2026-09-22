import { Component, inject, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CreateAccountData } from '@core/models';
import { AuthService } from '@core/services';
import { ValidationCallbackData } from 'devextreme-angular/common';
import { DxFormModule } from 'devextreme-angular/ui/form';
import { DxLoadIndicatorModule } from 'devextreme-angular/ui/load-indicator';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-create-account-form',
  templateUrl: './create-account-form.component.html',
  styleUrl: './create-account-form.component.scss',
  imports: [RouterLink, DxFormModule, DxLoadIndicatorModule],
})
export class CreateAccountFormComponent {
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

  readonly loading = signal<boolean>(false);
  formData: CreateAccountData = {
    email: '',
    password: '',
    confirmedPassword: '',
  };

  async onSubmit(e: Event): Promise<void> {
    e.preventDefault();
    const { email, password } = this.formData;
    this.loading.set(true);

    const result = await this.authService.createAccount(email, password);
    this.loading.set(false);

    if (result.isOk) {
      await this.router.navigate(['/login-form']);
    } else {
      notify(result.message || 'Failed to create account', 'error', 2000);
    }
  }

  confirmPassword = (e: ValidationCallbackData): boolean => {
    return e.value === this.formData.password;
  };
}

