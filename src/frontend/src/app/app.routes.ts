import { Routes } from '@angular/router';
import { AuthGuardService } from '@core/services';

export const routes: Routes = [
  {
    path: 'tasks',
    loadComponent: () => import('@features/tasks/tasks.component').then((m) => m.TasksComponent),
    canActivate: [AuthGuardService],
  },
  {
    path: 'profile',
    loadComponent: () =>
      import('@features/profile/profile.component').then((m) => m.ProfileComponent),
    canActivate: [AuthGuardService],
  },
  {
    path: 'home',
    loadComponent: () => import('@features/home/home.component').then((m) => m.HomeComponent),
    canActivate: [AuthGuardService],
  },
  {
    path: 'login-form',
    loadComponent: () =>
      import('@features/auth/components/login-form/login-form.component').then(
        (m) => m.LoginFormComponent,
      ),
    canActivate: [AuthGuardService],
  },
  {
    path: 'reset-password',
    loadComponent: () =>
      import('@features/auth/components/reset-password-form/reset-password-form.component').then(
        (m) => m.ResetPasswordFormComponent,
      ),
    canActivate: [AuthGuardService],
  },
  {
    path: 'create-account',
    loadComponent: () =>
      import('@features/auth/components/create-account-form/create-account-form.component').then(
        (m) => m.CreateAccountFormComponent,
      ),
    canActivate: [AuthGuardService],
  },
  {
    path: 'change-password/:recoveryCode',
    loadComponent: () =>
      import('@features/auth/components/change-password-form/change-password-form.component').then(
        (m) => m.ChangePasswordFormComponent,
      ),
    canActivate: [AuthGuardService],
  },
  {
    path: '**',
    redirectTo: 'home',
  },
];
