import { DOCUMENT } from '@angular/common';
import { computed, inject, Injectable, signal } from '@angular/core';

export const THEMES = ['light', 'dark'] as const;
export type Theme = (typeof THEMES)[number];

const THEME_CLASS_NAME_PREFIX = 'dx-swatch-';

function getNextTheme(theme?: Theme): Theme {
  return (theme && THEMES[THEMES.indexOf(theme) + 1]) || THEMES[0];
}

@Injectable({
  providedIn: 'root',
})
export class ThemeService {
  private readonly document = inject(DOCUMENT);

  readonly currentTheme = signal<Theme>(getNextTheme());
  readonly isDark = computed(() => this.currentTheme() === 'dark');

  constructor() {
    this.initializeThemeClass();
  }

  private initializeThemeClass(): void {
    const appEl = this.document.querySelector('.app');
    if (appEl && !appEl.className.includes(THEME_CLASS_NAME_PREFIX)) {
      appEl.classList.add(`${THEME_CLASS_NAME_PREFIX}${this.currentTheme()}`);
    }
  }

  switchTheme(): void {
    const current = this.currentTheme();
    const next = getNextTheme(current);
    const isCurrentDark = current === 'dark';

    const appEl = this.document.querySelector('.app');
    if (appEl) {
      appEl.classList.replace(
        `${THEME_CLASS_NAME_PREFIX}${current}`,
        `${THEME_CLASS_NAME_PREFIX}${next}`,
      );

      const additionalPrefix = `${THEME_CLASS_NAME_PREFIX}additional`;
      const additionalPostfix = isCurrentDark ? `-${current}` : '';
      const additionalClass = `${additionalPrefix}${additionalPostfix}`;
      const additionalEl = appEl.querySelector(`.${additionalClass}`);

      additionalEl?.classList.replace(
        additionalClass,
        `${additionalPrefix}${isCurrentDark ? '' : '-dark'}`,
      );
    }

    this.currentTheme.set(next);
  }
}

