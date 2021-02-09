import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { WebApiService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  constructor(private webapi: WebApiService, private router: Router) { }
  formLogin:FormGroup;
  @Input() user:User;
  ngOnInit() {
    this.formLogin=new FormGroup({
      tempPass:new FormControl ('',[Validators.required]),
      newPass:new FormControl('',[Validators.required]),
      verifyNewPass:new FormControl('',[Validators.required])
    })
  }
  changePassword() {
   
    this.webapi.forgotPassword(this.user.id).subscribe(x => {
      if(x)
      {
        this.webapi.changePassword(this.user.id,{...this.formLogin.value},"rnd").subscribe(y => {
          if(y)
          {
          alert("succes");
          this.router.navigate(['/login'])
        }
          else
          alert("try again");
        })
        
      }
      else
      alert("try again");
    })
   }
}
