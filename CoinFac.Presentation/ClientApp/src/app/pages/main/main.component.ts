import { Component, OnInit } from '@angular/core';
import { multi } from './main-data';
import { accounts, single } from './../main/main-data';
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
    Object.assign(this, { single, multi, accounts })

  }

   /*
    ? Just for clarification on how to used it
   */
  getUser(id: number): void {
    this.userService.getUser(id)
    .subscribe({
      next:(user:User) => this.displayUser(user),
      error: err => alert(err) 
    })
  }

  displayUser(user: User): void {
    alert("User -> "+JSON.stringify(user));
  }

  configureUser(loggedUser){
  
    if (loggedUser) {

      var profile = JSON.parse(JSON.stringify(loggedUser));

      var observable = this.userService.getUserByEmail(profile.email);
      observable.subscribe(user => {
        this.showInfo("Hey, how are you doing?", user.name);
      }, err => {
        if(err.originalError.status == 404){
          this.createNewUser(profile);
        }
      });
    }
  }

  createNewUser(user){

    var observable = this.userService.createUser(user);
    observable.subscribe(user=> {
      this.showSuccess("Wellcome "+ user.name, "New user!");
    }, err =>{
      this.showMessageByCode(err.originalError.status);
    })
  }

  /*
  * Messages
  */

  showMessageByCode(code){
    if (code == 404){
      this.showInfo("Oh no!", "Something was not found");
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
