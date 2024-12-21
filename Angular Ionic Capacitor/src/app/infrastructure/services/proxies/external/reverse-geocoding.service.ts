import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReverseGeocodingService {
  private apiUrl = 'https://api.api-ninjas.com/v1/reversegeocoding';

  constructor(private http: HttpClient) { }

  getReverseGeocoding(lat: string, lon: string): Observable<any> {
    // Set up the headers with the API key
    const headers = new HttpHeaders().set('X-Api-Key', 'YOUR_API_KEY');

    // Make the GET request
    return this.http.get(`${this.apiUrl}?lat=${lat}&lon=${lon}`, { headers });
  }
}
