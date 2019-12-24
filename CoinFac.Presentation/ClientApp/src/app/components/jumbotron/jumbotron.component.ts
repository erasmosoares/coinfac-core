import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-jumbotron',
  templateUrl: './jumbotron.component.html',
  styleUrls: ['./jumbotron.component.css']
})
export class JumbotronComponent implements OnInit {

  @Input('title') title: string;
  @Input('subtitle') subtitle: string;

  constructor() { }

  ngOnInit() {
  }

}
