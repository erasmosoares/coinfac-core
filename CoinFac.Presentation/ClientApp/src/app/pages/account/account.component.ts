import { Record } from "./../../models/record";
import { Account } from "./../../models/accounts";
import { AccountComponentService } from "./account.component.service";
// import { accountsForTest } from './account-data';
import { completeAccountsForTest, single } from "./../main/main-data";
//import { accounts, single } from './../main/fac-data';
import {
  Component,
  OnInit,
  ViewEncapsulation,
  ChangeDetectorRef,
} from "@angular/core";
import { NgxSmartModalService } from "ngx-smart-modal";
import { GlobalVariable } from "src/app/common/globals";
import { AccountService } from "../../services/account.service";
import { ToastrService } from "ngx-toastr";
import { AccountModalService } from "../account-modal/account.modal.service";

@Component({
  selector: "app-account",
  templateUrl: "./account.component.html",
  styleUrls: ["./account.component.css"],
  encapsulation: ViewEncapsulation.None,
})
export class AccountComponent implements OnInit {
  /*
   * Jumbontrom
   */
  showTitle = false;

  /*
   * Accounts bar info
   */
  accountsSum = 0;
  maxAccountName;
  maxAccountValue = 0;
  minAccountName;
  minAccountValue = 0;

  /*
   * Used for charts
   */
  view: any[] = [500, 400];
  colorScheme = {
    domain: ["#808782", "#a6d3a0", "#b3ffb3", "#d1ffd7"],
  };

  //TODO: Dark mode
  public theme = GlobalVariable.COINFAC_THEME_MODE_;

  single: any[];
  accounts: any[];

  public loading = false;

  accountsCollection: Account[];

  constructor(
    public ngxSmartModalService: NgxSmartModalService,
    private accountService: AccountService,
    private toastr: ToastrService,
    private cdref: ChangeDetectorRef,
    private accountComponentService: AccountComponentService,
    private accountModalService: AccountModalService
  ) { }

  ngOnInit() {

    this.loading = true;

    this.accounts = completeAccountsForTest;

    this.loadAccounts();

    //* event fired when a new account is created
    this.accountComponentService.change.subscribe((account) => {
      this.loadAccounts();
    });
  }

  loadAccounts() {
    var observable = this.accountService.getAccounts();
    observable.subscribe({
      next: (accounts: any) => this.refreshAccount(accounts),
      error: (err) => {
        this.showMessageByCode(err.originalError.status),
          this.loading = false;
      }
    });
  }

  refreshAccount(accounts) {
    if (accounts) {
      this.accountsCollection = JSON.parse(JSON.stringify(accounts));

      Object.assign(this, { single, accounts: this.accountsCollection });

      this.assemblyAccountsBar(this.accountsCollection);

      this.loading = false;

      /*
        ? Use it for demo purpose

        Object.assign(this, {single, completeAccountsForTest});
        this.assemblyAccountsBar(this.accountsCollection); 
      */
    }
  }

  onSelect(event) {
    console.log(event);
  }

  assemblyAccountsBar(accounts) {
    //TODO Fix when has no account

    let comparableAccounts: { [id: string]: number } = {};

    try {
      accounts.forEach(
        function (value) {
          let newestRegistry = value.series[value.series.length - 1].value;
          if (value.series.length > 0) {
            this.accountsSum += newestRegistry;
            comparableAccounts[value.name] =
              value.series[value.series.length - 1].value;
          }
        }.bind(this)
      );

      var maxValue = Math.max.apply(this, Object.values(comparableAccounts));
      var minValue = Math.min.apply(this, Object.values(comparableAccounts));

      this.maxAccountName = this.getKeyByValue(comparableAccounts, maxValue);
      this.maxAccountValue = maxValue;
      this.minAccountName = this.getKeyByValue(comparableAccounts, minValue);
      this.minAccountValue = minValue;
    } catch (error) {
      //? invalid series or undefined
    }
  }

  ngAfterViewInit() {
    const obj: Object = {
      data: this.accounts,
    };

    this.ngxSmartModalService.setModalData(obj, "popupOne");
    this.cdref.detectChanges();
  }

  openAccountModal() {
    const obj: Object = {
      data: new Account(),
    };

    this.ngxSmartModalService.setModalData(obj, "popupOne");
    this.ngxSmartModalService.getModal("popupOne").open();
  }

  openRecordsModal() {
    this.ngxSmartModalService.getModal("popupFour").open();
  }

  openDeleteModal(account: Account) {
    this.ngxSmartModalService.setModalData(account, "popupTwo");
    this.ngxSmartModalService.getModal("popupTwo").open();
  }

  openEditModal(account: Account) {
    //Notify
    this.accountModalService.notifyForEdition(account);
    this.ngxSmartModalService.setModalData(account, "popupThree");
    this.ngxSmartModalService.getModal("popupThree").open();
  }

  getKeyByValue(object, value) {
    return Object.keys(object).find((key) => object[key] === value);
  }

  /*
   * Messages
   */
  showMessageByCode(code) {
    if (code == 404) {
      this.showFailure("Oh no!", "Something was not found");
    } else {
      this.showFailure("Oh no!", "Internal Error");
    }
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
