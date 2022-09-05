import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-show-company',
  templateUrl: './show-company.component.html',
  styleUrls: ['./show-company.component.css']
})
export class ShowCompanyComponent implements OnInit {

  companiesList$!:Observable<any[]>;
  activateAddEditCompany:boolean = false;
  activateDeleteCompany:boolean = false;
  company:any;

  constructor(private service:CompanyService) { }

  ngOnInit(): void {
    this.companiesList$ = this.service.getCompanies();
  }

  openModal() {
    this.company = { companyId:0, companyName:"", ceo:"", }
    this.activateAddEditCompany = true;
  }

  editModal(item:any) {
    this.company = item;
    this.activateAddEditCompany = true;
  }

  deleteModal(item:any) {
    this.company = item;
    this.activateDeleteCompany = true;
  }

  closeModal() {
    this.activateAddEditCompany = false;
    this.activateDeleteCompany = false;
    this.companiesList$ = this.service.getCompanies();
  }

}
