import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  currentPageTitle: string = 'Home';

  constructor(private router: Router, private translate: TranslateService) {
    // Haal de opgeslagen taal op of stel standaard Engels in
    const savedLanguage = localStorage.getItem('language') || 'en';
    this.translate.setDefaultLang(savedLanguage);
    this.translate.use(savedLanguage);
  }

  ngOnInit() {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event: any) => {
        const url = event.urlAfterRedirects;

        // Werk de titel bij op basis van de huidige route
        if (url.includes('/home')) {
          this.currentPageTitle = this.translate.instant('HOME');
        } else if (url.includes('/dhikr')) {
          this.currentPageTitle = this.translate.instant('DHIKR');
        } else if (url.includes('/leaderboard')) {
          this.currentPageTitle = this.translate.instant('LEADERBOARD');
        } else if (url.includes('/login')) {
          this.currentPageTitle = this.translate.instant('LOGIN');
        } else if (url.includes('/register')) {
          this.currentPageTitle = this.translate.instant('REGISTER');
        } else if (url.includes('/salat')) {
          this.currentPageTitle = this.translate.instant('SALAT');
        } else if (url.includes('/profile')) {
          this.currentPageTitle = this.translate.instant('PROFILE');
        }
      });
  }

  // Functie om van taal te wisselen
  changeLanguage(lang: string): void {
    this.translate.use(lang); // Verander de taal
    localStorage.setItem('language', lang); // Sla de nieuwe taal op
    window.location.reload(); // Vernieuw de pagina om directe veranderingen te zien
  }
}
