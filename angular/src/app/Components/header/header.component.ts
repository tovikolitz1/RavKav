import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { WebApiService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(public userSer: WebApiService) { }
  userName: string;
  usersList: User[];
  userListFilter: User[];
  filter: string = "";
  userSelected=User;

  filterL() {
    const li = [...this.usersList]
    this.userListFilter = li.filter(x => this.filter == "" || x.fName.includes(this.filter) || x.lName.includes(this.filter) ||
      (x.lName + " " + x.fName).includes(this.filter) || (x.fName + " " + x.lName).includes(this.filter)
    )
    
  }
  ngOnInit() {
    this.userName = "היי אורח,"
    this.userSer.userEdit.subscribe((user: User) => {
      
      
if(this.userSer.isManager){
  this.userName = "היי " + this.userSer.mamager.fName + " " + this.userSer.mamager.lName + ",";
}
else{
  this.userName = "היי " + user.fName + " " + user.lName + ",";
      
}
      if (user.isManager) {
        
        this.userSer.GetUsersList().subscribe(y => {
          if (y) {
            this.usersList = y;
            this.filterL();
          }
        });
      }
    })
  }
}

