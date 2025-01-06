import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class IslamicFinderService {
  constructor(private http: HttpClient) {}
  private apiUrl = 'https://www.islamicfinder.us/api/prayer_times';

  getSalatTimes(latitude: number, longitude: number): Observable<any> {
    const params = {
      latitude: latitude.toString(),
      longitude: longitude.toString(),
      timezone: Intl.DateTimeFormat().resolvedOptions().timeZone, // Automatisch timezone ophalen
    };
    return this.http.get(this.apiUrl, { params });
  }
}
