import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Covid19_Vaccine } from 'src/app/models/covid19_Vaccine.model';
import { Patient } from 'src/app/models/patient.model';
import { GeneralDetailsService } from 'src/app/services/general-details.service';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  patients:Patient[];

  patient:Patient=new Patient();
  Id:string;
  numbernotvaccine:Number;
  sickinmonth:Number[]
 value=false;

 
  ngOnInit(): void {
  }
  constructor(private patientService:PatientService,private generaldetailsservice:GeneralDetailsService,private router:Router) 
  {
    //רשימת חברי קופה
    this.patientService.GetPatient().subscribe(

      res => { this.patients = res; }

    )
    
    //מספר החברים בקופה שלא מחוסנים
    this.generaldetailsservice.NumberNotVaccine().subscribe(

      res => { this.numbernotvaccine=res; }

    )

    //רשימה של חולים פעילים בחודש האחרון
    this.generaldetailsservice.SickInMonth().subscribe(

      res => { this.sickinmonth=res; console.log(res) }

    )
   
  
}
GetCurrentPatient()
{
  this.router.navigate(['/patient-details',this.Id]);
}

}
