import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AccountService extends DataService{
  private serviceUrl = `${this.baseUrl}/account`;
  
  constructor(private http: HttpClient){
    super();
  }

  getAccount(id: number): Observable<Account>{

    if(id===0){ 
      return new Observable<Account>();
    }

    const url = `${this.serviceUrl}/${id}`

    return this.http.get<Account>(url)
    .pipe(catchError(this.handleError))

  }

  createAccount(account: Account):  Observable<Account>{

    return this.http.post<Account>(this.serviceUrl, account, {headers:this.headers})
    .pipe(catchError(this.handleError));
  }

  updateAccount(account: Account):  Observable<Account>{

    const url = `${this.serviceUrl}/${account.id}`

    return this.http.put<Account>(url, account, {headers:this.headers})
    .pipe(catchError(this.handleError));
  }

  deleteAccount(id: number):  Observable<{}>{
    
    const url = `${this.serviceUrl}/${id}`
    
    return this.http.delete<Account>(url,{headers:this.headers})
    .pipe(catchError(this.handleError));
  }
}
