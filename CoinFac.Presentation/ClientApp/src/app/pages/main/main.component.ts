import { Component, OnInit } from '@angular/core';
import { multi } from './main-data';
import { accounts, single } from './../main/main-data';
import { AuthService } from '../../services/auth.service';
//import { accounts, single, } from './../main/fac-data';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  profileStorage: any;
  single: any[];
  multi: any[];
  accounts: any[];
  view: any[] = [400, 400];

  colorScheme = {
    domain: ['#808782', '#a6d3a0', '#b3ffb3', '#d1ffd7']
  };

  constructor(public auth: AuthService) {

    this.configureUser();

    Object.assign(this, { single, multi, accounts })
   }

  ngOnInit() {
    
    alert("main" + JSON.stringify(this.profileStorage));
  }

  onSelect(event) {
    console.log(event);
  }

  configureUser(){
    this.auth.userProfile$.subscribe(user => this.profileStorage = user);
    this.profileStorage = JSON.parse(sessionStorage.getItem('profile'))
  }
}
