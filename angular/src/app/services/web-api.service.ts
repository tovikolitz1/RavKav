import { Injectable } from '@angular/core';
import {  HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';
import { CalculateResulte } from '../models/calculateResult';

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
  GetNameById(id:number) {
    return this.httpClient.get<string>("http://localhost:60000/api/User/GetNameById?id=" + id);
  }
  CalculateThePayment(id:number,dtDate:Date)
  {
    return this.httpClient.get<Array<CalculateResulte>>("http://localhost:60000/api/travel/CalaulateThePayment?id=" + id+"?date="+dtDate);
  };
  CalculateThePayment(id:number)
  {
    return this.httpClient.get<Array<CalculateResulte>>("http://localhost:60000/api/travel/CalaulateThePayment?id=" + id);
  };
}
