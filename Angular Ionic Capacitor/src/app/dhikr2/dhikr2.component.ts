import { Component } from '@angular/core';

@Component({
  selector: 'app-dhikr2',
  templateUrl: './dhikr2.component.html',
  styleUrls: ['./dhikr2.component.scss'],
})
export class Dhikr2Component {
  counter: number = 0; // Initialiseer de teller op 0

  onButtonClick() {
    this.counter++; // Verhoog de teller met 1
  }
}
