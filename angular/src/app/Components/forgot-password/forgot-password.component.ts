

import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { $ } from 'protractor';
import { User } from 'src/app/models/user.model';
import { WebApiService } from 'src/app/services/web-api.service';



@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})


  export class ForgotPasswordComponent implements OnInit {

    constructor(private webapi: WebApiService, private router: Router) { }
    formForgotPassword: FormGroup;
    public ravkav: string;
    public tempPass: string;
    public newPass: string;
    public verifyNewPass: string;
    ngOnInit() {
  
      this.formForgotPassword = new FormGroup({
        ravkav: new FormControl('', [Validators.required])
      })
    }
  

    changePassword() {
      debugger
      //if (document.getElementById("vertification").className != "d-none") {
        this.webapi.forgotPassword({...this.formForgotPassword.value}).subscribe(x => {
          if (x) {
            alert('הסיסמה נשלחה בהצלחה, אנא הזן קוד אימות');
          //  $("#vertification").removeClass('d-none');
          //  $("#ravkav").addClass('d-none');
          }
        })
      }
 //  else {
   // }
    // fg(){
    //   // this.formForgotPassword = new FormGroup({
    //   //   tempPass: new FormControl('', [Validators.required]),
    //   //   newPass: new FormControl('', [Validators.required]),
    //   //   verifyNewPass: new FormControl('', [Validators.required])
    //   // })
    //   if(this.newPass!=this.verifyNewPass)
    //   alert("אימות סיסמה לא תואם")
    //   this.webapi.changePassword({ ...this.formForgotPassword.value }).subscribe(y => {
    //     if (y) {
    //       alert("succes")
    //       this.router.navigate(['/login'])
    //     }
    //     else
    //       alert("try again");
    //   })
    // }

 // }
}