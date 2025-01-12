import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable, tap, throwError, pipe } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';
import { AuthHeaderService } from './shared/auth-header.service';
import { UserSalahOverview } from 'src/app/domain/models/user-salah-overview';
import { UserSalahActivity } from 'src/app/domain/models/user-salah-activity';
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

  public upsert(salahTypeId: number, punctualityPercentage: number): Observable<any> {
    const headers = this.authHeaderService.getAuthHeaders();
    const requestBody = {
      userAccountId: null,
      salahTypeId: salahTypeId,
      trackedOn: new Date().toISOString().split('T')[0], // Format to YYYY-MM-DD
      punctualityPercentage: punctualityPercentage,
    };
    return this.http.post<any>(`${this.apiUrl}/upsert`, requestBody, {
      headers,
    });
  }

  public getTrackedOn(trackedOn: string): Observable<UserSalahActivity[]> {
    const headers = this.authHeaderService.getAuthHeaders();
    const formattedDate = trackedOn.toString().split('T')[0]; // Format to YYYY-MM-DD
    const url = `${this.apiUrl}/getallbytrackedon?trackedOn=${formattedDate}`;
    return this.http.get<UserSalahActivity[]>(url, { headers }).pipe(
      map((response) => {
        return response.map((userSalahActivity) =>
          UserSalahActivity.fromApiResponse(userSalahActivity)
        );
      }),
      catchError((error) => {
        console.error('Error fetching SalahActivities:', error);
        return throwError(() => new Error('Error fetching SalahActivities'));
      })
    );
  }
}
