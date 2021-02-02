import { Component, Input, OnInit } from '@angular/core';
import { Travel } from '../models/travel.model';

@Component({
  selector: 'app-travel',
  templateUrl: './travel.component.html',
  styleUrls: ['./travel.component.css']
})
export class TravelComponent implements OnInit {
@Input()
travel:Travel;
  constructor() { }

  ngOnInit() {
  }

}
