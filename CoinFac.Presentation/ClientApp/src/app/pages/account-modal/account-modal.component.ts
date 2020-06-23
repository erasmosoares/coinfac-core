import { RecordsService } from './../../services/records.service';
import { Account } from "./../../models/accounts";
import {
  Component,
  OnInit,
  Output,
  EventEmitter,
  AfterViewInit,
} from "@angular/core";
import { NgxSmartModalService } from "ngx-smart-modal";
import { FormBuilder, Validators, FormArray, FormGroup } from "@angular/forms";
import { UsernameValidators } from "./username.validators";
import { AccountService } from "src/app/services/account.service";
import { ToastrService } from "ngx-toastr";
import { AccountComponentService } from "../account/account.component.service";
import { AccountModalService } from "./account.modal.service";
import { completeAccountsForTest } from "./../main/main-data";
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/user';

@Component({
  selector: "app-account-modal",
  templateUrl: "./account-modal.component.html",
  styleUrls: ["./account-modal.component.css"],
})
export class AccountModalComponent implements OnInit {

  //? Form Groups
  accountForm: FormGroup;
  recordForm: FormGroup;
  amountForm: FormGroup;

  //? Basic account objects
  account: Account;
  accounts: any[];
  accountsNames: string[];

  //? Initialize a goal for account
  goalInput = "0.00"; //TODO Initialize ngOnInit()

  //? Flag used fo records submission
  submitted = false; //TODO Initialize ngOnInit()

  public loading = false;

  @Output() refreshAccounts: EventEmitter<Account> = new EventEmitter<Account>();

  constructor(
    public ngxSmartModalService: NgxSmartModalService,
    private accountService: AccountService,
    private recordService: RecordsService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder,
    private accountComponentService: AccountComponentService,
    private accountModalService: AccountModalService
  ) { }

  ngOnInit() {

    //this.profileStorage = JSON.parse(sessionStorage.getItem('profile'));

    //? Prperties Initialization
    this.account = new Account();
    this.accountsNames = [];
    this.accounts = completeAccountsForTest;

    //? Create accounts - Forms Initialization
    this.accountForm = this.formBuilder.group({
      name: [
        "",
        [
          Validators.required,
          Validators.minLength(3),
        /*UsernameValidators.cannotContainSpace ,
          UsernameValidators.shouldBeUnique */,
        ],
      ], //TODO There is a bug in this validator
      goal: ["", Validators.required],
      accountType: ["", Validators.required],
      comments: [""],
    });

    //? Create records - Forms Initialization
    this.recordForm = this.formBuilder.group({
      records: new FormArray([]),
    });

    this.amountForm = this.formBuilder.group({
      value: ["", Validators.required],
    });

    //? Subscribers
    this.accountModalService.editForm.subscribe((account) => {
      this.loadEditForm(account);
    });

    //? Triggers on init (onLoadUser)
    this.onChangeRecords();

  }

  /*
   * Create Records
   */
  // convenience getters for easy access to form fields
  get recordFormsControlFields() {
    return this.recordForm.controls;
  }
  get recordFormsAmountFields() {
    return this.recordFormsControlFields.records as FormArray;
  }

  updateAccountsNames(accounts: any[]) {
    accounts.forEach((account) => {
      this.accountsNames.push(account.name);
    });
  }

  onChangeRecords() {
    this.loading = true;
    var observable = this.accountService.getAccounts();
    observable.subscribe({
      next: (accounts: any) => {
        this.updateAccountsNames(accounts);

        const numberOfRecords = accounts.length || 0;

        if (this.recordFormsAmountFields.length < numberOfRecords) {
          for (let i = this.recordFormsAmountFields.length; i < numberOfRecords; i++) {
            this.recordFormsAmountFields.push(
              this.formBuilder.group({
                account: [this.accountsNames[i]],
                amount: ["", Validators.required],
              })
            );
          }
        } else {
          for (let i = this.recordFormsAmountFields.length; i >= numberOfRecords; i--) {
            this.recordFormsAmountFields.removeAt(i);
          }
        }
        this.loading = false;
      },
      error: (err) => {
        this.loading = false;
        alert("Error: " + err.originalError.status);
      },
    });
  }

