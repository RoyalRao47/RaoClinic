import { RouterModule, Routes } from '@angular/router';
import { SignUpComponent } from './authentication/sign-up/sign-up.component';
import { MainPageComponent } from './home/main-page/main-page.component';
import { NgModule } from '@angular/core';

export const routes: Routes = [
    { path: '', component: MainPageComponent }, 
    { path: 'sign-up', component: SignUpComponent }  
];
@NgModule({
    imports: [RouterModule],
    exports: [RouterModule]
  })
  export class AppRoutingModule {}
