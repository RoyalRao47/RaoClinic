import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorLefbarComponent } from './doctor-lefbar.component';

describe('DoctorLefbarComponent', () => {
  let component: DoctorLefbarComponent;
  let fixture: ComponentFixture<DoctorLefbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DoctorLefbarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DoctorLefbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
