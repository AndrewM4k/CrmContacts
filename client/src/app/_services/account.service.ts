import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  
  baseUrl = 'https://localhost:7067/api'

  constructor(private http: HttpClient) { }

  adding(model: any){
    return this.http.post(this.baseUrl +'/Contacts', model)
  }

  editing(model: any, id: any){
    return this.http.put(this.baseUrl +'/Contacts?id='+ id, model)
  }
  deleting(id: Guid){
    console.log(this.baseUrl +'/Contacts/'+ id)
    return this.http.delete(this.baseUrl +'/Contacts/'+ id)
    
  }
}
