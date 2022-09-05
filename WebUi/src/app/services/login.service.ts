import { HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  readonly apiurl = "https://localhost:7226/api";
  isLoggedInVar: boolean = this.IsLoggedIn();
  constructor(private http:HttpClient) { }

  ProceedLogin(user:any) {
    return this.http.post(this.apiurl + '/Account/login', user);
  }

  ProceedRegister(user:any) {
    return this.http.post(this.apiurl + '/Account/register', user);
  }

  IsLoggedIn() {
    return localStorage.getItem('token') != null;
  }

  LogOut() {
    localStorage.removeItem('token');
    window.location.reload();
  }

  GetToken() {
    return localStorage.getItem('token') || '';
  }
}
