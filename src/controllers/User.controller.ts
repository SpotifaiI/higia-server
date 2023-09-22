import {Request, Response} from 'express';
import * as uuidV4 from 'uuid';

import User from '../models/User';
import {httpCode} from "../utils/http";

class UserController {
  user: User;

  constructor() {
    this.user = new User();
  }

  async list(request: Request, response: Response) {
    let content = {};
    let httpStatusCode = httpCode.notFound;

    try {
      const data = await this.user.list();

      content = {
        success: true,
        results: data
      };
      httpStatusCode = httpCode.success;
    } catch (error) {
      content = {
        success: false,
        error
      };
      httpStatusCode = httpCode.fail;
    } finally {
      response.status(httpStatusCode).send(content);
    }
  }

  async show(request: Request, response: Response) {
    let content = {};
    let httpStatusCode = httpCode.fail;

    try {
      const userId = request.params.id;

      if (!userId) {
        httpStatusCode = httpCode.notFound;

        throw 'ID de usuário não enviado.';
      }

      if (!uuidV4.validate(userId)) {
        throw 'ID de usuário está no formato inválido. O formato a ser enviado é UUIDv4.';
      }

      const data = await this.user.show(userId);

      content = {
        success: true,
        result: data
      };
      httpStatusCode = httpCode.success;
    } catch (error) {
      content = {
        success: false,
        error
      };
    } finally {
      response.status(httpStatusCode).send(content);
    }
  }
}

export default UserController;