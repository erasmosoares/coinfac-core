import { UserService } from './user.service';

import { NotFoundError } from './../common/not-found';
import { AppError } from './../common/app-error';
import { throwError } from 'rxjs';
import { BadInput } from '../common/bad-input';
import { HttpHeaders } from '@angular/common/http';

export class DataService {

  public baseUrl = 'https://localhost:44372/api';

  constructor() {

  }

  public handleError(error: Response) {

    if (error.status === 404) {
      return throwError(new NotFoundError(error));
    }

    if (error.status === 400) {
      return throwError(new BadInput(error))
    }

    return throwError(new AppError(error));
  }

  public configureHeader() {
    var pid = sessionStorage.getItem("pid");
    if (!pid) {
      alert("couldn't indentify user: Please renew your session.");
    } else {
      return new HttpHeaders({ 'Content-Type': 'application/json' }).set('Authorization', `Basic  ${btoa(pid)}`);
    }
  }

  public configureUserHeader() {
    return new HttpHeaders({ 'Content-Type': 'application/json' });
  }
}


