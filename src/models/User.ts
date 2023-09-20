import { v4 as uuidv4 } from 'uuid';

abstract class User {
    id: string;
    birthday: Date;
    name: string
    email: string;
    created_at: Date;
    phone: string;

    constructor(name: string, birthday: Date, email:string, phone: string) {
        this.id = uuidv4();
        this.name = name;
        this.email = email
        this.phone = phone
        this.birthday = birthday;
        this.created_at = new Date(); 
    }
}

export default User;