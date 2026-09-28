import { Component, input } from '@angular/core';
import { DxDataGridModule } from 'devextreme-angular/ui/data-grid';
import type DataSource from 'devextreme/data/data_source';
import type { DataSourceOptions } from 'devextreme/data/data_source';
import type { Store } from 'devextreme/data/store';

export type TaskGridDataSource =
  | string
  | unknown[]
  | DataSource
  | DataSourceOptions
  | Store;

@Component({
  selector: 'app-task-grid',
  templateUrl: './task-grid.component.html',
  styleUrl: './task-grid.component.scss',
  imports: [DxDataGridModule],
})
export class TaskGridComponent {
  readonly dataSource = input.required<TaskGridDataSource>();
}

