import {v4 as uuidv4} from 'uuid';
import User from './User';

class Task {
  id: string;
  created_at: Date;
  initial_date: Date;
  end_date: Date;
  initial_coordinate: string;
  end_coordinate: string;
  observation: string;
  description: string;
  user: User[]

  constructor(
    created_at: Date,
    initial_date: Date,
    end_date: Date,
    initial_coordinate: string,
    end_coordinate: string,
    observation: string,
    description: string,
    user: User[]
  ) {
    this.id = uuidv4()
    this.created_at = created_at;
    this.initial_date = initial_date;
    this.end_date = end_date;
    this.initial_coordinate = initial_coordinate;
    this.end_coordinate = end_coordinate;
    this.observation = observation;
    this.description = description;
    this.user = user;
  }
}

export default Task;