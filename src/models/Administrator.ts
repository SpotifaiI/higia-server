import User from './User';

export class Administrator extends User {
  isAdmin: boolean;

  constructor(name: string, birthday: Date, email: string, phone: string) {
    super(name, birthday, email, phone);
    this.isAdmin = true;
  }
}
