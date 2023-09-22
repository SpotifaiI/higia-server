import {config} from 'dotenv';

import app from './app';
import {PORT} from './utils/constants';

config();

app.listen(PORT);