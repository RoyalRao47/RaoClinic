import { Component,CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DoctorLefbarComponent } from "../doctor-lefbar/doctor-lefbar.component";

@Component({
  selector: 'app-specialties',
  standalone: true,
  imports: [RouterModule, DoctorLefbarComponent],
  templateUrl: './specialties.component.html',
  styleUrl: './specialties.component.css',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SpecialtiesComponent {

}
