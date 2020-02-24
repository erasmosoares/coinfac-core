import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { Http } from '@angular/http';
import { map, filter, catchError, mergeMap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  constructor(private http: Http) {}
  public accounts;
  getAccounts() : Observable<boolean> {
    return this.http.get('https://localhost:44372/api/accounts')
      .pipe(
        map((response: Response) => {
          this.accounts = response.json();
          return true;
        }));
  }
}
