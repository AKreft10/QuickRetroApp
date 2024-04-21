import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ColumnService {
  private columnCount = new BehaviorSubject<number>(3);

  currentColumnCount = this.columnCount.asObservable();

  constructor() { }

  changeColumnCount(count: number) {
    this.columnCount.next(count);
  }
}