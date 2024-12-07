import { Component } from '@angular/core';

@Component({
  selector: 'app-dhikr1',
  templateUrl: './dhikr1.component.html',
  styleUrls: ['./dhikr1.component.scss'],
})
export class Dhikr1Component {
  counter: number = 0; // Initialiseer de teller op 0

  onButtonClick() {
    this.counter++; // Verhoog de teller met 1
  }
}
