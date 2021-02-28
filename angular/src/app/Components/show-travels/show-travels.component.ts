import { Component, OnInit, Input } from '@angular/core';
import { WebApiService } from 'src/app/services/web-api.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Travel } from 'src/app/models/travel.model';


@Component({
  selector: 'app-show-travels',
  templateUrl: './show-travels.component.html',
  styleUrls: ['./show-travels.component.css']//,'../globalStyle.css']
})
export class ShowTravelsComponent implements OnInit {

  constructor(private webapi: WebApiService, private route: ActivatedRoute, private router: Router) { }
public name:string;
public travelList:Array<Travel>;
public date:Date;
public type:boolean=true;
public sum:number=0;
  ngOnInit() {
   
    console.log(this.travelList)

     this.webapi.getTravels().subscribe(x=>{
       console.log(x);
       this.travelList = x;
       this.sum=this.travelList.reduce((sum, current) => sum + current.price, 0); console.log(this.sum)
     })
  }
}
