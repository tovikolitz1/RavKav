import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowTravelsComponent } from './show-travels.component';

describe('ShowTravelsComponent', () => {
  let component: ShowTravelsComponent;
  let fixture: ComponentFixture<ShowTravelsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShowTravelsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowTravelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
