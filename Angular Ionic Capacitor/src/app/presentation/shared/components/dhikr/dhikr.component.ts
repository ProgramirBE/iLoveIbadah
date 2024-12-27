import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NetworkService } from 'src/app/infrastructure/services/proxies/external/network.service';

@Component({
  selector: 'app-dhikr',
  templateUrl: './dhikr.component.html',
  styleUrls: ['./dhikr.component.scss'],
})
export class DhikrComponent implements OnInit {
  section: string = ''; // Huidige sectie
  counter: number = 0; // Huidige teller
  totalCounter: number = 0; // Totaal aantal klikken
  buttonDisabled: boolean = false;
  words: string[] = ["Soubhan' Allah", 'Alhamdulilah', 'Allah u akbar'];
  currentWord: string = this.words[0];
  isOnline: boolean = true;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private networkService: NetworkService
  ) {}

  ngOnInit(): void {
    // Ophalen van de sectie uit de route
    this.route.data.subscribe((data) => {
      this.section = data['section'] || 'home';
    });

    // Ophalen van de teller uit lokale opslag
    const savedCounter = localStorage.getItem('dhikrCounter');
    const savedTotalCounter = localStorage.getItem('dhikrTotalCounter');

    if (savedCounter) {
      this.counter = parseInt(savedCounter, 10);
    }

    if (savedTotalCounter) {
      this.totalCounter = parseInt(savedTotalCounter, 10);
    }

    // Subscribe to network status changes
    this.networkService.isOnline.subscribe((status) => {
      this.isOnline = status;
      console.log('Network status:', this.isOnline ? 'Online' : 'Offline');
    });
  }

  onButtonClick(): void {
    this.networkService.isOnline.subscribe((status) => {
      if (status) {
        
      } else {
        console.log('You are offline. Only in locastorage and not synced!');
        // Handle offline scenario (e.g., show a message to the user)
        this.counter++;
        this.totalCounter++;

        // Opslaan in de lokale opslag
        localStorage.setItem('dhikrCounter', this.counter.toString());
        localStorage.setItem('dhikrTotalCounter', this.totalCounter.toString());

        // Wissel woorden alleen voor algemene Dhikr
        if (this.section === 'dhikr') {
          const currentIndex = this.words.indexOf(this.currentWord);
          const nextIndex = (currentIndex + 1) % this.words.length;
          this.currentWord = this.words[nextIndex];
        }

        // Specifieke secties
        if (this.section === '1') {
          this.currentWord = "Soubhan' Allah";
        } else if (this.section === '2') {
          this.currentWord = 'Alhamdulilah';
        } else if (this.section === '3') {
          this.currentWord = 'Allah u akbar';
        }

        // Deactiveer de knop elke 99 klikken
        if (this.counter % 99 === 0) {
          this.buttonDisabled = true;
        }
      }
    });
  }

  onCheckboxToggle(): void {
    this.buttonDisabled = false;
  }

  // Methode om terug te navigeren en de pagina te refreshen
  goBack(): void {
    this.router.navigate(['/dhikr/home']).then(() => {
      window.location.reload();
    });
  }
}
