import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SalatComponent } from './salat.component';

describe('SalatComponent', () => {
  let component: SalatComponent;
  let fixture: ComponentFixture<SalatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SalatComponent]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SalatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
