import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GoodCategoryEditComponent } from './good-category-edit.component';

describe('GoodCategoryEditComponent', () => {
  let component: GoodCategoryEditComponent;
  let fixture: ComponentFixture<GoodCategoryEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GoodCategoryEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GoodCategoryEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
