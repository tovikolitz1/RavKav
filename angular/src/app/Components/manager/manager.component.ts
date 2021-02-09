import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WebApiService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {

  constructor(private webapi: WebApiService, private router: Router) { }

  ngOnInit() {

  }

}
