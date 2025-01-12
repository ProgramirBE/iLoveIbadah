import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable, tap, throwError, pipe } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';
import { AuthHeaderService } from './shared/auth-header.service';
import { SalahType } from 'src/app/domain/models/salah-type';

@Injectable({
  providedIn: 'root',
})
export class SalahTypesService {
  constructor(private authHeaderService: AuthHeaderService) {}
  private http = inject(HttpClient);
  private apiUrl = environment.apiURL + '/salahtypes';

  public getAll(): Observable<SalahType[]> {
    return this.http.get<SalahType[]>(`${this.apiUrl}`).pipe(
      map((response) => {
        return response.map((salahType) =>
          SalahType.fromApiResponse(salahType)
        );
      }),
      catchError((error) => {
        console.error('Error fetching SalahTypes:', error);
        return throwError(() => new Error('Error fetching SalahTypes'));
      })
    );
  }
}
