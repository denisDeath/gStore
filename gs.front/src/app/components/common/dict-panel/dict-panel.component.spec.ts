import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DictPanelComponent } from './dict-panel.component';

describe('DictPanelComponent', () => {
  let component: DictPanelComponent;
  let fixture: ComponentFixture<DictPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DictPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DictPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
