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
formLogin:FormGroup;
  ngOnInit() {
    this.formLogin=new FormGroup({
      ravkav:new FormControl ('',[Validators.required]),
      firstName:new FormControl('',[Validators.required]),
      lastName:new FormControl('',[Validators.required]),
      profileId:new FormControl('',[Validators.required])
    })
  }
UpdateDetails(){
  this.webapi.UpdateUser({...this.user}).subscribe(x => {
  if(x){
    alert('good');
    this.router.navigate(['/home']);
  }
  else
  alert('bed');
  });
}
}
