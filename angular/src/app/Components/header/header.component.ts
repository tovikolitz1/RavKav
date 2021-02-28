import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { WebApiService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']//,'../globalStyle.css']
})
export class HeaderComponent implements OnInit {

  constructor(public userSer:WebApiService) { }
 userName:string

  ngOnInit() {
    //         //Get the user display name before login
    
    this.userName = "היי אורח,"

  
  this.userSer.userEdit.subscribe((user:User)=>{
    this.userName="היי "+ user.fName+" "+user.lName+",";
    //Save the user display name on login
    localStorage.setItem("userID", String(user.id));
  })
}
}
