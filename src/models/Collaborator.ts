import User from './User';

export class Collaborator extends User {
  isAdmin: boolean;

  constructor(name: string, birthday: Date, email: string, phone: string) {
    super(name, birthday, email, phone);
    this.isAdmin = false;
  }
}
