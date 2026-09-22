import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AppInfoService {
  readonly title = signal('Nshub');
  readonly currentYear = signal(new Date().getFullYear());
}

