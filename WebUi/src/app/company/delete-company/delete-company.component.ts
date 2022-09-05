import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-delete-company',
  templateUrl: './delete-company.component.html',
  styleUrls: ['./delete-company.component.css']
})
export class DeleteCompanyComponent implements OnInit {

  companiesList$!:Observable<any[]>;

  constructor(private service:CompanyService) { }

  @Input() company:any;
  companyId: number = 0;
  companyName: string = "";

  ngOnInit(): void {
    this.companyId = this.company.companyId;
    this.companyName = this.company.name;
  }

  deleteCompany() {
    var id : number = this.companyId;
    this.service.deleteCompany(id).subscribe(res =>
    {
      var closeModalButton = document.getElementById('modal-close');
      if (closeModalButton) {
        closeModalButton.click();
      }
      var showDeletesuccess = document.getElementById('delete-success-alert');
      if (showDeletesuccess) {
        showDeletesuccess.style.display = "block";
      }
      setTimeout(function() {
        if(showDeletesuccess) {
          showDeletesuccess.style.display = "none";
        }
      }, 4000);
    }, err => {
      var showAddError = document.getElementById('delete-error-alert');
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
