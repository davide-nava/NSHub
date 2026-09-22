import { Component, inject } from '@angular/core';
import { TaskItem } from '@core/models';
import { CustomStoreAdapter, TaskApiService } from '@infrastructure/index';
import { TaskGridComponent } from './components/task-grid.component';

@Component({
  selector: 'app-tasks',
  template: `
    <h2>Tasks</h2>
    <app-task-grid [dataSource]="dataSource"></app-task-grid>
  `,
  imports: [TaskGridComponent],
})
export class TasksComponent {
  private readonly taskApiService = inject(TaskApiService);

  readonly dataSource = {
    store: CustomStoreAdapter.create<TaskItem>({
      key: 'id',
      load: () => this.taskApiService.getAllTasks(),
    }),
  };
}

