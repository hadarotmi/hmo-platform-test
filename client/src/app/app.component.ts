import {  Component } from '@angular/core';
import { Router } from '@angular/router';
import { Patient } from './models/patient.model';
import { PatientService } from './services/patient.service';


@Component({
  selector: 'app-root', 

  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
 
	
})
export class AppComponent  {
  
  title = 'client';

 
}

