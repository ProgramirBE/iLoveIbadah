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
          console.log('Coördinaten ontvangen:', this.latitude, this.longitude);

          // Controleer op geldige coördinaten voordat je API-aanroepen doet
          if (this.latitude !== null && this.longitude !== null) {
            this.fetchSalatTimes();
            this.location = `${this.latitude.toFixed(2)}, ${this.longitude.toFixed(2)}`;
          }
        },
        (error) => {
          console.error('Fout bij ophalen van locatie:', error);
        }
      );
    } else {
      console.error('Geolocatie wordt niet ondersteund door deze browser.');
    }
  }

  fetchSalatTimes(): void {
    if (this.latitude !== null && this.longitude !== null) {
      this.salatService.getSalatTimes(this.latitude, this.longitude).subscribe(
        (data) => {
          console.log('Ontvangen gegevens:', data);
          if (data.success && data.data) {
            this.salatTimes = data.data;
          } else {
            console.error('Geen gebedstijden ontvangen.');
            this.salatTimes = null;
          }
        },
        (error) => {
          console.error('Fout bij ophalen van gebedstijden:', error);
          this.salatTimes = null;
        }
      );
    } else {
      console.error('Latitude en/of Longitude zijn niet beschikbaar.');
    }
  }
}
