import {
  ApplicationConfig,
  provideZoneChangeDetection,
  provideBrowserGlobalErrorListeners,
} from '@angular/core';
import { provideRouter, withComponentInputBinding, withHashLocation } from '@angular/router';
import { routes } from './app.routes';
import { AppInfoService, AuthService, AuthGuardService, ScreenService } from '@core/services';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    AuthGuardService,
    AuthService,
    ScreenService,
    AppInfoService,
    provideRouter(routes, withHashLocation(), withComponentInputBinding()),
  ],
};
