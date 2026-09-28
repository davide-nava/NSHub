import { Component, computed, inject } from '@angular/core';
import { ThemeService } from '@core/services';
import { DxButtonModule } from 'devextreme-angular/ui/button';

@Component({
  selector: 'theme-switcher',
  template: `
    <dx-button
      class="theme-button"
      stylingMode="text"
      [icon]="icon()"
      [elementAttr]="{ 'aria-label': 'Toggle theme' }"
      (onClick)="onButtonClick()"
    ></dx-button>
  `,
  imports: [DxButtonModule],
})
export class ThemeSwitcherComponent {
  readonly themeService = inject(ThemeService);
  readonly icon = computed(() => (this.themeService.isDark() ? 'sun' : 'moon'));

  onButtonClick(): void {
    this.themeService.switchTheme();
  }
}

