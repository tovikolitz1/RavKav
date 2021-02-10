import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { WebApiService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {
user:User;
  constructor(private webapi: WebApiService, private router: Router) { }

  ngOnInit() {
    this.user=this.webapi.getUSer()
   if(!this.webapi.getUSer().isManager){
     
    this.router.navigate(["login"])
   }
   this.webapi.userEdit.subscribe(x=>{
    if(!x.isManager)
    this.router.navigate(["login"])
   })

  }
}
