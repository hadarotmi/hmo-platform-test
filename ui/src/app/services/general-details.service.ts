import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient} from '@angular/common/http'
@Injectable({
  providedIn: 'root'
})
export class GeneralDetailsService {
  url='https://localhost:44304/api/GeneralDetails/'
  constructor(private http:HttpClient) { }
  NumberNotVaccine(): Observable<Number> 
  {
      return this.http.get<Number>(this.url +"NumberNotVaccine");
  }


  SickInMonth(): Observable<Number[]> 
  {
      return this.http.get<Number[]>(this.url +"SickInMonth");
  }
}
