import { CapitalAccount } from './../../models/accounts';
import { Component, OnInit } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { UsernameValidators } from './username.validators';
import { AccountService } from 'src/app/services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-account-modal',
  templateUrl: './account-modal.component.html',
  styleUrls: ['./account-modal.component.css'],
})
export class AccountModalComponent implements OnInit {

  customerForm: FormGroup;
  customer = new CapitalAccount();

  goalInput = "0.00";

  constructor(public ngxSmartModalService: NgxSmartModalService,
                private accountService: AccountService,
                private toastr: ToastrService,
                private fb: FormBuilder) { }
  
  ngOnInit() {

    let data = this.ngxSmartModalService;

    console.log('ngxdata: '+data);

    this.customerForm = this.fb.group({
      name: ['', [Validators.required, 
                  Validators.minLength(3),
                  UsernameValidators.cannotContainSpace,
                  UsernameValidators.shouldBeUnique]],
      goal: ['', Validators.required],
      type: ['', Validators.required],
      comments: ['']
    });

  }

  submit(){

    //TODO This work    
    let jsonObj = JSON.stringify(this.customerForm.value);
    let stringify = JSON.parse(jsonObj);

    this.customer = stringify;
    this.customer.records = [];
    this.customer.userId = "73";

    console.log(this.customer); //TODO: Associate user
    
    this.accountService.createAccount(this.customer)
    .subscribe(
        data => this.showSuccess("success!", "Account created"), //TODO: Close dialog
        error => this.showFailure("couldn't post because", error)
    );  
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
