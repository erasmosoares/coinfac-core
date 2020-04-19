import { CapitalAccount } from './../../models/accounts';
import { Component, OnInit, Output, EventEmitter, AfterViewInit } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { UsernameValidators } from './username.validators';
import { AccountService } from 'src/app/services/account.service';
import { ToastrService } from 'ngx-toastr';
import { AccountComponentService } from '../account/account.component.service';
import { AccountModalService } from './account.modal.service';

@Component({
  selector: 'app-account-modal',
  templateUrl: './account-modal.component.html',
  styleUrls: ['./account-modal.component.css'],
})
export class AccountModalComponent implements OnInit {

  accountForm: FormGroup;
  capitalAccount = new CapitalAccount();
  dataForEdition:CapitalAccount;
  goalInput = "0.00";

  @Output() refreshAccounts: EventEmitter<CapitalAccount> = new EventEmitter<CapitalAccount>();

  constructor(public ngxSmartModalService: NgxSmartModalService,
                private accountService: AccountService,
                private toastr: ToastrService,
                private fb: FormBuilder,
                private accountComponentService: AccountComponentService,
                private accountModalService: AccountModalService) { }
  
  ngOnInit() {

    this.accountForm = this.fb.group({
      name: ['', [Validators.required, 
                  Validators.minLength(3),
                  UsernameValidators.cannotContainSpace/* ,
                  UsernameValidators.shouldBeUnique */]], //TODO There is a bug in this validator
      goal: ['', Validators.required],
      type: ['', Validators.required],
      comments: ['']
    });    

    this.accountModalService.editForm.subscribe(account => {
      this.loadEditForm(account);
    });
  }

  loadEditForm(account:CapitalAccount){
    alert('loadForm '+account.name);

    //TODO Initialize Forms
    //? popupThree is the editForm, if its open, initialize the form with current data
    /*
    alert('after ngOnInit');
    var editModal = this.ngxSmartModalService. getModalData('popupThree');
    alert('editModal '+editModal);
    if(editModal !== undefined){
      this.dataForEdition = this.ngxSmartModalService.getModal('popupThree').getData();
      alert('dataForEdition '+this.dataForEdition);
      alert('dataForEdition '+this.dataForEdition.name);

      this.accountForm.patchValue({
        name: 'qwe',
        goal: 'qweqwe',
        type: '0',
        comments:'adasd'
      });
    }
    */
  }

  saveAccount(){
    
    var pid = sessionStorage.getItem('pid');
    
    if(!pid){
      this.showFailure("couldn't indentify user", "Please renew your session.")
    }
    else{
         
      let jsonObj = JSON.stringify(this.accountForm.value);
      let stringify = JSON.parse(jsonObj);

      this.capitalAccount = stringify;
      this.capitalAccount.records = [];
      this.capitalAccount.userId = pid; 

      //this.notify(this.capitalAccount);
      this.ngxSmartModalService.getModal('popupOne').close();

      this.accountService.createAccount(this.capitalAccount)
      .subscribe(
          data => {this.notify(data,"Account created")}, 
          error => this.showFailure("couldn't post because", error)
      );  

      this.ngxSmartModalService.getModal('popupOne').removeData();

    }
  }

  deleteAccount(){
    
    var account:CapitalAccount = this.ngxSmartModalService.getModal('popupTwo').getData();
    
    this.accountService.deleteAccount(+account.id) 
      .subscribe(
          data => {
            this.showInfo("success!", "Account "+data+" deleted"), 
            this.accountComponentService.notify(account),
            this.ngxSmartModalService.getModal('popupTwo').close();
          }, 
          error => {
            this.showFailure("Could not delete this account","Server error."),
            this.accountComponentService.notify(account),
            this.ngxSmartModalService.getModal('popupTwo').close()}
      ); 

      this.ngxSmartModalService.getModal('popupTwo').removeData();
  }

  editAccount(){
    var pid = sessionStorage.getItem('pid');
    
    if(!pid){
      this.showFailure("couldn't indentify user", "Please renew your session.")
    }
    else{
         
      let jsonObj = JSON.stringify(this.accountForm.value);
      let stringify = JSON.parse(jsonObj);

      this.capitalAccount = stringify;
      this.capitalAccount.records = [];
      this.capitalAccount.userId = pid; 

      //this.notify(this.capitalAccount);
      //this.ngxSmartModalService.getModal('popupOne').close();

      this.accountService.updateAccount(this.capitalAccount)
      .subscribe(
          data => {this.notify(data,"Account updated")}, 
          error => this.showFailure("couldn't post because", error)
      );  

      this.ngxSmartModalService.getModal('popupThree').removeData();

    }
  }

  //TODO Calling twice
  notify(value, text){
    this.showSuccess("success!", text);
    this.accountComponentService.notify(value);  
  }

  /*
  * Messages
  */
  showSuccess(title, message) {
    this.toastr.success(message, title, {
      timeOut: 3000,
    });
  }
  showFailure(title, message) {
    this.toastr.error(title, message, {
      timeOut: 3000,
    });
  }
  showInfo(title, message) {
    this.toastr.info(title, message, {
      timeOut: 3000,
    });
  }
  
}
