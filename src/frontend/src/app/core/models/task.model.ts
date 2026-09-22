export type TaskPriority = 'Low' | 'Normal' | 'High' | 'Urgent';
export type TaskStatus = 'Completed' | 'In Progress' | 'Deferred' | 'Need Assistance' | 'Not Started';

export interface TaskItem {
  id: number;
  text: string;
  status: TaskStatus | string;
  owner: string;
  startDate: string | Date;
  dueDate: string | Date;
  priority: TaskPriority | string;
}

