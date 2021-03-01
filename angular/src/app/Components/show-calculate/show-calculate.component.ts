import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CalculateResulte } from 'src/app/models/calculateResult';
import { WebApiService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-show-calculate',
  templateUrl: './show-calculate.component.html',
  styleUrls: ['./show-calculate.component.css']
})
export class ShowCalculateComponent implements OnInit {
  constructor(private webapi: WebApiService, private route: ActivatedRoute, private router: Router) { }
  public name:string;
  public contractList:Array<CalculateResulte>;
  public date:Date;
  public price:number=0;
  public fullPrice:number=0;
    ngOnInit() {
       this.webapi.CalculateThePayment().subscribe(x=>{
         console.log(x);
         this.contractList = x;
         //this.price=this.contractList.reduce((sum, current) => sum + current.price, 0);
        // this.contractList.forEach(a => 
        // this.fullPrice+= a.TravelToCon.reduce((sum,current)=> sum =current.price,0));
         
       })
    }
  }
  