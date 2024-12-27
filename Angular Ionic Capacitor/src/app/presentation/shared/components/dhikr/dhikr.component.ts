import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { DhikrService } from './dhikr.service'; // Import de service

import { NetworkService } from 'src/app/infrastructure/services/proxies/external/network.service';


@Component({
  selector: 'app-dhikr',
  templateUrl: './dhikr.component.html',
  styleUrls: ['./dhikr.component.scss'],
})
export class DhikrComponent implements OnInit {
  section: string = ''; // Huidige sectie
  counter: number = 0; // Lokale teller
  totalCounter: number = 0; // Lokale totaal teller
  onlineCounter: number = 0; // Online teller
  onlineTotalCounter: number = 0; // Online totaal teller
  buttonDisabled: boolean = false;
  words: string[] = ["Soubhan' Allah", 'Alhamdulilah', 'Allah u akbar'];
  currentWord: string = this.words[0];
  isOnline: boolean = true;

  constructor(
    private route: ActivatedRoute,
    private router: Router,

    private dhikrService: DhikrService // Inject de service

    private networkService: NetworkService

  ) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.section = data['section'] || 'home';
    });

    this.loadLocalCounters();
    this.loadOnlineCounters(); // Haal online counters op
  }

  private loadLocalCounters(): void {
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

  private loadOnlineCounters(): void {
    this.dhikrService.getCounters().subscribe({
      next: (data) => {
        this.onlineCounter = data.onlineCounter;
        this.onlineTotalCounter = data.onlineTotalCounter;
      },
      error: (err) => {
        console.error('Fout bij ophalen online counters:', err);
        // Mock data als fallback
        this.onlineCounter = 0;
        this.onlineTotalCounter = 0;
      },
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

    // Update lokaal opgeslagen data
    localStorage.setItem('dhikrCounter', this.counter.toString());
    localStorage.setItem('dhikrTotalCounter', this.totalCounter.toString());

    // Update online counters
    this.dhikrService.updateCounter(1).subscribe({
      next: () => {
        this.onlineCounter++;
        this.onlineTotalCounter++;
      },
      error: (err) => {
        console.error('Fout bij updaten online counter:', err);
      },
    });

    // Wissel woorden alleen voor algemene Dhikr
    if (this.section === 'dhikr') {
      const currentIndex = this.words.indexOf(this.currentWord);
      this.currentWord = this.words[(currentIndex + 1) % this.words.length];
    }

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

  goBack(): void {
    this.router.navigate(['/dhikr/home']).then(() => {
      window.location.reload();
    });
  }
}
