import { v4 as uuidv4 } from 'uuid';

class UserTask {
    userID: string;
    taskID: string;  
    userTaskID: string;  
  
    constructor(userID: string, taskID: string, userTaskID: string) {
      this.userID = userID;
      this.taskID = taskID;
      this.userTaskID = uuidv4();
    }
  }