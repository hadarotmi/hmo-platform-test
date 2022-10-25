import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Patient } from '../models/patient.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  data = new FormData();
  url='https://localhost:44304/api/Patients/'
  constructor(private http:HttpClient) { }

  AddPatient(patient:Patient):Observable<boolean>
  {
     
    return this.http.post<boolean>(this.url+"AddPatient",patient)
  }

  GetPatient(): Observable<Patient[]> {
    return this.http.get<Patient[]>(this.url + "GetPatient")

  }

 
  UpdatePatient(patient:Patient):Observable<boolean>
  {
      return this.http.post<boolean>(this.url+"UpdatePatient",patient)
  }

  DeletePatient(patientId:string):Observable<boolean>
  {
      
      return this.http.delete<boolean>(this.url+"DeletePatient/"+patientId)
  }
  
  GetCurrentPatient(PatientId: string): Observable<Patient> {
    return this.http.get<Patient>(this.url + "GetCurrentPatient/"+ PatientId)

  }


}