  onSubmit() {
    this.submitted = true;

    if (this.recordForm.invalid) {
      return;
    }

    this.saveAccountRecords();
    this.ngxSmartModalService.getModal("popupFour").removeData(); //TODO rename popup create
    this.ngxSmartModalService.getModal("popupFour").close();
  }

  saveAccountRecords() {
    this.loading = true;
    alert("SUCCESS!! :-)\n\n" + JSON.stringify(this.recordForm.value, null, 4)); //Data to post
    this.loading = false;
    //this.recordService.createRecords()

    /*
    "records":[
      {
        "account":"Neon",
        "name":"15.000"
      },
      {
        "account":"Desjardins",
        "name":"15.000"
      }
    ]
    */
  }

  onClear() {
    this.submitted = false;
    this.recordFormsAmountFields.reset();
  }

  /*
   * Save Account
   */
  saveAccount() {
    var pid = sessionStorage.getItem("pid");

    if (!pid) {
      this.showFailure("couldn't indentify user", "Please renew your session.");
    } else {
      this.loading = true;

      let jsonObj = JSON.stringify(this.accountForm.value);
      let obj: Account = JSON.parse(jsonObj);

      this.account.name = obj.name;
      this.account.goal = obj.goal;
      this.account.accountType = obj.accountType;
      this.account.comments = obj.comments;
      this.account.records = [];
      this.account.userId = pid;

      this.accountService.createAccount(this.account).subscribe(
        (data) => {
          this.loading = false;
          this.notify(data, "Account created");
        },
        (error) => {
          this.loading = false;
          console.log(error),
            this.showFailure("couldn't post because", error.originalError);
        }
      );

      this.ngxSmartModalService.getModal("popupOne").removeData(); //TODO rename popup create
      this.ngxSmartModalService.getModal("popupOne").close();
    }
  }

  /*
 * Delete Account
 */
  deleteAccount() {
    var account: Account = this.ngxSmartModalService
      .getModal("popupTwo")
      .getData();
    this.loading = true;
    this.accountService.deleteAccount(+account.id).subscribe(
      (data) => {
        this.loading = false;
        this.showInfo("success!", "Account " + data + " deleted"),
          this.accountComponentService.notify(account);
      },
      (error) => {
        this.loading = false;
        this.showFailure("Could not delete this account", "Server error."),
          this.accountComponentService.notify(account);
      }
    );

    this.ngxSmartModalService.getModal("popupTwo").removeData(); //TODO rename popup delete
    this.ngxSmartModalService.getModal("popupTwo").close();
  }

  /*
  * Edit Account
  */
  editAccount() {
    var account: Account = this.ngxSmartModalService
      .getModal("popupThree")
      .getData();

    let jsonObj = JSON.stringify(this.accountForm.value);
    let stringify = JSON.parse(jsonObj);

    account.name = stringify.name;
    account.accountType = stringify.accountType;
    account.goal = stringify.goal;
    account.comments = stringify.comments;
    this.loading = true;
    this.accountService.updateAccount(account).subscribe(
      (data) => {
        this.loading = false;
        this.notify(data, "Account updated");
      },
      (error) => {
        this.loading = false;
        console.log(error),
          this.showFailure("couldn't post because", error.originalError);
      }
    );

    this.ngxSmartModalService.getModal("popupThree").removeData(); //TODO rename popup update
    this.ngxSmartModalService.getModal("popupThree").close();
  }

  loadEditForm(account: Account) {
    //? popupThree is the editForm, if its open, initialize the form with current data
    if (account !== undefined) {
      this.accountForm.patchValue({
        name: account.name,
        goal: account.goal,
        accountType: this.loadAccountType(account.accountType),
        comments: account.comments,
      });
    }
  }

  loadAccountType(type) {
    switch (type) {
      case 0: {
        return "Income";
      }
      case 1: {
        return "Expense";
      }
      case 2: {
        return "IncomeAndExpense";
      }
      default: {
        return "IncomeAndExpense";
      }
    }
  }
  /*
   * Publisher
   */
  notify(value, text) {
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
