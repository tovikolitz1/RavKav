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

    this.webapi.IfExsistRavKav(this.ravkav, this.password).subscribe(ID => {
      if (ID != 0)
      {
        window.localStorage.setItem('ID',ID);

        this.router.navigate(['account',localStorage.getItem('ID')]);
      }
        else
        {
         alert("undifine!!!!!!");
        }
        
    });
  }
  newUser() {
  }
}
