import { Component } from '@angular/core';

@Component({
  selector: 'app-dhikr',
  templateUrl: './dhikr.component.html',
  styleUrls: ['./dhikr.component.scss'],
})
export class DhikrComponent {
  counter: number = 0;
  words: string[] = ["Soubhan'Allah", "Allah u akbar", "Al hamdulilah"];
  currentWord: string = this.words[0]; // Start met het eerste woord

  onButtonClick(): void {
    // Verhoog de teller
    this.counter++;

    // Wissel het woord
    const currentIndex = this.words.indexOf(this.currentWord);
    const nextIndex = (currentIndex + 1) % this.words.length; // Circulaire rotatie
    this.currentWord = this.words[nextIndex];
  }
}
