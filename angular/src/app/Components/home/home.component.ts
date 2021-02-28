import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { WebApiService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private router: Router, public userService:WebApiService) { }
  isManager:boolean=false;
  ngOnInit() {
    
    this.isManager=this.userService.getUSer().isManager;
this.userService.userEdit.subscribe((user:User)=>{
    this.isManager= user.isManager;
  });
  }
  
}
