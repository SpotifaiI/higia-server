import Task from './Task';
import User from './User';

export class Collaborator extends User {
  isAdmin: boolean;
  tasks: Task[];

  constructor(name: string, birthday: Date, email: string, phone: string, tasks: Task[]) {
    super(name, birthday, email, phone);
    this.isAdmin = false;
    this.tasks = tasks;
  }
}
