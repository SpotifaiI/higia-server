import db from '../config/db/db';

class User {
  connection;

  constructor() {
    this.connection = db.user;
  }

  async list() {
    const {data, error} = await this.connection.select('user_id');

    if (error) {
      throw error.message;
    }

    return data;
  }

  async show(userId: string) {
    const {data, error} = await this
      .connection
      .select('user_id')
      .eq('user_id', userId);

    if (error) {
      throw error.message;
    }

    return data[0] || null;
  }
}

export default User;