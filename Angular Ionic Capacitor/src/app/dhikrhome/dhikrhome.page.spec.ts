import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DhikrhomePage } from './dhikrhome.page';

describe('DhikrhomePage', () => {
  let component: DhikrhomePage;
  let fixture: ComponentFixture<DhikrhomePage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(DhikrhomePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
