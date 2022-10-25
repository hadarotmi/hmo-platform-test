import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Covid19_Vaccine } from 'src/app/models/covid19_Vaccine.model';
import { Patient } from 'src/app/models/patient.model';
import { PatientService } from 'src/app/services/patient.service';
import { VaccinesService } from 'src/app/services/vaccines.service';

@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.css']
})
export class PatientDetailsComponent implements OnInit {
  patient: Patient;
  IdPatient: string;

  upDate = false
  vaccine: FormGroup;
  VaccinesToPatient: Covid19_Vaccine[];
  numberofvaccine: boolean = false;
  myvaccine: Covid19_Vaccine = new Covid19_Vaccine();

  constructor(private patientService: PatientService, private vaccinesservice: VaccinesService, private routerId: ActivatedRoute, private router: Router) {




  }

  ngOnInit(): void {

    this.IdPatient = this.routerId.snapshot.paramMap.get('id');

    //רשימת חיסונים למטופל
    this.vaccinesservice.GetVaccinesToPatient(this.IdPatient).subscribe(
      res => { this.VaccinesToPatient = res; }
    )

    //פרטי חבר קופה ספציפי
    this.patientService.GetCurrentPatient(this.IdPatient).subscribe(
      res => { this.patient = res; }
    )


    this.vaccine = new FormGroup({
      dateVaccine: new FormControl(),
      creator: new FormControl()
    });
   
  }
  

  UpdatePatient() {

    if (this.upDate == false)
      this.upDate = true;
    else {
      this.patient.FirstName = (document.getElementById('firstName') as HTMLInputElement).value
      this.patient.LastName = (document.getElementById('lastName') as HTMLInputElement).value
      this.patient.Address = (document.getElementById('address') as HTMLInputElement).value
      this.patient.Telephone = (document.getElementById('telephone') as HTMLInputElement).value
      this.patient.Phone = (document.getElementById('phone') as HTMLInputElement).value
      if (this.patient.StartCovid19 == null) {
        this.patient.StartCovid19 = new Date((document.getElementById('startcovid19') as HTMLInputElement).value)
      }
      if (this.patient.EndCovid19 == null) {
        this.patient.EndCovid19 = new Date((document.getElementById('endcovid19') as HTMLInputElement).value)
      }

      console.log(this.patient)
      this.patientService.UpdatePatient(this.patient).subscribe(
        res => { }
      )
      this.upDate = false
    }


  }
  
  DeletePatient() {
    this.patientService.DeletePatient(this.IdPatient).subscribe(
      res => { }
    )
    this.router.navigate(['/']);
  }

  AddVaccine() {
    debugger
    if (this.numberofvaccine == false)
      this.numberofvaccine = true;
    else {
      if (this.vaccine.valid) {

        this.myvaccine.IdPatient = this.IdPatient;
        this.myvaccine.NumberOfVaccine = this.VaccinesToPatient.length+1;
        this.myvaccine.DateOfVaccine = new Date((document.getElementById('dateVaccine') as HTMLInputElement).value)
        this.myvaccine.Creator = (document.getElementById('creator') as HTMLInputElement).value
        this.vaccinesservice.AddVaccineToPatient(this.myvaccine).subscribe(
          res => (console.log(res)
          )
        )
      }
      
      this.numberofvaccine=false;
    }
  }
}
