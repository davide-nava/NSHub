import { Component, input, viewChild } from '@angular/core';
import { DxDrawerModule } from 'devextreme-angular/ui/drawer';
import { DxScrollViewComponent, DxScrollViewModule } from 'devextreme-angular/ui/scroll-view';
import { DxToolbarModule, DxToolbarTypes } from 'devextreme-angular/ui/toolbar';
import { DxTreeViewTypes } from 'devextreme-angular/ui/tree-view';
import { HeaderComponent, SideNavigationMenuComponent } from '../../shared/components';
import { LayoutDrawerState } from '../layout-drawer.state';

@Component({
  selector: 'app-side-nav-inner-toolbar',
  templateUrl: './side-nav-inner-toolbar.component.html',
  styleUrl: './side-nav-inner-toolbar.component.scss',
  imports: [
    HeaderComponent,
    SideNavigationMenuComponent,
    DxDrawerModule,
    DxToolbarModule,
    DxScrollViewModule,
  ],
})
export class SideNavInnerToolbarComponent {
  readonly scrollView = viewChild<DxScrollViewComponent>('scrollView');
  readonly title = input<string>('');

  readonly drawerState = new LayoutDrawerState();

  readonly onMenuToggleClick = (e: DxToolbarTypes.ItemClickEvent): void => {
    this.drawerState.toggleMenu();
    e.event?.stopPropagation();
  };

  onNavigationChanged(event: DxTreeViewTypes.ItemClickEvent): void {
    this.drawerState.handleNavigationChange(event, this.scrollView());
  }
}

