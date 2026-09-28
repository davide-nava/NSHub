import { Injectable } from '@angular/core';
import { TaskItem } from '@core/models';

const API_ENDPOINT = 'https://js.devexpress.com/Demos/RwaService/api/Employees/AllTasks';

@Injectable({
  providedIn: 'root',
})
export class TaskApiService {
  async getAllTasks(): Promise<TaskItem[]> {
    try {
      const response = await fetch(API_ENDPOINT);
      if (!response.ok) {
        throw new Error(`HTTP Error: ${response.status} ${response.statusText}`);
      }
      return (await response.json()) as TaskItem[];
    } catch (err: unknown) {
      const message = err instanceof Error ? err.message : 'Unknown network error';
      throw new Error(`Failed to load tasks: ${message}`);
    }
  }
}

