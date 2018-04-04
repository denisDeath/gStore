import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GoodsIncomingListComponent } from './goods-incoming-list.component';

describe('GoodsIncomingListComponent', () => {
  let component: GoodsIncomingListComponent;
  let fixture: ComponentFixture<GoodsIncomingListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GoodsIncomingListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GoodsIncomingListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
