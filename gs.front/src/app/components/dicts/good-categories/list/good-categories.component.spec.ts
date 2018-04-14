import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GoodCategoriesComponent } from './good-categories.component';

describe('GoodCategoriesComponent', () => {
  let component: GoodCategoriesComponent;
  let fixture: ComponentFixture<GoodCategoriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GoodCategoriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GoodCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
