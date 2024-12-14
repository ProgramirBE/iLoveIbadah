import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  currentPageTitle: string = 'Home'; // Standaardpagina

  constructor(private router: Router) {}

  ngOnInit() {
    // Luister naar routewijzigingen
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event: any) => {
        // Werk de paginatitel bij op basis van de actieve route
        const url = event.urlAfterRedirects;

        if (url.includes('/home')) {
          this.currentPageTitle = 'Home';
        } else if (url.includes('/dhikr/home')) {
          this.currentPageTitle = 'Dhikr Home';
        } else if (url.includes('/dhikr')) {
          this.currentPageTitle = 'Dhikr';
        } else if (url.includes('/leaderboard')) {
          this.currentPageTitle = 'Leaderboard';
        } else if (url.includes('/login')) {
          this.currentPageTitle = 'Login';
        } else if (url.includes('/register')) {
          this.currentPageTitle = 'Register';
        } else {
          this.currentPageTitle = 'Ibadah Lover'; // Standaardtitel
        }
      });
  }
}
