import { Component, Input, OnInit } from '@angular/core';
import { Travel } from '../../models/travel.model';

@Component({
  selector: 'app-travel',
  templateUrl: './travel.component.html',
  styleUrls: ['./travel.component.css']//,'../globalStyle.css']
})
export class TravelComponent implements OnInit {
@Input() travel:Travel;
@Input() type:boolean;
  constructor() { }
  ngOnInit() {
    if(this.type == true)
    document.getElementById('singleTravelPrice').classList.remove('d-none');
  }

}
