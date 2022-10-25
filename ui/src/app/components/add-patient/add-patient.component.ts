import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router, } from '@angular/router';
import { Patient } from 'src/app/models/patient.model';
import { PatientService } from 'src/app/services/patient.service';


@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.css']
})
export class AddPatientComponent implements OnInit {
  patient: Patient = new Patient();
  myForm: FormGroup;
  constructor(private patientService: PatientService, private router: Router) { }

  ngOnInit(): void {
    this.myForm = new FormGroup({
      Id: new FormControl('', Validators.compose([Validators.required, Validators.pattern('[0-9]*')])),
      FirstName: new FormControl('', Validators.compose([Validators.required, Validators.pattern('[א-ת ]*')])),
      LastName: new FormControl('', Validators.compose([Validators.required, Validators.pattern('[א-ת ]*')])),
      Address: new FormControl(),
      Birth: new FormControl(),
      Telephone: new FormControl('', Validators.compose([Validators.pattern('[0-9]{9}')])),
      Phone: new FormControl('', Validators.compose([Validators.required, Validators.pattern('[0-9]{10}')])),
      StartCovid19: new FormControl(),
      EndCovid19: new FormControl()

    });




  }

  AddPatient() {
  
    if (this.myForm.valid) {
    debugger
      this.patient.Id = this.myForm.controls.Id.value;
      this.patient.FirstName = this.myForm.controls.FirstName.value;
      this.patient.LastName = this.myForm.controls.LastName.value;
      this.patient.Birth = this.myForm.controls.Birth.value;
      this.patient.Telephone = this.myForm.controls.Telephone.value;
      this.patient.Phone = this.myForm.controls.Phone.value;
      this.patient.Address = this.myForm.controls.Address.value;
      this.patient.StartCovid19 = this.myForm.controls.StartCovid19.value;
      this.patient.EndCovid19 = this.myForm.controls.EndCovid19.value;

      this.patientService.AddPatient(this.patient).subscribe(
        res => (console.log(res)
        )
      )
      this.router.navigate(['/']);
    } else {
      debugger;
    }
    


  }

}
