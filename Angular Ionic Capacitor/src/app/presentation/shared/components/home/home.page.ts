import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  username: string = 'Guest'; 

  constructor() {}

  setUsername(newUsername: string): void {
    this.username = newUsername;
  }
}
