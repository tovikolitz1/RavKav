import { Injectable } from '@angular/core';
import {  HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class WebApiService {
  constructor(private httpClient: HttpClient) { }
  IfExsistRavKav(objec:{ravKav: string, pass: string}) {
    return this.httpClient.get<number>("http://localhost:60000/api/User/IfExsistRavKav?ravKav=" + objec.ravKav + "&pass=" + objec.pass);
  }
  AddUser(user:User){
    return this.httpClient.post<boolean>("http://localhost:60000/api/User/AddUser",user);
  }
  CalculateThePayment(id:number,dtDate:Date)
  {
    return this.httpClient.get<number>("http://localhost:60000/api/Travel/CalaulateThePayment?id=" + id+"?date="+dtDate);
  };
  GetNameById(id:number) {
    return this.httpClient.get<string>("http://localhost:60000/api/User/GetNameById?id=" + id);
  }
}
