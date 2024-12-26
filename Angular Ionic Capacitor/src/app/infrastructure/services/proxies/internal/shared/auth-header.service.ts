import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthHeaderService {
  constructor() {}

  public getAuthHeaders(): HttpHeaders {
    const token = localStorage.getItem('jwtToken'); // Adjust this to your token storage method
    return new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });
  }
}
