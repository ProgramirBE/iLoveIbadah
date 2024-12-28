import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable, tap, throwError, pipe } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';
import { AuthHeaderService } from './shared/auth-header.service';
import { DhikrType } from 'src/app/domain/models/dhikr-type';

@Injectable({
  providedIn: 'root',
})
export class DhikrTypesService {
  constructor(private authHeaderService: AuthHeaderService) {}
  private http = inject(HttpClient);
  private apiUrl = environment.apiURL + '/dhikrtypes';

  public getAll(): Observable<DhikrType[]> {
    return this.http.get<DhikrType[]>(`${this.apiUrl}`).pipe(
      map((response) => {
        return response.map((dhikrType) =>
          DhikrType.fromApiResponse(dhikrType)
        );
      }),
      catchError((error) => {
        console.error('Error fetching DhikrTypes:', error);
        return throwError(() => new Error('Error fetching DhikrTypes'));
      })
    );
  }
}
