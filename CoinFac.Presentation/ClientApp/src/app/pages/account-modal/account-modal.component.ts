import { Component, OnInit } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { FormBuilder, Validators, FormArray, FormControl, FormGroup } from '@angular/forms';
import { UsernameValidators } from './username.validators';


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

    form2 = new FormGroup({
      record: new FormGroup({
            value: new FormControl('',[Validators.required]),
            date: new FormControl('',Validators.required),
            notes: new FormControl(),
        })
      });

    goalInput = "0.00";

   constructor(public ngxSmartModalService: NgxSmartModalService) { 
   }

  ngOnInit() {
    let data = this.ngxSmartModalService;
    console.log(data);
  }

  get name(){
    return this.form.get('account.name');
  }

  login(){
    this.form.setErrors({
      invalidLogin:true
    });
  }
  
}
