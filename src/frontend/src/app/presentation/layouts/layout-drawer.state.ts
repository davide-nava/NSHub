import { computed, inject, signal } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { ScreenService, ThemeService } from '@core/services';
import { DxDrawerTypes } from 'devextreme-angular/ui/drawer';
import { DxScrollViewComponent } from 'devextreme-angular/ui/scroll-view';
import { DxTreeViewTypes } from 'devextreme-angular/ui/tree-view';

export class LayoutDrawerState {
  protected readonly screen = inject(ScreenService);
  protected readonly router = inject(Router);
  protected readonly themeService = inject(ThemeService);

  readonly selectedRoute = signal<string>('');
  readonly menuOpened = signal<boolean>(this.screen.isLarge());
  readonly temporaryMenuOpened = signal<boolean>(false);

  readonly swatchClassName = computed(
    () => `dx-swatch-additional${this.themeService.isDark() ? '-dark' : ''}`,
  );

  readonly menuMode = computed<DxDrawerTypes.OpenedStateMode>(() =>
    this.screen.isLarge() ? 'shrink' : 'overlap',
  );

  readonly menuRevealMode = computed<DxDrawerTypes.RevealMode>(() =>
    this.screen.isXSmall() ? 'slide' : 'expand',
  );

  readonly minMenuSize = computed<number>(() => (this.screen.isXSmall() ? 0 : 60));

  readonly shaderEnabled = computed<boolean>(() => !this.screen.isLarge());

  readonly hideMenuAfterNavigation = computed(
    () => this.menuMode() === 'overlap' || this.temporaryMenuOpened(),
  );

  constructor() {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.selectedRoute.set(event.urlAfterRedirects.split('?')[0]);
      }
    });
  }

  toggleMenu(): void {
    this.menuOpened.update((opened) => !opened);
  }

  handleNavigationChange(
    event: DxTreeViewTypes.ItemClickEvent,
    scrollView?: DxScrollViewComponent,
  ): void {
    const itemData = event.itemData as { path?: string } | undefined;
    const path = itemData?.path;
    const pointerEvent = event.event;

    if (path && this.menuOpened()) {
      if (event.node?.selected) {
        pointerEvent?.preventDefault();
      } else {
        this.router.navigate([path]);
        scrollView?.instance?.scrollTo(0);
      }

      if (this.hideMenuAfterNavigation()) {
        this.temporaryMenuOpened.set(false);
        this.menuOpened.set(false);
        pointerEvent?.stopPropagation();
      }
    } else {
      pointerEvent?.preventDefault();
    }
  }

  handleNavigationClick(): void {
    if (!this.menuOpened()) {
      this.temporaryMenuOpened.set(true);
      this.menuOpened.set(true);
    }
  }
}

