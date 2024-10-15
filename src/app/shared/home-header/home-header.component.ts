import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../../app.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home-header',
  standalone: true,
  imports: [AppComponent, RouterModule, CommonModule],
  templateUrl: './home-header.component.html',
  styleUrl: './home-header.component.css',
})
export class HomeHeaderComponent implements OnInit {
  userType: any;
  constructor() {}

  ngOnInit(): void {
    if (typeof window !== 'undefined' && window.sessionStorage) {
      this.userType = sessionStorage.getItem('userType');
      if (this.userType == null) {
        this.userType = 0;
      }
      console.log('userType ' + this.userType);
    }
  }
}
