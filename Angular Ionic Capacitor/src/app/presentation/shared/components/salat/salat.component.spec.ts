import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SalatComponent } from './salat.component';

describe('SalatComponent', () => {
  let component: SalatComponent;
  let fixture: ComponentFixture<SalatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SalatComponent],
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

  it('should set next prayer as Fajr after Isha', () => {
    component.filteredPrayers = [
      { name: 'Fajr', time: '7:03 AM' },
      { name: 'Dhuhr', time: '12:47 PM' },
      { name: 'Asr', time: '2:31 PM' },
      { name: 'Maghrib', time: '4:49 PM' },
      { name: 'Isha', time: '6:30 PM' },
    ];
    const mockTime = new Date();
    mockTime.setHours(22, 30, 0); // 10:30 PM
    jasmine.clock().mockDate(mockTime);

    component.setNextPrayer();

    expect(component.nextPrayerName).toEqual('Fajr');
    expect(component.currentPrayerName).toEqual('Isha');
  });
});
