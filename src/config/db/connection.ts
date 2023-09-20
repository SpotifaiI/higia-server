import { USER, HOST, DATABASE, PORT, PASSWORD } from "../const";
const { Pool } = require('pg');

const pool = new Pool({
    user: USER,
    host: HOST,
    database: DATABASE,
    password: PASSWORD,
    port: PORT,
  });

export default pool;