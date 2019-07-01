import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/model';
import { NgForm, NgModel } from '@angular/forms';
import { AuthService} from '../auth.service'
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user: User;
  formValid: boolean;

  constructor(private auth: AuthService, private toastr: ToastrService) { }

  ngOnInit() {
    this.user = new User();
    this.formValid = false;
  }

  onRegister(){
    console.log(123);
  //   this.auth.register(this.user).subscribe( data => {
  //     console.log(data);
  //     console.log(this.user.username, this.user.password);
  //     this.toastr.success("User registered");
  //   },
  //   error => {
  //     console.log(JSON.stringify(error));
  //   });

     this.auth.register(this.user);
  }

}