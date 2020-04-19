import { Injectable, Output, EventEmitter } from '@angular/core'
import { CapitalAccount } from 'src/app/models/accounts';

@Injectable()
export class AccountModalService {

  @Output() editForm: EventEmitter<CapitalAccount> = new EventEmitter();

  notifyForEdition(value:CapitalAccount) {
    
    this.editForm.emit(value);
  }

}