import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DhikrService {
  private apiUrl = 'api ibadah';

  constructor(private http: HttpClient) {}

  // Haal de counters op van de server
  getCounters(): Observable<{ onlineCounter: number; onlineTotalCounter: number }> {
    return this.http.get<{ onlineCounter: number; onlineTotalCounter: number }>(`${this.apiUrl}/counters`);
  }

  // Update de counter op de server
  updateCounter(amount: number): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/update-counter`, { amount });
  }
}
