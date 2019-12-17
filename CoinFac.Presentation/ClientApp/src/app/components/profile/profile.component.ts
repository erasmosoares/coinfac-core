import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})

export class ProfileComponent implements OnInit {

  profileStorage: any;
  profileConst: any;

  constructor(public auth: AuthService) {
    this.profileStorage = JSON.parse(sessionStorage.getItem('profile'))
  }

  ngOnInit() {

    this.auth.userProfile$.subscribe(user => this.profileStorage = user);
    alert("1"+JSON.stringify(this.profileStorage));

    this.profileConst = JSON.parse(JSON.stringify(this.profileStorage));
    alert("2" +this.profileConst.given_name);

    sessionStorage.setItem('profile', JSON.stringify(this.profileStorage))
    alert("3" +this.profileStorage.given_name);
  }

}

//{
//  "given_name": "Erasmo",
//    "family_name": "Soares",
//      "nickname": "erasmosaraujo",
//        "name": "Erasmo Soares",
//          "picture": "https://lh3.googleusercontent.com/a-/AAuE7mBRmLLtZIHh90Ps_4QfJjoRvGUnPqRFDSn8mSif_fk",
//            "locale": "pt-BR",
//              "updated_at": "2019-12-17T01:32:04.544Z",
//                "email": "erasmosaraujo@gmail.com",
//                  "email_verified": true,
//                    "sub": "google-oauth2|114036336240545963278"
//}
