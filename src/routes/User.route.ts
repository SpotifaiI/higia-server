import {Router} from 'express';

import UserController from '../controllers/User.controller';

const UserRoutes = Router();

const userController = new UserController();

UserRoutes.get('/', userController.list.bind(userController));
UserRoutes.get('/:id', userController.show.bind(userController));

export default UserRoutes;