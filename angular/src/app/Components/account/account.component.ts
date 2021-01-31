import { Component, OnInit } from '@angular/core';
import { WebApiService } from '../../services/web-api.service';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  constructor(private webapi: WebApiService, private route: ActivatedRoute, private router: Router)  { }
public id:number=  Number(this.route.snapshot.paramMap.get('id'));
  public amountPayable:number;
  ngOnInit() {
    
    var dt = new Date();
document.getElementById("datetime").innerHTML = dt.toLocaleDateString();
    this.webapi.CalculateThePayment(this.id,new Date()).subscribe(y => {
     this.amountPayable=y});
  }

}
