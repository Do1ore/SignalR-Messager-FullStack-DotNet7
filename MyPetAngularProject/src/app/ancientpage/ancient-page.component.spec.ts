import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AncientPageComponent } from './ancient-page.component';

describe('AncientpageComponent', () => {
  let component: AncientPageComponent;
  let fixture: ComponentFixture<AncientPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AncientPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AncientPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
