import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError} from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})

export class UserService extends DataService{

  private serviceUrl = `${this.baseUrl}/user`;
  
  constructor(private http: HttpClient){
    super();
  }

  getUser(id: number): Observable<User>{

    if(id===0){ 
      return new Observable<User>();
    }

    const url = `${this.serviceUrl}/${id}`

    return this.http.get<User>(url)
    .pipe(catchError(this.handleError))

  }

  createUser(user: User):  Observable<User>{

    return this.http.post<User>(this.serviceUrl, user, {headers:this.headers})
    .pipe(catchError(this.handleError));
  }

  updateUser(user: User):  Observable<User>{

    const url = `${this.serviceUrl}/${user.id}`

    return this.http.put<User>(url, user, {headers:this.headers})
    .pipe(catchError(this.handleError));
  }

  deleteUser(id: number):  Observable<{}>{
    
    const url = `${this.serviceUrl}/${id}`
    
    return this.http.delete<User>(url,{headers:this.headers})
    .pipe(catchError(this.handleError));
  }

  getUserByEmail(email: string): Observable<User>{

    const url = `${this.serviceUrl}/email/${email}`
    
    return this.http.get<User>(url)
    .pipe(catchError(this.handleError))
  }
}





