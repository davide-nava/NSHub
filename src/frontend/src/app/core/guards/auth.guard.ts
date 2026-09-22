import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

const AUTH_FORM_ROUTES = [
  'login-form',
  'reset-password',
  'create-account',
  'change-password/:recoveryCode',
];

export const authGuard: CanActivateFn = (route: ActivatedRouteSnapshot) => {
  const router = inject(Router);
  const authService = inject(AuthService);

  const isLoggedIn = authService.isAuthenticated();
  const routePath = route.routeConfig?.path || '';
  const isAuthForm = AUTH_FORM_ROUTES.includes(routePath);

  if (isLoggedIn && isAuthForm) {
    authService.setLastAuthenticatedPath('/');
    return router.parseUrl('/');
  }

  if (!isLoggedIn && !isAuthForm) {
    return router.parseUrl('/login-form');
  }

  if (isLoggedIn) {
    authService.setLastAuthenticatedPath(routePath || '/');
  }

  return true;
};

