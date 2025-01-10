import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable, tap, throwError, pipe } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';
import { AuthHeaderService } from './shared/auth-header.service';
import { UserSalahOverview } from 'src/app/domain/models/user-salah-overview';
// import { response } from 'express'; // Remove this line if not needed

@Injectable({
  providedIn: 'root',
})
export class UserSalahActivitiesService {
  constructor(private authHeaderService: AuthHeaderService) {}
  private http = inject(HttpClient);
  private apiUrl = environment.apiURL + '/usersalahactivities';

  // public getById(): Observable<any> {
  //   const headers = this.authHeaderService.getAuthHeaders();
  //   return this.http
  //     .get<any>(`${this.apiUrl}/getbyid`, { headers })
  //     .pipe(map((response) => UserAccount.fromApiResponse(response)));
  // }

  //--- for admin only so no impelementation needed for now
  // public getAll(): Observable<any[]> {
  //   const headers = this.authHeaderService.getAuthHeaders();
  //   return this.http
  //     .get<any[]>(this.apiUrl, { headers })
  //     .pipe(
  //       map((response) =>
  //         response.map((user) => UserAccount.fromApiResponse(user))
  //       )
  //     );
  // }

  public upsert(salahTypeId: number): Observable<any> {
    const headers = this.authHeaderService.getAuthHeaders();
    const requestBody = {
      userAccountId: null,
      salahTypeId: salahTypeId,
      performedOn: new Date().toISOString().split('T')[0], // Format to YYYY-MM-DD
      lastPerformedAt: new Date(),
    };
    return this.http.post<any>(`${this.apiUrl}/upsert`, requestBody, {
      headers,
    });
  }

  public getbyperformedon(
    performedOn: Date,
    salahTypeId: number
  ): Observable<any> {
    const headers = this.authHeaderService.getAuthHeaders();
    const formattedDate = performedOn.toISOString().split('T')[0]; // Format to YYYY-MM-DD
    const url = `${this.apiUrl}/getbyperformedon?performedOn=${formattedDate}&dhikrTypeId=${salahTypeId}`;
    return this.http.get<any>(url, { headers });
  }
}
