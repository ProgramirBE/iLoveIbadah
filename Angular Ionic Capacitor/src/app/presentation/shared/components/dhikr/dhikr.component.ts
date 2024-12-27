import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DhikrService } from './dhikr.service';

@Component({
  selector: 'app-dhikr',
  templateUrl: './dhikr.component.html',
  styleUrls: ['./dhikr.component.scss'],
})
export class DhikrComponent implements OnInit {
  section: string = ''; // Huidige sectie
  counter: number = 0; // Lokale teller
  totalCounter: number = 0; // Lokale totale teller
  onlineCounter: number = 0; // Online teller
  onlineTotalCounter: number = 0; // Online totale teller
  buttonDisabled: boolean = false;
  words: string[] = ["Soubhan' Allah", "Alhamdulilah", "Allah u akbar"];
  currentWord: string = this.words[0];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dhikrService: DhikrService
  ) {}

  ngOnInit(): void {
    // Ophalen van de sectie uit de route
    this.route.data.subscribe((data) => {
      this.section = data['section'] || 'home';
    });

    // Ophalen van de lokale counters
    const savedCounter = localStorage.getItem('dhikrCounter');
    const savedTotalCounter = localStorage.getItem('dhikrTotalCounter');

    if (savedCounter) {
      this.counter = parseInt(savedCounter, 10);
    }

    if (savedTotalCounter) {
      this.totalCounter = parseInt(savedTotalCounter, 10);
    }

    // Ophalen van online counters
    this.dhikrService.getCounters().subscribe({
      next: (data) => {
        this.onlineCounter = data.onlineCounter;
        this.onlineTotalCounter = data.onlineTotalCounter;
      },
      error: (err) => {
        console.error('Error fetching online counters:', err);
      },
    });
  }

  onButtonClick(): void {
    this.counter++;
    this.totalCounter++;
    this.onlineCounter++;
    this.onlineTotalCounter++;

    // Lokale opslag bijwerken
    localStorage.setItem('dhikrCounter', this.counter.toString());
    localStorage.setItem('dhikrTotalCounter', this.totalCounter.toString());

    // Online teller bijwerken
    this.dhikrService.updateCounter(1).subscribe({
      next: () => {
        console.log('Online counter updated');
      },
      error: (err) => {
        console.error('Error updating online counter:', err);
      },
    });

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
