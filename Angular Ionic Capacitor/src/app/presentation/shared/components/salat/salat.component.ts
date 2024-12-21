import { Component, OnInit } from '@angular/core';
import { SalatService } from './salat.service';

@Component({
  selector: 'app-salat',
  templateUrl: './salat.component.html',
  styleUrls: ['./salat.component.scss'],
})
export class SalatComponent implements OnInit {
  salatTimes: any = null;
  location: string = '';
  latitude: number | null = null;
  longitude: number | null = null;

  constructor(private salatService: SalatService) {}

  ngOnInit(): void {
    this.getLocationAndFetchTimes();
  }

  getLocationAndFetchTimes(): void {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          this.latitude = position.coords.latitude;
          this.longitude = position.coords.longitude;
          this.location = `${this.latitude.toFixed(2)}, ${this.longitude.toFixed(2)}`;
          this.fetchSalatTimes();
        },
        (error) => {
          console.error('Fout bij ophalen locatie:', error);
        }
      );
    } else {
      console.error('Geolocatie wordt niet ondersteund door deze browser.');
    }
  }

  fetchSalatTimes(): void {
    if (this.latitude !== null && this.longitude !== null) {
      this.salatService.getSalatTimes(this.latitude, this.longitude).subscribe({
        next: (data) => {
          console.log('Ontvangen data:', data);

          if (data.success && data.results) {
            // Extract de gebedstijden en verwijder "%"-tekens
            this.salatTimes = Object.fromEntries(
              Object.entries(data.results).map(([key, value]) => [
                key,
                (value as string).replace(/%/g, ''),
              ])
            );
          } else {
            console.error('Geen gebedstijden ontvangen.');
            this.salatTimes = null;
          }
        },
        error: (error) => {
          console.error('Fout bij ophalen gebedstijden:', error);
          this.salatTimes = null;
        },
      });
    }
  }
}
