import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable, tap, throwError, pipe } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';
import { AuthHeaderService } from './shared/auth-header.service';
import { UserDhikrOverview } from 'src/app/domain/models/user-dhikr-overview';

@Injectable({
  providedIn: 'root',
})
export class UserDhikrOverviewsService {
  constructor(private authHeaderService: AuthHeaderService) {}
  private http = inject(HttpClient);
  private apiUrl = environment.apiURL + '/userdhikroverviews';

  public getByUserAccount(): Observable<UserDhikrOverview> {
      const headers = this.authHeaderService.getAuthHeaders();
      return this.http
        .get<UserDhikrOverview>(`${this.apiUrl}/getbyuseraccount`, { headers })
        .pipe(map((response) => UserDhikrOverview.fromApiResponse(response)));
  }
}
