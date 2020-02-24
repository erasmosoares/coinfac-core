
import { NotFoundError } from './../common/not-found';
import { AppError } from './../common/app-error';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { BadInput } from '../common/bad-input';
import { Headers, RequestOptions } from '@angular/http';
import { Http } from '@angular/http';


export class DataService {

    constructor(private url: string, public http: Http) { }

  getAll(){
    return this.http.get(this.url)
    .pipe(catchError(this.handleError));
  }

  create(resource) {
    let _requestOptions: RequestOptions = new RequestOptions(
      {
        headers: new Headers({
          'Content-Type': 'application/json',
        })
      });
    return this.http.post(this.url, JSON.stringify(resource), _requestOptions)
    .pipe(catchError(this.handleError));
  }

  update(resource){
    return this.http.patch(this.url+'/'+resource.id,JSON.stringify({ isRead:true}))
    .pipe(catchError(this.handleError));
  }

  delete(id){
    return this.http.delete(this.url + '/'+id)
    .pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: Response){
    if (error.status ===404)
    return throwError(new NotFoundError(error));

    if(error.status === 400)
    return throwError(new BadInput(error.json()))
  
    return throwError(new AppError(error));
  }
}
