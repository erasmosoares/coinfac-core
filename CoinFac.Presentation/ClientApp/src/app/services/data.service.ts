
import { NotFoundError } from './../common/not-found';
import { AppError } from './../common/app-error';
import { throwError } from 'rxjs';
import { BadInput } from '../common/bad-input';
import { HttpHeaders } from '@angular/common/http';

export class DataService {
  
  public headers = new HttpHeaders({'Content-Type': 'application/json'});

  public baseUrl = 'https://localhost:44372/api';

  public handleError(error: Response){

    if (error.status ===404){
      return throwError(new NotFoundError(error));
    }
    
    if(error.status === 400){
      return throwError(new BadInput(error.json()))
    }
    
    return throwError(new AppError(error));
  }
}
