import { Component,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DoctorLefbarComponent } from "../doctor-lefbar/doctor-lefbar.component";

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [RouterModule, DoctorLefbarComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class DashboardComponent {

}
