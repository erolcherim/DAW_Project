import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-add-edit-company',
  templateUrl: './add-edit-company.component.html',
  styleUrls: ['./add-edit-company.component.css']
})
export class AddEditCompanyComponent implements OnInit {

  companiesList$!:Observable<any[]>;

  constructor(private service:CompanyService) { }

  @Input() company:any;
  companyId: number = 0;
  companyName: string = "";
  ceo: string = "";

  ngOnInit(): void {
    this.companyId = this.company.companyId;
    this.companyName = this.company.companyName;
    this.ceo = this.company.ceo;
  }

  addCompany() {
    var company = { companyName: this.companyName }
    this.service.addCompany(company).subscribe(res =>
    {
      var closeModalButton = document.getElementById('modal-close');
      if (closeModalButton) {
        closeModalButton.click();
      }
      var showAddsuccess = document.getElementById('add-success-alert');
      if (showAddsuccess) {
        showAddsuccess.style.display = "block";
      }
      setTimeout(function() {
        if(showAddsuccess) {
          showAddsuccess.style.display = "none";
        }
      }, 4000);
    }, err => {
      var showAddError = document.getElementById('add-error-alert');
      if (showAddError) {
        showAddError.innerHTML = err.error;
        showAddError.style.display = "block";
      }
      setTimeout(function() {
        if(showAddError) {
          showAddError.style.display = "none";
        }
      }, 4000);
    })
  }

  updateCompany() {
    var companyUpdated = {
      companyId: this.companyId,
      companyName: this.companyName,
      ceo: this.ceo
    }
    var id : number = this.companyId;
    this.service.updateCompany(id, companyUpdated).subscribe(res =>
    {
      var closeModalButton = document.getElementById('modal-close');
      if (closeModalButton) {
        closeModalButton.click();
      }
      var showUpdatesuccess = document.getElementById('update-success-alert');
      if (showUpdatesuccess) {
        showUpdatesuccess.style.display = "block";
      }
      setTimeout(function() {
        if(showUpdatesuccess) {
          showUpdatesuccess.style.display = "none";
        }
      }, 4000);
    }, err => {
      var showAddError = document.getElementById('add-error-alert');
      if (showAddError) {
        showAddError.innerHTML = err.error;
        showAddError.style.display = "block";
      }
      setTimeout(function() {
        if(showAddError) {
          showAddError.style.display = "none";
        }
      }, 4000);
    })
  }

  closeModal() {
    var closeModalButton = document.getElementById('modal-close');
    if (closeModalButton) {
      closeModalButton.click()
    }
  }
}
