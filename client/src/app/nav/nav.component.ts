import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})

export class NavComponent implements OnInit {

  model: any ={};
  Added = false;
  

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
  }

  adding() {
    this.accountService.adding(this.model).subscribe({
      next: response => {
        console.log(response);
        this.Added = true;
      },
      error: error => console.log(error)
    })  
  }

  open(){
    const modelDiv = document.getElementById('newModal');
    if(modelDiv!= null){
      modelDiv.style.display = 'block';
    }
  }

  close(){
    const modelDiv = document.getElementById('newModal');
    if(modelDiv!= null){
      modelDiv.style.display = 'none';
    }
  }
}
