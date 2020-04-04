import { Component, OnInit } from '@angular/core';
import { multi } from './main-data';
import { completeAccountsForTest, single } from './../main/main-data';
import { AuthService } from '../../services/auth.service';
import { UserService } from '../../services/user.service';
import { User } from 'src/app/models/user';
import { ToastrService } from 'ngx-toastr';
//import { accounts, single, } from './../main/fac-data';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  
   /*
   * Used for charts
   */
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

     
    /*
     * Auth0 subscriber
     */
    this.auth.userProfile$.subscribe(loggedUser =>  this.configureUser(loggedUser));

    /*
    TODO Will be removed
   */
    Object.assign(this, { single, multi, accounts: completeAccountsForTest })

  }

  configureUser(loggedUser){
  
    if (loggedUser) {

      var profile = JSON.parse(JSON.stringify(loggedUser));

      var observable = this.userService.getUserByEmail(profile.email);
      observable.subscribe({
        next:(user:User) => this.showInfo("Hey, how are you doing?", user.name),
        error: err => {
          if(err.originalError.status == 404){
            this.createNewUser(profile);
          }
        }
      })
    }
  }

  createNewUser(user){

    var observable = this.userService.createUser(user);
    observable.subscribe({
      next:(user:User) => this.showSuccess("Wellcome "+ user.name, "New user!"),
      error: err => this.showMessageByCode(err.originalError.status)
    })
  }

  /*
  * Messages
  */

  showMessageByCode(code){
    if (code == 404){
      this.showFailure("Oh no!", "Something was not found");
    }
    else{
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
