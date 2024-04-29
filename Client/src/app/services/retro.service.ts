import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Result } from '../interfaces/result';
import { SaveTemplate } from '../interfaces/savetemplate.interface';
import { Router } from '@angular/router';
import { Observable, Subject, map } from 'rxjs';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import * as signalR from '@microsoft/signalr';
import { RetroBoard, RetrospectiveBoard } from '../features/retrospective-board/retrospective-board.interface';
import { AddCard } from '../interfaces/addcard.interface';
import { CardAddedEvent } from '../interfaces/cardadded.interface';
import { MoveCard } from '../interfaces/movecard.interface';
import { CardMovedEvent } from '../interfaces/cardmoved.interface';

@Injectable({
  providedIn: 'root'
})

export class RetroService {
  public cardAdded$ = new Subject<CardAddedEvent>();
  public cardMoved$ = new Subject<CardMovedEvent>();
  private boardConnection?: HubConnection;
  constructor(private http: HttpClient, private router: Router) { }

  startRetro(retroData: SaveTemplate) : Observable<Result<string>> {
    return this.http.post<Result<string>>(`${environment.apiUrl}/retro/Start`, retroData)
  }

  getBoard(id: string): Observable<Result<RetroBoard>> {
    return this.http.post<Result<RetroBoard>>(`${environment.apiUrl}/retro/GetBoard`, {id: id})
  }

  createBoardConnection(retroId : string) {
    this.boardConnection = new HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/hubs/retroboard`, {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      }).withAutomaticReconnect().build();

      this.boardConnection.start().catch(error => {
        console.log(error);
      })

      this.boardConnection.on('UserConnected', () => {
        this.boardConnection?.invoke('AddUserToGroup', retroId).catch(error => console.log(error))
      })

      this.boardConnection.on('CardAdded', (columnId, content, cardId) => {
        console.log(`user added card with content ${content}`)
        this.cardAdded$.next({columnId, content, cardId});
      });

      this.boardConnection.on('CardMoved', (cardId, movedTo) => {
        this.cardMoved$.next({cardId, movedTo});
      })
  }

  addCard(card : AddCard) {
    this.boardConnection?.invoke('AddCard', card)
  }

  stopBoardConnection() {
    this.boardConnection?.stop().catch(error => {
      console.log(error);
    })
  }

  moveCard(moveCard : MoveCard) {
    this.boardConnection?.invoke('MoveCard', moveCard);
  }

  private mapToRetrospectiveBoard(board: RetroBoard): RetrospectiveBoard {
    return {
      columns: board.columns.map(column => ({
        name: column.name,
        cards: column.items.map(item => item.textContent),
        id: column.id
      }))
    };
  }
}
