import { Component, OnInit, Input } from '@angular/core';
import { WebApiService } from 'src/app/services/web-api.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CalculateResulte } from 'src/app/models/calculateResult';


@Component({
  selector: 'app-show-travels',
  templateUrl: './show-travels.component.html',
  styleUrls: ['./show-travels.component.css']
})
export class ShowTravelsComponent implements OnInit {

  constructor(private webapi: WebApiService, private route: ActivatedRoute, private router: Router) { }
public name:string;
public contractList:Array<CalculateResulte>;
public date:Date;
  ngOnInit() {
    //this.date=new Date(Date.now()).setMonth(-1);
   
     this.webapi.CalculateThePayment().subscribe(x=>{
       debugger
       this.contractList = x;
     })
  }
}
