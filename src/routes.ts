import {Router} from 'express';

import UserRoutes from './routes/User.route';

const routes = Router();

routes.use('/users', UserRoutes);

export default routes;