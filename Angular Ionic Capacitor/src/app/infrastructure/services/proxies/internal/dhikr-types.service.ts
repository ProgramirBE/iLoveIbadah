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

  public getAllByUserAccount(): Observable<DhikrType[]> {
    const headers = this.authHeaderService.getAuthHeaders();
    //I need to pass userAccountId to api but it gets replaced with the id extracted from the token! that's why I'm passing 0
    return this.http
      .get<DhikrType[]>(`${this.apiUrl}/getallbyuseraccount?userAccountId=0`, {
        headers,
      })
      .pipe(
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

  public create(
    fullName: string,
    arabicFullName?: string
  ): Observable<DhikrType> {
    const headers = this.authHeaderService.getAuthHeaders();
    const requestBody = {
      fullName: fullName,
      createdBy: 0,
      arabicFullName: '',
    };
    if (arabicFullName) {
      requestBody.arabicFullName = arabicFullName;
    }
    return this.http
      .post<DhikrType>(`${this.apiUrl}/create`, requestBody, {
        headers,
      })
      .pipe(
        map((response) => DhikrType.fromApiResponse(response)),
        catchError((error) => {
          console.error('Error creating DhikrType:', error);
          return throwError(() => new Error('Error creating DhikrType'));
        })
      );
  }
}
