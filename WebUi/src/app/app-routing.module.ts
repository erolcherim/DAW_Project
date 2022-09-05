import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AuthenticationGuard} from "./authentication.guard";

import {LoginComponent} from "./login/login.component";
import {RegisterComponent} from "./register/register.component";
import {CompanyComponent} from "./company/company.component";

const routes: Routes = [
  {path:"",component:CompanyComponent, canActivate:[AuthenticationGuard]},
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
