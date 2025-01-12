import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable, tap, throwError, pipe } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';
import { AuthHeaderService } from './shared/auth-header.service';
import { UserAccount } from 'src/app/domain/models/user-account';
// import { response } from 'express'; // Remove this line if not needed

@Injectable({
  providedIn: 'root',
})
export class UserAccountsService {
  constructor(private authHeaderService: AuthHeaderService) {}
  private http = inject(HttpClient);
  private apiUrl = environment.apiURL + '/useraccounts';

  public getById(): Observable<UserAccount> {
    const headers = this.authHeaderService.getAuthHeaders();
    return this.http
      .get<UserAccount>(`${this.apiUrl}/getbyid`, { headers })
      .pipe(map((response) => UserAccount.fromApiResponse(response)));
  }

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

  public login(credentials: {
    email: string;
    passwordHash: string;
  }): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, credentials).pipe(
      tap((response: any) => {
        localStorage.setItem('jwtToken', response.token);
        localStorage.setItem('userId', response.id);
        localStorage.setItem('uniqueId', response.uniqueId);
        localStorage.setItem('fullName', response.fullName);
        localStorage.setItem('email', response.email);
      }),
      catchError((error) => {
        // Handle the error and provide feedback
        console.error('Login failed', error);
        return throwError(() => new Error('Login failed'));
      })
    );
  }

  public register(user: {
    fullName: string;
    email: string;
    passwordHash: string;
  }): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/register`, user);
  }

  public isLoggedIn(): boolean {
    const token = localStorage.getItem('jwtToken');
    if (token === null) {
      return false;
      };
    return true;
    };
  // public isLoggedIn(): Observable<boolean> {
  //   const headers = this.authHeaderService.getAuthHeaders();
  //   return this.http
  //     .get<boolean>(`${this.apiUrl}/isLoggedIn`, { headers })
  //     .pipe(
  //       catchError((error) => {
  //         console.error('Failed to check login status', error);
  //         return throwError(() => new Error('Failed to check login status'));
  //       })
  //     );
  // }
}
