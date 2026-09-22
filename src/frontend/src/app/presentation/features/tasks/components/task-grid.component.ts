import { Component, input } from '@angular/core';
import { DxDataGridModule } from 'devextreme-angular/ui/data-grid';

@Component({
  selector: 'app-task-grid',
  templateUrl: './task-grid.component.html',
  styleUrl: './task-grid.component.scss',
  imports: [DxDataGridModule],
})
export class TaskGridComponent {
  readonly dataSource = input.required<unknown>();
}

