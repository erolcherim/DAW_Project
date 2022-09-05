import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule} from "@angular/common/http";
import {CommonModule} from "@angular/common";
import { RegisterComponent } from './register/register.component';
import { SalesComponent } from './sales/sales.component';
import { CompanyComponent } from './company/company.component';

import { CompanyService } from "./services/company.service";
import { AddEditCompanyComponent } from './company/add-edit-company/add-edit-company.component';
import { DeleteCompanyComponent } from './company/delete-company/delete-company.component';
import { ShowCompanyComponent } from './company/show-company/show-company.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    SalesComponent,
    CompanyComponent,
    AddEditCompanyComponent,
    DeleteCompanyComponent,
    ShowCompanyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    ReactiveFormsModule
  ],
  providers: [CompanyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
