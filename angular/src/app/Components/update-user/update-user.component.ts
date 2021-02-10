import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { WebApiService } from 'src/app/services/web-api.service';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit {

constructor(private webapi: WebApiService, private router: Router) { }
@Input() user:User
formUpdateUser:FormGroup;
  ngOnInit() {
    this.formUpdateUser=new FormGroup({
      ravkav:new FormControl (this.user.ravkav,[Validators.required]),
      firstName:new FormControl(this.user.firstName,[Validators.required]),
      lastName:new FormControl(this.user.lastName,[Validators.required]),
      profileId:new FormControl(this.user.profileId,[Validators.required])
    })
   
  }
  
UpdateDetails(){
  const user={...this.formUpdateUser.value};
  user["id"]=this.user.id;
  
  
  this.webapi.UpdateUser(user).subscribe(x => {
  if(x){
    alert('good');
    this.router.navigate(['/home']);
  }
  else
  alert('bed');
  });
}
}
