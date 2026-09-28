import { Component, computed, effect, input, output, viewChild } from '@angular/core';
import { APP_NAVIGATION, NavigationItem } from '@core/models';
import { DxTreeViewComponent, DxTreeViewModule, DxTreeViewTypes } from 'devextreme-angular/ui/tree-view';

@Component({
  selector: 'app-side-navigation-menu',
  templateUrl: './side-navigation-menu.component.html',
  styleUrl: './side-navigation-menu.component.scss',
  imports: [DxTreeViewModule],
  host: {
    '(click)': 'onHostClick($event)',
  },
})
export class SideNavigationMenuComponent {
  readonly treeView = viewChild<DxTreeViewComponent>('treeView');

  readonly selectedItem = input<string>('');
  readonly compactMode = input<boolean>(false);

  readonly selectedItemChanged = output<DxTreeViewTypes.ItemClickEvent>();
  readonly openMenu = output<Event>();

  readonly navigationItems = computed<NavigationItem[]>(() => {
    const compact = this.compactMode();
    return APP_NAVIGATION.map((item) => {
      const normalizedPath = item.path && !item.path.startsWith('/') ? `/${item.path}` : item.path;
      return {
        ...item,
        path: normalizedPath,
        expanded: !compact,
      };
    });
  });

  constructor() {
    effect(() => {
      const item = this.selectedItem();
      const tv = this.treeView();
      if (item && tv?.instance) {
        tv.instance.selectItem(item);
      }
    });

    effect(() => {
      const compact = this.compactMode();
      const currentSelection = this.selectedItem();
      const tv = this.treeView();
      if (!tv?.instance) return;

      if (compact) {
        tv.instance.collapseAll();
      } else if (currentSelection) {
        tv.instance.expandItem(currentSelection);
      }
    });
  }

  onItemClick(event: DxTreeViewTypes.ItemClickEvent): void {
    this.selectedItemChanged.emit(event);
  }

  onHostClick(event: Event): void {
    this.openMenu.emit(event);
  }
}

