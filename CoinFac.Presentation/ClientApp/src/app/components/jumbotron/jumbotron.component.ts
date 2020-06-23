import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-jumbotron',
  templateUrl: './jumbotron.component.html',
  styleUrls: ['./jumbotron.component.css']
})
export class JumbotronComponent implements OnInit {

  @Input('title') title: string;
  @Input('subtitle') subtitle: string;

  public picUrl: string;

  constructor(public auth: AuthService) { }

  ngOnInit() {
    this.auth.userProfile$.subscribe(user => {
      if (user != null || user != undefined) {
        this.picUrl = user.pictureUrl;
      }
    });
  }

}
