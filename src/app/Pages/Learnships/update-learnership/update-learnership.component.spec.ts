import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateLearnershipComponent } from './update-learnership.component';

describe('UpdateLearnershipComponent', () => {
  let component: UpdateLearnershipComponent;
  let fixture: ComponentFixture<UpdateLearnershipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateLearnershipComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateLearnershipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
