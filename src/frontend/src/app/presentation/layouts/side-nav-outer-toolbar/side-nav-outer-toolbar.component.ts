import { Component, input, viewChild } from '@angular/core';
import { DxDrawerModule } from 'devextreme-angular/ui/drawer';
import { DxScrollViewComponent, DxScrollViewModule } from 'devextreme-angular/ui/scroll-view';
import { DxTreeViewTypes } from 'devextreme-angular/ui/tree-view';
import { HeaderComponent, SideNavigationMenuComponent } from '@shared/components';
import { LayoutDrawerState } from '@presentation/layouts';

@Component({
  selector: 'app-side-nav-outer-toolbar',
  templateUrl: './side-nav-outer-toolbar.component.html',
  styleUrl: './side-nav-outer-toolbar.component.scss',
  imports: [HeaderComponent, SideNavigationMenuComponent, DxDrawerModule, DxScrollViewModule],
})
export class SideNavOuterToolbarComponent {
  readonly scrollView = viewChild<DxScrollViewComponent>('scrollView');
  readonly title = input<string>('');

  readonly drawerState = new LayoutDrawerState();

  onNavigationChanged(event: DxTreeViewTypes.ItemClickEvent): void {
    this.drawerState.handleNavigationChange(event, this.scrollView());
  }
}
