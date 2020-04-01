import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { catchError} from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})
export class UserService extends DataService{
  private userUrl = 'https://localhost:44372/api/user';
  constructor(private http: HttpClient){
    super();
  }
  getUser(id: number): Observable<User>{
    if(id===0){ 
      return new Observable<User>();
    }
    const url = `${this.userUrl}/${id}`
    return this.http.get<User>(url)
    .pipe(catchError(this.handleError))
  }
  createUser(user: User):  Observable<User>{
    const headers = new HttpHeaders({'Content-Type': 'application/json'})
    return this.http.post<User>(this.userUrl, user, {headers:headers})
    .pipe(catchError(this.handleError));
  }
  updateUser(user: User):  Observable<User>{
    const headers = new HttpHeaders({'Content-Type': 'application/json'})
    const url = `${this.userUrl}/${user.id}`
    return this.http.put<User>(url, user, {headers:headers})
    .pipe(catchError(this.handleError));
  }
  deleteUser(id: number):  Observable<{}>{
    const headers = new HttpHeaders({'Content-Type': 'application/json'})
    const url = `${this.userUrl}/${id}`
    return this.http.delete<User>(url,{headers:headers})
    .pipe(catchError(this.handleError));
  }
}





