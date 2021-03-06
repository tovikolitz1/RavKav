import { User } from './../../models/user.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { WebApiService } from '../../services/web-api.service';
import {  FormGroup ,FormControl, Validators} from '@angular/forms';
import { userInfo } from 'os';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']//,'../globalStyle.css']
})
export class RegisterComponent implements OnInit {

  public user: User;


  constructor(private webapi: WebApiService, private router: Router) { }
  formRegister:FormGroup;
  ngOnInit() { 
    this.formRegister=new FormGroup({
      fName:new FormControl ('',[Validators.required]),
      lName:new FormControl('',[Validators.required]),
      ravkav:new FormControl('',[Validators.required]),
      email:new FormControl('',[Validators.required]),
      pass:new FormControl('',[Validators.required]),
      profileId:new FormControl('',[Validators.required])  
      
    })

  // this.user = new User({...this.formRegister.value});
  }

  register() {
   // alert(this.user.firstName)
    this.webapi.AddUser({...this.formRegister.value}).subscribe(y => {
      if (y)
      {
        alert("add!");
        this.router.navigate(['/Home'])
      }
      else
         alert("no");
    });
  }
}
