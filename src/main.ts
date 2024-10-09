import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes';
import { provideRouter } from '@angular/router';

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes)  // Set up application-wide routing here
  ]
});
bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));
