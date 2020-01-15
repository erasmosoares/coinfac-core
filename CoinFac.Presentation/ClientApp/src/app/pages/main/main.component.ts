import { Component, OnInit } from '@angular/core';
import { multi } from './main-data';
import { accounts, single } from './../main/main-data';
import { AuthService } from '../../services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../services/UserService';
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

  constructor(public auth: AuthService,
              private userService: UserService,
              private toastr: ToastrService) {

    this.auth.userProfile$.subscribe(user => this.configureUser(user));

    Object.assign(this, { single, multi, accounts })
   }

  ngOnInit() {
    
    //alert("main" + JSON.stringify(this.profileStorage));
  }

  onSelect(event) {
    console.log(event);
  }

  configureUser(user){
    
    //this.profileStorage = JSON.parse(user)
    var result = this.userService.create(JSON.parse(user))
    result.subscribe(userObs => {
      this.showSuccess("Success", "The user was sucessfully updated.")
    }, err => { 
      if (err.status == 404)
        this.showInfo("Woops", "User not found");
        else
        this.showFailure("dammit", "User not found");
    });
  }

  showSuccess(title, message) {
    this.toastr.success(title, message, {
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
