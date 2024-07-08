import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLearnershipComponent } from './add-learnership.component';

describe('AddLearnershipComponent', () => {
  let component: AddLearnershipComponent;
  let fixture: ComponentFixture<AddLearnershipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddLearnershipComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddLearnershipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
