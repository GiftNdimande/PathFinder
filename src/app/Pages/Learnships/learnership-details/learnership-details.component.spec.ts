import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearnershipDetailsComponent } from './learnership-details.component';

describe('LearnershipDetailsComponent', () => {
  let component: LearnershipDetailsComponent;
  let fixture: ComponentFixture<LearnershipDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LearnershipDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LearnershipDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
