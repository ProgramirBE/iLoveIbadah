import { Component } from '@angular/core';

@Component({
  selector: 'app-dhikr3',
  templateUrl: './dhikr3.component.html',
  styleUrls: ['./dhikr3.component.scss'],
})
export class Dhikr3Component {
  counter: number = 0; // Initialiseer de teller op 0

  onButtonClick() {
    this.counter++; // Verhoog de teller met 1
  }
}
