import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { RegisterComponent } from './Components/register/register.component';
import { LoginComponent } from './Components/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { ShowTravelsComponent } from './Components/show-travels/show-travels.component';
import { FormsModule,ReactiveFormsModule}   from '@angular/forms';
import { TravelComponent } from './Components/travel/travel.component';
import { ContractComponent } from './Components/contract/contract.component';
import { ForgotPasswordComponent } from './Components/forgot-password/forgot-password.component';
import { ManagerComponent } from './Components/manager/manager.component';
//import swal from 'sweetalert';
const routes:Routes=
[
{path:'',component:LoginComponent},
{path:'login',component:LoginComponent},
{path:'Register',component:RegisterComponent},
{path:'showTravels/:id',component:ShowTravelsComponent},
{path:'manager/:id',component:ManagerComponent},
{path:'contract/:id',component:ContractComponent}

]
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ShowTravelsComponent,
    TravelComponent,
    ContractComponent,
    ForgotPasswordComponent,
    ManagerComponent
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
