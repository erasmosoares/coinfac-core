import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CapitalAccount } from '../models/accounts';

@Injectable({
  providedIn: 'root'
})
export class AccountService extends DataService{
  private serviceUrl = `${this.baseUrl}/accounts`;
  
  constructor(private http: HttpClient){
    super();
  }

  getAccounts(): Observable<CapitalAccount[]>{

    const url = `${this.serviceUrl}`

    return this.http.get<CapitalAccount[]>(url)
    .pipe(catchError(this.handleError))

  }

  getAccount(id: number): Observable<CapitalAccount>{

    if(id===0){ 
      return new Observable<CapitalAccount>();
    }

    const url = `${this.serviceUrl}/${id}`

    return this.http.get<CapitalAccount>(url)
    .pipe(catchError(this.handleError))

  }

  createAccount(account: CapitalAccount):  Observable<CapitalAccount>{
    return this.http.post<CapitalAccount>(this.serviceUrl, account, {headers:this.headers})
    .pipe(catchError(this.handleError));
  }

  //TODO getAccountByNameAndUserID - eg. https://localhost:44372/api/accounts/fullaccount?accountName=NuBank&accountUserId=73
  /*getAccountByNameAndUserID(accountName:string, accountUserId: string): Observable<CapitalAccount>{

  }*/

  updateAccount(account: CapitalAccount):  Observable<CapitalAccount>{
    alert(account.id);
    const url = `${this.serviceUrl}/${account.id}`

    return this.http.put<CapitalAccount>(url, account, {headers:this.headers})
    .pipe(catchError(this.handleError));
  }

  deleteAccount(id: number):  Observable<{}>{
    
    const url = `${this.serviceUrl}/${id}`
    
    return this.http.delete<CapitalAccount>(url,{headers:this.headers})
    .pipe(catchError(this.handleError));
  }
}
