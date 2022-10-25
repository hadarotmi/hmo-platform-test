import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient} from '@angular/common/http'
import { Covid19_Vaccine } from '../models/covid19_Vaccine.model';
@Injectable({
  providedIn: 'root'
})
export class VaccinesService {
  url='https://localhost:44304/api/Vaccines/'
  constructor(private http:HttpClient) { }
  
  GetVaccinesToPatient(PatientId: string): Observable<Covid19_Vaccine[]> 
  {
      return this.http.get<Covid19_Vaccine[]>(this.url +"GetVaccinesToPatient/"+PatientId);
  }

  AddVaccineToPatient(vaccine:Covid19_Vaccine):Observable<boolean>
  {
     
    return this.http.post<boolean>(this.url+"AddVaccineToPatient",vaccine)
  }
}
