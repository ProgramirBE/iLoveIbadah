import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  fullName = signal('Guest');

  constructor() {}

  ngOnInit() {
    if (localStorage.getItem('fullName')) {
      this.fullName.set(localStorage.getItem('fullName') ?? 'Guest');
    }
  }
}
