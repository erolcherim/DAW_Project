import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  email: string = "";
  password: string = "";
  confirmPassword: string = "";
  firstName: string = "";
  lastName: string = "";
  phoneNumber: string = "";
  age: string = "";

  constructor(private service:LoginService, private route:Router) {
  }

  ngOnInit(): void {
  }

  PasswordsMatch() {
    return this.password == this.confirmPassword;
  }

  ProceedRegister() {
    if (this.PasswordsMatch()) {
      var user = {
        firstName: this.firstName,
        lastName: this.lastName,
        email: this.email,
        age: this.age,
        phoneNumber: this.phoneNumber,
        password: this.password
      }
      this.service.ProceedRegister(user).subscribe(res =>
      {
        var showRegisterAlert = document.getElementById('register-succes-alert');
        if (showRegisterAlert) {
          showRegisterAlert.style.display = "block";
        }
        setTimeout(function() {
          if(showRegisterAlert) {
            showRegisterAlert.style.display = "none";
          }
        }, 4000);
      }, err =>
      {
        var showRegisterAlert = document.getElementById('register-fail-alert');
        if (showRegisterAlert) {
          showRegisterAlert.innerHTML = err.error;
          showRegisterAlert.style.display = "block";
        }
        setTimeout(function() {
          if(showRegisterAlert) {
            showRegisterAlert.style.display = "none";
          }
        }, 4000);
      })
    }
    else {
      var showPasswordAlert = document.getElementById('register-fail-alert');
      if (showPasswordAlert) {
        showPasswordAlert.innerHTML = "Passwords don't match";
        showPasswordAlert.style.display = "block";
      }
      setTimeout(function() {
        if(showPasswordAlert) {
          showPasswordAlert.style.display = "none";
        }
      }, 4000);
    }
  }

}
