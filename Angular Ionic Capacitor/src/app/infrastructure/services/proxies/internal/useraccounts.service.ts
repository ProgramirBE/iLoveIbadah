import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable, tap, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment.prod';
import { AuthHeaderService } from './shared/auth-header.service';
// import { response } from 'express'; // Remove this line if not needed

@Injectable({
  providedIn: 'root',
})
export class UseraccountsService {
  constructor(private authHeaderService: AuthHeaderService) {}
  private http = inject(HttpClient);
  private apiUrl = environment.apiURL + '/useraccounts';

  public getById(id: string): Observable<any> {
    const headers = this.authHeaderService.getAuthHeaders();
    return this.http.get<any>(`${this.apiUrl}/${id}`, { headers });
  }

  public getAll(): Observable<any[]> {
    const headers = this.authHeaderService.getAuthHeaders();
    return this.http.get<any[]>(this.apiUrl, { headers });
  }

  public login(credentials: {
    username: string;
    password: string;
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
    username: string;
    password: string;
    email: string;
  }): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/register`, user);
  }
}
