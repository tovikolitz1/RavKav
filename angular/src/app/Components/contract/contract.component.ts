import { Component, OnInit } from '@angular/core';
import { Travel } from 'src/app/models/travel.model';

@Component({
  selector: 'app-contract',
  templateUrl: './contract.component.html',
  styleUrls: ['./contract.component.css']
})
export class ContractComponent implements OnInit {
  
  constructor() { }
@Input() contract:Travel;
  ngOnInit() {
  }

}
