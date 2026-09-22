import { Routes } from '@angular/router';
import {
  LoginFormComponent,
  ResetPasswordFormComponent,
  CreateAccountFormComponent,
  ChangePasswordFormComponent,
} from './shared/components';
import { AuthGuardService } from './shared/services';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { TasksComponent } from './pages/tasks/tasks.component';
import { authGuard } from '@core/guards/auth.guard';

export const routes: Routes = [
  {
    path: 'tasks',
    component: TasksComponent,
    canActivate: [AuthGuardService],
    loadComponent: () =>
      import('@features/tasks/tasks.component').then((m) => m.TasksComponent),
    canActivate: [authGuard],
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [AuthGuardService],
    loadComponent: () =>
      import('@features/profile/profile.component').then((m) => m.ProfileComponent),
    canActivate: [authGuard],
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuardService],
    loadComponent: () =>
      import('@features/home/home.component').then((m) => m.HomeComponent),
    canActivate: [authGuard],
  },
  {
    path: 'login-form',
    component: LoginFormComponent,
    canActivate: [AuthGuardService],
    loadComponent: () =>
      import('@features/auth/components/login-form/login-form.component').then(
        (m) => m.LoginFormComponent,
      ),
    canActivate: [authGuard],
  },
  {
    path: 'reset-password',
    component: ResetPasswordFormComponent,
    canActivate: [AuthGuardService],
    loadComponent: () =>
      import('@features/auth/components/reset-password-form/reset-password-form.component').then(
        (m) => m.ResetPasswordFormComponent,
      ),
    canActivate: [authGuard],
  },
  {
    path: 'create-account',
    component: CreateAccountFormComponent,
    canActivate: [AuthGuardService],
    loadComponent: () =>
      import('@features/auth/components/create-account-form/create-account-form.component').then(
        (m) => m.CreateAccountFormComponent,
      ),
    canActivate: [authGuard],
  },
  {
    path: 'change-password/:recoveryCode',
    component: ChangePasswordFormComponent,
    canActivate: [AuthGuardService],
    loadComponent: () =>
      import('@features/auth/components/change-password-form/change-password-form.component').then(
        (m) => m.ChangePasswordFormComponent,
      ),
    canActivate: [authGuard],
  },
  {
    path: '**',
    redirectTo: 'home',
  },
];
