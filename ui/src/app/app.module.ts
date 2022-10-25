import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddPatientComponent } from './components/add-patient/add-patient.component';
import { RouterModule } from '@angular/router';
import { PatientDetailsComponent } from './components/patient-details/patient-details.component';
import { MainComponent } from './components/main/main.component';


@NgModule({
  exports: [ RouterModule ],
  declarations: [
    AppComponent,
    AddPatientComponent,
    PatientDetailsComponent,
    MainComponent


  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path: '', component:MainComponent },
      {path: 'add-patient', component:AddPatientComponent },
      {path: 'add-patient/:id', component:AddPatientComponent },
      {path: 'patient-details/:id', component:PatientDetailsComponent },
    ]),
 
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
