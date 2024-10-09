import { Component } from '@angular/core';
import { RouterLink, RouterModule, RouterOutlet } from '@angular/router';
import { MainPageComponent } from './home/main-page/main-page.component';
import { HomeHeaderComponent } from './shared/home-header/home-header.component';
import { HomeFooterComponent } from './shared/home-footer/home-footer.component';
import { AppRoutingModule, routes } from './app.routes';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterModule, 
    MainPageComponent,HomeHeaderComponent, HomeFooterComponent, 
    RouterLink,RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Rao Clinic';
}
