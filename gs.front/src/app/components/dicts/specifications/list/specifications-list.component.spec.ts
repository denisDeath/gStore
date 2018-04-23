import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecificationsListComponent } from './specifications-list.component';

describe('SpecificationsListComponent', () => {
  let component: SpecificationsListComponent;
  let fixture: ComponentFixture<SpecificationsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpecificationsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpecificationsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
