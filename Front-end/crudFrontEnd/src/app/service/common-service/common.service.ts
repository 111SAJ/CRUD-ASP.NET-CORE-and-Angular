import { Injectable } from '@angular/core';
import { ajLib } from '../../../helpers/ajLib';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommonService {
  protected options:any={
    headers:{
      'Content-Type': "application/json",
    }
  }

  constructor(protected http:HttpClient) { }

  public post(endpoint:string, formData: any, queryParams: any): Observable<any> {
    this.options.params = queryParams
    return this.http.post(endpoint,formData, this.options)
  }

  public delete(endpoint:string, queryParams:any):Observable<any>{
    this.options.params = queryParams
    return this.http.delete(endpoint, this.options)
  }
}
