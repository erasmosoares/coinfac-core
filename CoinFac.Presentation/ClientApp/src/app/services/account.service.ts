import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { Http } from '@angular/http';
import { map, filter, catchError, mergeMap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService extends DataService{
  public accounts;
  /*
  constructor(http: Http) {
    super('https://localhost:44372/api/accounts', http);
  }

  getAccounts() : Observable<boolean> {
    return this.http.get('https://localhost:44372/api/accounts')
      .pipe(
        map((response: Response) => {
          this.accounts = response.json();
          return true;
        }));
  }*/
}
