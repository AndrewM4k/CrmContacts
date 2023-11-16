import { HttpClient } from '@angular/common/http';
import { Component,  OnInit } from '@angular/core';
import { AccountService } from './_services/account.service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    
  title = 'Contacts';
  contacts: any;
  closeResult: string | undefined;
  Added= false;
  model: any ={};
  id: any;

  constructor(
    private http: HttpClient, 
    private accountService: AccountService) {}

  ngOnInit(): void {
    this.http.get('https://localhost:7067/api/Contacts').subscribe({
      next: response => this.contacts = response,
      error: error => console.log(error)
    })
  }

  editing(id:any) {
    this.accountService.editing(this.model, id).subscribe({
      next: response => {
        console.log(response);
        this.Added = true;
      },
      error: error => console.log(error)
    })  
  }

  deleting(id:Guid) {
    this.accountService.deleting(id).subscribe({
      next: response => {
        console.log(response);
      },
      error: error => console.log(error)
    })  
  }

  open(content:any){
    const modelDiv = document.getElementById('exampleModal');
    if(modelDiv!= null){
      modelDiv.style.display = 'block';
      this.id = content;
    }
    return content;
  }

  close(){
    const modelDiv = document.getElementById('exampleModal');
    if(modelDiv!= null){
      modelDiv.style.display = 'none';
    }
  }
  }

