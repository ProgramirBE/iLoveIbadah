import { Component } from '@angular/core';

@Component({
  selector: 'app-dhikr',
  templateUrl: './dhikr.component.html',
  styleUrls: ['./dhikr.component.scss'],
})
export class DhikrComponent {
  counter: number = 0;

  incrementCounter(dhikrType: string) {
    this.counter++;
    console.log(`${dhikrType} clicked! Counter: ${this.counter}`);
  }
}
