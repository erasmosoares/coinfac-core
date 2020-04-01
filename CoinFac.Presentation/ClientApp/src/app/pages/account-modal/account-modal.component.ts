import { Component, OnInit } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { FormBuilder, Validators, FormArray, FormControl, FormGroup } from '@angular/forms';
import { UsernameValidators } from './username.validators';
import { AccountService } from 'src/app/services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-account-modal',
  templateUrl: './account-modal.component.html',
  styleUrls: ['./account-modal.component.css'],
})
export class AccountModalComponent implements OnInit {
  form = new FormGroup({
    account: new FormGroup({
        name: new FormControl('',[
          Validators.required,
          Validators.minLength(3),
          UsernameValidators.cannotContainSpace],UsernameValidators.shouldBeUnique),
          goal: new FormControl('',Validators.required),
          type: new FormControl('',Validators.required),
          comments: new FormControl('',Validators.required),
      })
    });
    goalInput = "0.00";
    constructor(public ngxSmartModalService: NgxSmartModalService,
                private accountService: AccountService,
                private toastr: ToastrService) { }
  ngOnInit() {
    let data = this.ngxSmartModalService;
    console.log(data);
  }
  get name(){
    return this.form.get('account.name');
  }
  submit(){
    let resource = JSON.stringify(this.form.value);
    alert(resource);
    /*
    this.accountService.create(this.form.value)
            .subscribe(
                data => this.showSuccess("success!", data),
                error => this.showFailure("couldn't post because", error)
            );   */
  }
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
