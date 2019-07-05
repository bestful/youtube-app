import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-credential',
  templateUrl: './credential.component.html',
  styleUrls: ['./credential.component.css']
})
export class CredentialComponent implements OnInit {

  constructor(public account: AccountService) { }

  ngOnInit() {
    this.account.updateAccount();
  }

  acc(){
  }


}
