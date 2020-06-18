import { Injectable, Output, EventEmitter } from '@angular/core'
import { Account } from 'src/app/models/accounts';

@Injectable()
export class AccountComponentService {

  @Output() change: EventEmitter<Account> = new EventEmitter();

  notify(value: Account) {

    this.change.emit(value);
  }

}