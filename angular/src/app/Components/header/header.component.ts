import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { WebApiService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(public userSer: WebApiService, private router: Router) { }
  userName: string;
  usersList: User[];
  userListFilter: User[];
  filter: string = "";
  userSelected: User;
  isShowList: boolean = false;

  filterL() {
    const li = [...this.usersList]
    this.userListFilter = li.filter(x => this.filter == "" || x.fName.includes(this.filter) || x.lName.includes(this.filter) ||
      (x.lName + " " + x.fName).includes(this.filter) || (x.fName + " " + x.lName).includes(this.filter)
    )
    document.getElementById("selectList").focus();
  }

  selecdedItem() {
    debugger
    this.userSer.userEdit.emit(
      { ...this.userSelected });
    alert('select')
  }


  ngOnInit() {
    if (this.router.url === '/home' || this.router.url === '/' || this.router.url === '/login')
      this.isShowList = false;
    else
      this.isShowList = true
    console.log(this.router.url)
    this.userName = "היי אורח,"

    //if ther is id show user name
    if (localStorage.getItem("userID") != null) {
      {

        this.userSer.UserDetails(parseInt(localStorage.getItem("userID"))).subscribe(u => {
          if (u != null)
            this.userSer.userEdit.emit(
              { ...u });

        });
      }
    }
// in change of user update  th list
    this.userSer.userEdit.subscribe((user: User) => {
      debugger
      if (this.userSer.isManager) {
        //sqy hallo to the manager
        this.userName = "היי " + this.userSer.mamager.fName + " " + this.userSer.mamager.lName + ",";
        //list of users
        this.userSer.GetUsersList().subscribe(y => {
          if (y) {
            this.usersList = y;
            this.filterL();
          }
        });
      }
      else {
        //hallo to ither users
        this.userName = "היי " + user.fName + " " + user.lName + ",";
      }

    })
  }

}

