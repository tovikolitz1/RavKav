import { Component, OnInit } from '@angular/core';
import { WebApiService } from '../../services/web-api.service';
import { User } from '../../models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private webapi: WebApiService, private router: Router) { }
  public ravkav: string;
  public password: string;
  ngOnInit() {
  }
  login() {

    this.webapi.IfExsistRavKav(this.ravkav, this.password).subscribe(y => {
      if (y == 0)
        alert("undifine!!!!!!");
        else
        {
          alert("fine!!!!!!");
          this.router.navigate(['account',y]);
        }
        
    });
  }
  newUser() {
  }
}
