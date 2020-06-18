import { Injectable, Output, EventEmitter } from '@angular/core'
import { Account } from 'src/app/models/accounts';

@Injectable()
export class AccountModalService {

  @Output() editForm: EventEmitter<Account> = new EventEmitter();

  notifyForEdition(value: Account) {

    this.editForm.emit(value);
  }

}