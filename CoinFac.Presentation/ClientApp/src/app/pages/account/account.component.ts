import { accounts, single } from './../main/main-data';
//import { accounts, single } from './../main/fac-data';
import { Component, OnInit, ViewEncapsulation, ChangeDetectorRef } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { GlobalVariable } from 'src/app/common/globals';

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

  //Services
  single: any[];
  accounts: any[];

  //Charts
  view: any[] = [500, 400];
  colorScheme = {
    domain: ['#808782', '#a6d3a0', '#b3ffb3', '#d1ffd7']
  };

  private theme = GlobalVariable.COINFAC_THEME_MODE_;
  
  constructor(public ngxSmartModalService: NgxSmartModalService, private cdref: ChangeDetectorRef) {

    Object.assign(this, {single, accounts}) 
   }

  ngOnInit() {
  
    this.assemblyAccountsBar(accounts);

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
      data: accounts,
    };

    this.ngxSmartModalService.setModalData(obj, 'popupOne'); 
    this.cdref.detectChanges();
  }

  getKeyByValue(object, value) {
    return Object.keys(object).find(key => object[key] === value);
  }
}
