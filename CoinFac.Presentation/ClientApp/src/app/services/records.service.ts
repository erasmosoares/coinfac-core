import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Record } from '../models/record';

@Injectable({
  providedIn: 'root'
})
export class RecordsService extends DataService {
  private serviceUrl = `${this.baseUrl}/records`;

  constructor(private http: HttpClient) {
    super();
  }

  createRecords(record: Record): Observable<Record> {
    return this.http.post<Record>(this.serviceUrl, record, { headers: this.configureHeader() })
      .pipe(catchError(this.handleError));
  }
}
