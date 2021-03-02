import { Component, OnInit, Output } from '@angular/core';
import { WebApiService } from '../../services/web-api.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { User } from 'src/app/models/user.model';

//import swal from 'sweetalert';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']//,'../styleGlobal']
})
export class LoginComponent implements OnInit {

  constructor(private webapi: WebApiService, private router: Router) { }
  public ravkav: string;
  public password: string;
  public ID: number;
  formLogin: FormGroup;

  ngOnInit() {
    this.formLogin = new FormGroup({
      ravkav: new FormControl('', [Validators.required]),
      pass: new FormControl('', [Validators.required])
    });
    if (localStorage.getItem("userID") != null) {
      this.ID = parseInt(localStorage.getItem("userID"));
      this.webapi.UserDetails(this.ID).subscribe(u => {
        if (u != null)
          this.webapi.userEdit.emit(
            { ...u });

      });

    }
  }
  login() {
    this.webapi.IfExsistRavKav({ ...this.formLogin.value }).subscribe(u => {
      if (u != null) {
        console.log(u)
        this.webapi.userEdit.emit(
          { ...u });
        //Save the user display name on login
        localStorage.setItem("userID", String(u.id));
        this.router.navigate(['/home']);
      }
      else {
        //להוסיף הערות בתצוגה שאחד מהנתונים שגוי
      }

    })
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

  //var d=5;
  //var b=d;;/\
  //b=7;
  //d=5;
  //var a=[1,2,3]
  //var c=a;
  //c=[...a]


  //      this.webapi.IfExsistRavKav(this.ravkav, this.password).subscribe(ID => {
  //     if (ID != 0)
  //        {

  //          window.localStorage.setItem('ID',String(ID));

  //          this.router.navigate(['account',localStorage.getItem('ID')]);
  //        }
  //        else{
  //          alert('hjk');
  //        }
  //      }
  //  //}
  //          else
  //  {
  //swal({
  //          title: "הכניסה נכשלה",
  //           text: "נסה שוב",
  //           icon: "warning",
  //           dangerMode: true,
  //         })
  //         .then(willDelete => {
  //         });

  //       }

  //   });
  // }


}