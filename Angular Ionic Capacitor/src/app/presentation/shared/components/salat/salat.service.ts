import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SalatService {
  private apiUrl = 'https://www.islamicfinder.us/index.php/api/prayer_times'; // Proxy gebruikt

  constructor(private http: HttpClient) {}

  getSalatTimes(latitude: number, longitude: number): Observable<any> {
    const params = {
      latitude: latitude.toString(),
      longitude: longitude.toString(),
      timezone: Intl.DateTimeFormat().resolvedOptions().timeZone, // Automatisch timezone ophalen
    };
    return this.http.get(this.apiUrl, { params });
  }
}
