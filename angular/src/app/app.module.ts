import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

import { RegisterComponent } from './Components/register/register.component';
import { LoginComponent } from './Components/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { AccountComponent } from './Components/account/account.component';
import { ShowTravelsComponent } from './Components/show-travels/show-travels.component';
import { FormsModule,ReactiveFormsModule}   from '@angular/forms';
import { TravelComponent } from './Components/travel/travel.component';
import { ContractComponent } from './contract/contract.component';
//import swal from 'sweetalert';
const routes:Routes=
[
{path:'',component:LoginComponent},
{path:'login',component:LoginComponent},
{path:'Register',component:RegisterComponent},
{path:'account/:id',component:AccountComponent},
{path:'showTravels/:id',component:ShowTravelsComponent}
]
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    LoginComponent,
    AccountComponent,
    ShowTravelsComponent,
    TravelComponent,
    ContractComponent
  ],
  imports:[
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
