import { accounts, single } from './../main/main-data';
//import { accounts, single } from './../main/fac-data';
import { Component, OnInit, ViewEncapsulation, ChangeDetectorRef } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { GlobalVariable } from 'src/app/common/globals';
import { AccountService } from '../../services/account.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css'],  
  encapsulation: ViewEncapsulation.None
})
export class AccountComponent implements OnInit {
  //Jumbontrom
  showTitle = false;
  //Accounts bar info
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
    domain: ['#808782', '#a6d3a0', '#b3ffb3', '#d1ffd7']
  };
  private theme = GlobalVariable.COINFAC_THEME_MODE_;
  public accounts = [];
  
  constructor(public ngxSmartModalService: NgxSmartModalService,
              private accountService: AccountService,
              private toastr: ToastrService,
              private cdref: ChangeDetectorRef) {}
  ngOnInit() {/*
    this.accountService.getAccounts().subscribe(success => {
      if (success) { 
        this.accounts = this.accountService.accounts;
        this.assemblyAccountsBar(this.accounts);
      }
    })
    */
    Object.assign(this, {single, accounts})
  }
  
  onAdd(){
    //accounts.push({ id: 1, name: 'Next', type: 'Income', comments: 'Mais um banco digital', goal:'0', series: []});
  }
  onRemove(account){
    let index = accounts.indexOf(account);
    accounts.splice(index, 1);
  }
  onSelect(event) {
    console.log(event);
  }
  assemblyAccountsBar(accounts){
    // See series area from accounts placeholder
    let comparableAccounts: { [id: string] : number; } = {};
    
    accounts.forEach(function (value) {
      let newestRegistry = value.series[value.series.length - 1].value;
      if(value.series.length > 0){
        this.accountsSum += newestRegistry;
        comparableAccounts[value.name] = value.series[value.series.length - 1].value;   
        
      } 
    }.bind(this));
    var maxValue = Math.max.apply(this,Object.values(comparableAccounts))
    var minValue = Math.min.apply(this,Object.values(comparableAccounts))
    this.maxAccountName = this.getKeyByValue(comparableAccounts,maxValue);
    this.maxAccountValue = maxValue;
    this.minAccountName = this.getKeyByValue(comparableAccounts,minValue);
    this.minAccountValue = minValue;
  }
  ngAfterViewInit() {
    const obj: Object = {
      data: this.accounts,
    };
    this.ngxSmartModalService.setModalData(obj, 'popupOne'); 
    this.cdref.detectChanges();
  }
  getKeyByValue(object, value) {
    return Object.keys(object).find(key => object[key] === value);
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

