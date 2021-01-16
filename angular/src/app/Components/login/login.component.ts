import { Component, OnInit } from '@angular/core';
import { WebApiService } from '../../services/web-api.service';
import { User } from '../../models/user.model';
import { Router } from '@angular/router';
import {AppModule}from 'src/app/app.module';
import { from } from 'rxjs';
import { FormsModule, FormGroup ,FormControl, Validators}   from '@angular/forms';
//import swal from 'sweetalert';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private webapi: WebApiService, private router: Router) { }
  public ravkav: string;
  public password: string;
  formLogin:FormGroup;
  
  ngOnInit() {
    this.formLogin=new FormGroup({
      ravkav:new FormControl ('',[Validators.required]),
      pass:new FormControl('',[Validators.required])
    })
    
  }
}
//   ///אבא
//   x:string
//   ///בן
//   @Input()
//   t:string
//   @output()
//   clickList=new eventEmiter<string>()
//   clickList=new observble<string>()
// save(){
//   this.clickList.emit("xxxx")

//   this.clickList.subscribe(x=>)


  // login() {

  //   this.webapi.IfExsistRavKav(this.ravkav, this.password).subscribe(ID => {
  //     if (ID != 0)
  //     {

  //       window.localStorage.setItem('ID',String(ID));

  //       this.router.navigate(['account',localStorage.getItem('ID')]);
  //     }
  //     else{
  //       alert('hjk');
  //     }
  //   }
  // }
  //       else
  //       {
  //         swal({
  //           title: "הכניסה נכשלה",
  //           text: "נסה שוב",
  //           icon: "warning",
  //           dangerMode: true,
  //         })
  //         .then(willDelete => {
  //         });
         
  //       }
        
  //   });
  // }
  // newUser() {
  // }


