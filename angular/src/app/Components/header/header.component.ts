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
    if(localStorage.getItem("userName")!=null)
    this.userName = localStorage.getItem("userName");
else
    localStorage.setItem("userName", 'רחלי');
  
  this.userSer.userEdit.subscribe((x:User)=>{
    this.userName=x.fName+" "+x.lName;
  })
}
}
