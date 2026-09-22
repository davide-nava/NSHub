import { Component, input } from '@angular/core';
import { UserMenuItem } from '@core/models';
import { DxDropDownButtonModule } from 'devextreme-angular/ui/drop-down-button';
import { DxListModule } from 'devextreme-angular/ui/list';

const DEFAULT_AVATAR =
  'https://js.devexpress.com/Demos/WidgetsGallery/JSDemos/images/employees/06.png';

@Component({
  selector: 'app-user-panel',
  templateUrl: './user-panel.component.html',
  styleUrl: './user-panel.component.scss',
  imports: [DxListModule, DxDropDownButtonModule],
})
export class UserPanelComponent {
  readonly menuItems = input<UserMenuItem[]>([]);
  readonly menuMode = input<'context' | 'list'>('context');
  readonly userAvatar = input<string>(DEFAULT_AVATAR);
}

