import { User } from './../../models/user.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WebApiService } from '../../services/web-api.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public user: User;

  constructor(private webapi: WebApiService, private router: Router) { }

  ngOnInit() {
    this.user = new User();
  }

  register() {
    alert(this.user.firstName)
    this.webapi.AddUser(this.user).subscribe(y => {
      if (y == false)
        alert("no");
      else
        alert("add!");
        this.router.navigate(['/login'])
    });
  }
}
