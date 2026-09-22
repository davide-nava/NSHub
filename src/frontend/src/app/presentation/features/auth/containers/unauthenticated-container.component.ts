import { Component, computed, inject } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { SingleCardComponent } from '@layouts/index';

@Component({
  selector: 'app-unauthenticated-container',
  template: `
    <app-single-card [title]="title()" [description]="description()">
      <router-outlet></router-outlet>
    </app-single-card>
  `,
  styles: [
    `
      :host {
        display: block;
        width: 100%;
        height: 100%;
      }
    `,
  ],
  imports: [RouterOutlet, SingleCardComponent],
})
export class UnauthenticatedContainerComponent {
  private readonly router = inject(Router);

  readonly title = computed(() => {
    const path = this.router.url.split('/')[1] || '';
    switch (path) {
      case 'login-form':
        return 'Sign In';
      case 'reset-password':
        return 'Reset Password';
      case 'create-account':
        return 'Sign Up';
      case 'change-password':
        return 'Change Password';
      default:
        return '';
    }
  });

  readonly description = computed(() => {
    const path = this.router.url.split('/')[1] || '';
    switch (path) {
      case 'reset-password':
        return 'Please enter the email address that you used to register, and we will send you a link to reset your password via Email.';
      default:
        return '';
    }
  });
}

