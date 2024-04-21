import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BackgroundService {
  private backgroundUrlSource = new Subject<string>();
  backgroundUrl$ = this.backgroundUrlSource.asObservable();

  setBackgroundUrl(url: string) {
    this.backgroundUrlSource.next(url);
  }
}