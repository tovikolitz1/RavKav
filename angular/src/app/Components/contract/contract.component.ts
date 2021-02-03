import { Component, OnInit,Input } from '@angular/core';
import { CalculateResulte } from 'src/app/models/calculateResult';
import { Travel } from 'src/app/models/travel.model';

@Component({
  selector: 'app-contract',
  templateUrl: './contract.component.html',
  styleUrls: ['./contract.component.css']
})
export class ContractComponent implements OnInit {
 
  constructor() { }
 @Input() contract:CalculateResulte;
  ngOnInit() {
  
  }

}
