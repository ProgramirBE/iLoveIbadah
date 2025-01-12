import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DhikrTypeService {
  private dhikrTypeIdSource = new BehaviorSubject<number | null>(null);
  dhikrTypeId$ = this.dhikrTypeIdSource.asObservable();
  private triggerSetCurrentWord = new BehaviorSubject<void>(undefined);

  triggerSetCurrentWord$ = this.triggerSetCurrentWord.asObservable();

  triggerSetCurrentWordMethod() {
    this.triggerSetCurrentWord.next();
  }
  setDhikrTypeId(id: number): void {
    this.dhikrTypeIdSource.next(id);
  }

  getDhikrTypeId(): number | null {
    return this.dhikrTypeIdSource.value;
  }
}
