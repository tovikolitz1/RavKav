import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css','../globalStyle.css']
})
export class HeaderComponent implements OnInit {

  constructor() { }
 userName:string

  ngOnInit() {
    //         //Get the user display name before login
    if(localStorage.getItem("userName")!=null)
    this.userName = localStorage.getItem("userName");
else
    localStorage.setItem("userName", 'טובי תחפשי בקומפוננטה HEADER את השורה הזאת ובמקומה תכתבי את השם שלך');
  }

}
