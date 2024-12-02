import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  currentPageTitle: string = 'Home'; // Valeur par défaut

  constructor(private router: Router) {}

  ngOnInit() {
    // Écoutez les changements de route
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event: any) => {
        // Mettez à jour le titre en fonction de la route active
        const url = event.urlAfterRedirects;

        if (url.includes('/home')) {
          this.currentPageTitle = 'Home';
        } else if (url.includes('/dhikr')) {
          this.currentPageTitle = 'Dhikr';
        } else if (url.includes('/leaderboard')) {
          this.currentPageTitle = 'Leaderboard';
        }
      });
  }
}
