import { RouterModule, Routes } from '@angular/router';
import { SignUpComponent } from './authentication/sign-up/sign-up.component';
import { MainPageComponent } from './home/main-page/main-page.component';
import { NgModule } from '@angular/core';
import { LogInComponent } from './authentication/log-in/log-in.component';
import { DashboardComponent } from './doctor/dashboard/dashboard.component';
import { PatientDashboardComponent } from './patient/patient-dashboard/patient-dashboard.component';
import { SpecialtiesComponent } from './doctor/specialties/specialties.component';

export const routes: Routes = [
    { path: '', component: MainPageComponent }, 
    { path: 'sign-up', component: SignUpComponent },
    { path: 'log-in', component: LogInComponent },  
    { path: 'doctor-dashboard', component: DashboardComponent },  
    { path: 'doctor-specialties', component: SpecialtiesComponent },  
    { path: 'patient-dashboard', component: PatientDashboardComponent },  

];
@NgModule({
    imports: [RouterModule],
    exports: [RouterModule]
  })
  export class AppRoutingModule {}
