import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { Http } from '@angular/http';
@Injectable({
    providedIn: 'root'
})
export class UserService extends DataService {
  constructor(http: Http) {
    super('https://localhost:44372/api/user/create', http);
  }
}
