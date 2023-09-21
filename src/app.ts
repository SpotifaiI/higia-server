import express, { json } from 'express';
import cors from 'cors';

import routes from './routes';
import testConnection from './config/db/db';
const app = express();

app.use(json());
app.use(cors());
app.use(routes);

testConnection();

export default app;