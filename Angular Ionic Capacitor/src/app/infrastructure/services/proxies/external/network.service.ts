import { Injectable } from '@angular/core';
import { Network, ConnectionStatus } from '@capacitor/network';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NetworkService {
  private onlineSubject: BehaviorSubject<boolean> =
    new BehaviorSubject<boolean>(true);

  constructor() {
    this.initializeNetworkStatus();
  }

  private async initializeNetworkStatus() {
    const status = await Network.getStatus();
    this.updateOnlineStatus(status.connected);

    Network.addListener('networkStatusChange', (status: ConnectionStatus) => {
      this.updateOnlineStatus(status.connected);
    });
  }

  private updateOnlineStatus(isOnline: boolean) {
    this.onlineSubject.next(isOnline);
  }

  public get isOnline(): Observable<boolean> {
    return this.onlineSubject.asObservable();
  }
}
