import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  email: string = "";
  password: string = "";

  responseData: any;

  constructor(private service: LoginService, private route: Router) {
  }

  ngOnInit(): void {
  }

  ProceedLogin() {
    var user = {
      email: this.email,
      password: this.password
    }

    this.service.ProceedLogin(user).subscribe(res => {
      if (res != null) {
        this.responseData = res;
        localStorage.setItem('token', this.responseData.tokenString);
        this.route.navigate(['']).then(() => {
          window.location.reload();
        });
      }
    }, err => {
      var showLoginAlert = document.getElementById('login-fail-alert');
      if (showLoginAlert) {
        showLoginAlert.innerHTML = err.error;
        showLoginAlert.style.display = "block";
      }
      setTimeout(function () {
        if (showLoginAlert) {
          showLoginAlert.style.display = "none";
        }
      }, 4000);
    })
  }

  ReloadPage() {
    window.location.reload();
  }
}
