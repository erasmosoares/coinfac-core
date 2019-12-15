import { Component, OnInit } from '@angular/core';
import { GlobalVariable } from 'src/app/common/globals';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  private theme = GlobalVariable.COINFAC_THEME_MODE_;

  constructor() { }

  ngOnInit() {
    console.log(this.theme);
  }

}
