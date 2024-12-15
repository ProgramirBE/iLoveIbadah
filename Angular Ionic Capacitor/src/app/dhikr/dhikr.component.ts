import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-dhikr',
  templateUrl: './dhikr.component.html',
  styleUrls: ['./dhikr.component.scss'],
})
export class DhikrComponent implements OnInit {
  section: string = ''; // Huidige sectie (home, 1, 2, 3, dhikr)
  counter: number = 0;
  buttonDisabled: boolean = false;
  currentWord: string = ''; // Het huidige woord dat wordt weergegeven
  words: string[] = ["Soubhan' Allah", "Alhamdulilah", "Allah u akbar"]; // Woordenreeks

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Ophalen van de sectie uit de route
    this.route.data.subscribe((data) => {
      this.section = data['section'] || 'home';

      // Stel het juiste woord of gedrag in afhankelijk van de sectie
      if (this.section === 'dhikr') {
        this.currentWord = this.words[0]; // Start met het eerste woord voor algemene dhikr
      } else if (this.section === '1') {
        this.currentWord = "Soubhan' Allah"; // Specifiek woord voor Dhikr1
      } else if (this.section === '2') {
        this.currentWord = 'Alhamdulilah'; // Specifiek woord voor Dhikr2
      } else if (this.section === '3') {
        this.currentWord = 'Allah u akbar'; // Specifiek woord voor Dhikr3
      }
    });
  }

  onButtonClick(): void {
    this.counter++;

    // Woorden wisselen voor algemene Dhikr
    if (this.section === 'dhikr') {
      const currentIndex = this.words.indexOf(this.currentWord);
      const nextIndex = (currentIndex + 1) % this.words.length; // Circulaire rotatie
      this.currentWord = this.words[nextIndex];
    }

    // Deactiveer de knop elke 99 klikken
    if (this.counter % 99 === 0) {
      this.buttonDisabled = true;
    }
  }

  onCheckboxToggle(): void {
    this.buttonDisabled = false; // Reactiveren van de knop na checkbox
  }
}
