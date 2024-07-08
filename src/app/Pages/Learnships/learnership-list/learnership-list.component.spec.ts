import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LearnershipListComponent } from './learnership-list.component';

describe('LearnershipListComponent', () => {
  let component: LearnershipListComponent;
  let fixture: ComponentFixture<LearnershipListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LearnershipListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LearnershipListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
