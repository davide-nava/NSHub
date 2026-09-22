import { Component, inject, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '@core/services';
import { DxFormModule } from 'devextreme-angular/ui/form';
import { DxLoadIndicatorModule } from 'devextreme-angular/ui/load-indicator';
import notify from 'devextreme/ui/notify';

const NOTIFICATION_TEXT = "We've sent a link to reset your password. Check your inbox.";

@Component({
  selector: 'app-reset-password-form',
  templateUrl: './reset-password-form.component.html',
  styleUrl: './reset-password-form.component.scss',
  imports: [RouterLink, DxFormModule, DxLoadIndicatorModule],
})
export class ResetPasswordFormComponent {
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

  readonly loading = signal<boolean>(false);
  formData: { email: string } = { email: '' };

  async onSubmit(e: Event): Promise<void> {
    e.preventDefault();
    const { email } = this.formData;
    this.loading.set(true);

    const result = await this.authService.resetPassword(email);
    this.loading.set(false);

    if (result.isOk) {
      await this.router.navigate(['/login-form']);
      notify(NOTIFICATION_TEXT, 'success', 2500);
    } else {
      notify(result.message || 'Failed to reset password', 'error', 2000);
    }
  }
}

