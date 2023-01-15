import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiService } from './web-api.service';

var apiUrl = "https://localhost:7152";

var httpLink = {
  getAllBar: apiUrl + "/api/Bars",
  deleteBarById: apiUrl + "/api/Bars/",
  getBarDetailById: apiUrl + "/api/Bars/",
  saveBar: apiUrl + "/api/Bars/"
}
@Injectable({
  providedIn: 'root'
})
export class HttpProviderService {
  constructor(private webApiService: WebApiService) { }

  public getAllBars(): Observable<any> {
    return this.webApiService.get(httpLink.getAllBar);
  }
  public deleteBarById(model: any): Observable<any> {
    return this.webApiService.post(httpLink.deleteBarById + '?barId=' + model, "");
  }
  public getBarDetailById(model: any): Observable<any> {
    return this.webApiService.get(httpLink.getBarDetailById + '?barId=' + model);
  }
  public saveBar(model: any): Observable<any> {
    return this.webApiService.post(httpLink.saveBar, model);
  }  
}                          