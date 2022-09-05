import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  readonly apiurl = "https://localhost:7226/api";

  constructor(private http : HttpClient) { }

  getCompanies() : Observable<any[]> {
    return this.http.get<any>(this.apiurl + '/Companies');
  }

  getCompany(id:number) : Observable<any> {
    return this.http.get<any>(this.apiurl + `/Companies/${id}`);
  }

  addCompany(data:any) {
    return this.http.post(this.apiurl + '/Companies', data);
  }

  updateCompany(id:number, data:any) {
    return this.http.put(this.apiurl + `/Companies/${id}`, data);
  }

  deleteCompany(id:number) {
    return this.http.delete(this.apiurl + `/Companies/${id}`);
  }
}
