import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '@core/services';
import { ValidationCallbackData } from 'devextreme-angular/common';
import { DxFormModule } from 'devextreme-angular/ui/form';
import { DxLoadIndicatorModule } from 'devextreme-angular/ui/load-indicator';
import notify from 'devextreme/ui/notify';

@Component({
  selector: 'app-change-password-form',
  templateUrl: './change-password-form.component.html',
  imports: [DxFormModule, DxLoadIndicatorModule],
})
export class ChangePasswordFormComponent {
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  readonly loading = signal<boolean>(false);
  formData = {
    password: '',
    confirmedPassword: '',
  };

  private get recoveryCode(): string {
    return this.route.snapshot.paramMap.get('recoveryCode') || '';
  }

  async onSubmit(e: Event): Promise<void> {
    e.preventDefault();
    const { password } = this.formData;
    this.loading.set(true);

    const result = await this.authService.changePassword(password, this.recoveryCode);
    this.loading.set(false);

    if (result.isOk) {
      await this.router.navigate(['/login-form']);
    } else {
      notify(result.message || 'Failed to change password', 'error', 2000);
    }
  }

  confirmPassword = (e: ValidationCallbackData): boolean => {
    return e.value === this.formData.password;
  };
}

