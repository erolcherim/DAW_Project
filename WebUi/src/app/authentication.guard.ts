import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import { Observable } from 'rxjs';
import {LoginService} from "./services/login.service";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationGuard implements CanActivate {

  constructor(private service:LoginService, private route:Router) {

  }
  canActivate() {
    if (this.service.IsLoggedIn())
    {
      return true;
    }
    else
    {
      this.route.navigate(['/login']);
      return false;
    }
  }


}
