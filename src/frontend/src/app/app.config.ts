import { ApplicationConfig, provideZoneChangeDetection , provideBrowserGlobalErrorListeners} from '@angular/core';
import { provideRouter, withHashLocation } from '@angular/router';
import { provideRouter, withComponentInputBinding, withHashLocation } from '@angular/router';
import { routes } from './app.routes';
import { AppInfoService, AuthGuardService, AuthService, ScreenService } from './shared/services';

export const appConfig: ApplicationConfig = {
  providers: [
  	provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes, withHashLocation()),
    AuthGuardService,
    AuthService,
    ScreenService,
    AppInfoService,
    provideRouter(routes, withHashLocation(), withComponentInputBinding()),
  ],
};
