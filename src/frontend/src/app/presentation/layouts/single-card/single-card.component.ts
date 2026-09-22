import { Component, input } from '@angular/core';
import { DxScrollViewModule } from 'devextreme-angular/ui/scroll-view';

@Component({
  selector: 'app-single-card',
  templateUrl: './single-card.component.html',
  styleUrl: './single-card.component.scss',
  imports: [DxScrollViewModule],
})
export class SingleCardComponent {
  readonly title = input<string>('');
  readonly description = input<string>('');
}

