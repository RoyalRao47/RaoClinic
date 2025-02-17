import { Component } from '@angular/core';
import { DoctorLefbarComponent } from "../doctor-lefbar/doctor-lefbar.component";

@Component({
  selector: 'app-availability',
  standalone: true,
  imports: [DoctorLefbarComponent],
  templateUrl: './availability.component.html',
  styleUrl: './availability.component.css'
})
export class AvailabilityComponent {

}
