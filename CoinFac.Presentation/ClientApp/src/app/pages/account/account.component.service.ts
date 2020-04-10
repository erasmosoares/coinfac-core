import { Injectable, Output, EventEmitter } from '@angular/core'
import { CapitalAccount } from 'src/app/models/accounts';

@Injectable()
export class AccountComponentService {

  @Output() change: EventEmitter<CapitalAccount> = new EventEmitter();

  notify(value:CapitalAccount) {
    
    this.change.emit(value);
  }

}