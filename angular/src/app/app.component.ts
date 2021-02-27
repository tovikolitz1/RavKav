import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './models/user.model';
import { WebApiService } from './services/web-api.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css','./Components/globalStyle.css']
})
export class AppComponent implements OnInit {
 title = 'project';
 user:User
 constructor(private webapi: WebApiService, private router: Router) { }
ngOnInit() {
 
}
}
