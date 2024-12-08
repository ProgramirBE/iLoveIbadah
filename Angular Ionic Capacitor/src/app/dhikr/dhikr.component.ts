import { Component } from '@angular/core';

@Component({
  selector: 'app-dhikr',
  templateUrl: './dhikr.component.html',
  styleUrls: ['./dhikr.component.scss'],
})
export class DhikrComponent {
  counter: number = 0;
  words: string[] = ["Soubhan'Allah", "Allah u akbar", "Al hamdulilah"];
  currentWord: string = this.words[0];
  buttonDisabled: boolean = false; // Status van de knop
  finalText: string = '';

  onButtonClick(): void {
    this.counter++;

    // Controleer of de counter een veelvoud van 99 is
    if (this.counter % 99 === 0) {
      this.buttonDisabled = true; // Schakel de knop uit
      this.finalText =
        'Lè ilèhè illa Al-lahoe oe-ahdahoe lè shèrika lèhoe, Lèhoel molkoe oe-è lèhoel hamdoe, oe-è hoewa ‘âla koel-li sjee‘in Qadier.';
    } else {
      const currentIndex = this.words.indexOf(this.currentWord);
      const nextIndex = (currentIndex + 1) % this.words.length; // Circulaire rotatie
      this.currentWord = this.words[nextIndex];
    }
  }

  onCheckboxChange(event: any): void {
    if (event.target.checked) {
      this.buttonDisabled = false; // Activeer de knop opnieuw
      this.finalText = ''; // Verwijder de tekst
    }
  }
}
