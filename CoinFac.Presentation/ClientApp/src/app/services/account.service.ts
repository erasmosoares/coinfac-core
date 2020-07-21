import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Account } from '../models/accounts';

@Injectable({
  providedIn: 'root'
})
export class AccountService extends DataService {
  private serviceUrl = `${this.baseUrl}/accounts`;

  constructor(private http: HttpClient) {
    super();
  }

  getAccounts(): Observable<Account[]> {

    const url = `${this.serviceUrl}`

    return this.http.get<Account[]>(url, { headers: this.configureHeader() })
      .pipe(catchError(this.handleError))

  }

  getFullAccounts(): Observable<Account[]> {

    const url = `${this.serviceUrl}/full`

    return this.http.get<Account[]>(url, { headers: this.configureHeader() })
      .pipe(catchError(this.handleError))

  }

  getAccount(id: number): Observable<Account> {

    if (id === 0) {
      return new Observable<Account>();
    }

    const url = `${this.serviceUrl}/${id}`

    return this.http.get<Account>(url, { headers: this.configureHeader() })
      .pipe(catchError(this.handleError))

  }

  createAccount(account: Account): Observable<Account> {

    return this.http.post<Account>(this.serviceUrl, account, { headers: this.configureHeader() })
      .pipe(catchError(this.handleError));
  }

  updateAccount(account: Account): Observable<Account> {

    const url = `${this.serviceUrl}/${account.id}`

    return this.http.put<Account>(url, account, { headers: this.configureHeader() })
      .pipe(catchError(this.handleError));
  }

  deleteAccount(id: number): Observable<{}> {

    const url = `${this.serviceUrl}/${id}`

    return this.http.delete<Account>(url, { headers: this.configureHeader() })
      .pipe(catchError(this.handleError));
  }
}
