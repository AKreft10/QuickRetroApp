import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RetrospectiveBoard, RetrospectiveColumn } from '../retrospective-template/retrospective-board-model';
import { CardContentDialogComponent } from '../retrospective-template/dialogs/card-content-dialog/card-content-dialog.component';
import { NoopScrollStrategy } from '@angular/cdk/overlay';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { EditCardDialogComponent } from '../retrospective-template/dialogs/edit-dialog/edit-dialog.component';
import { RetroService } from '../../services/retro.service';
import { AuthService } from '../../services/authservice.service';
import { ActivatedRoute } from '@angular/router';
import { Subscription, map } from 'rxjs';
import { RetroBoard, RetroBoardColumn, RetroBoardColumnItem } from './retrospective-board.interface';
import { AddCard } from '../../interfaces/addcard.interface';
import { MoveCard } from '../../interfaces/movecard.interface';

@Component({
  selector: 'app-retrospective-board',
  templateUrl: './retrospective-board.component.html',
  styleUrl: './retrospective-board.component.scss'
})
export class RetrospectiveBoardComponent implements OnInit, OnDestroy {
  private addSubsription: Subscription | undefined;
  private cardMovedSubscription: Subscription | undefined;
  backgroundUrl = 'https://img.freepik.com/free-photo/beautiful-aerial-shot-fronalpstock-mountains-switzerland-beautiful-pink-blue-sky_181624-9315.jpg?w=1800&t=st=1713660388~exp=1713660988~hmac=3eac2b800be6c8514e6b45ef6fafc2914237462fa6c49d920604268fae6e0c59';
  userNickname : string | undefined;
  retroId: string = '';
  constructor(public dialog : MatDialog, public retroService: RetroService, public authService: AuthService, private route: ActivatedRoute){}
  ngOnDestroy(): void {
    this.addSubsription?.unsubscribe();
  }
  ngOnInit(): void {

    this.retroId = this.route.snapshot.paramMap.get('id')!;

    this.retroService.createBoardConnection(this.retroId)
    
    this.retroService.getBoard(this.retroId).subscribe(data => {
      this.board = data.content!;
    })

    this.addSubsription = this.retroService.cardAdded$.subscribe({
      next: ({cardId, columnId, content}) => {
        const column = this.board.columns.find(c => c.id === columnId);

        if(column) {
          var columnItem : RetroBoardColumnItem = {
            id: cardId,
            textContent: content
          }

          column.items = [...column.items, columnItem]
        }
          
        else 
          console.error(`Can't find column by id ${columnId}`)
      }
    })

    this.cardMovedSubscription = this.retroService.cardMoved$.subscribe({
      next: ({cardId, movedTo}) => {
        const fromColumn = this.board.columns.find(c => 
          c.items.find(item => item.id === cardId)
        );
  
        const toColumn = this.board.columns.find(c => c.id === movedTo);
  
        if (fromColumn && toColumn) {
          const card = fromColumn.items.find(item => item.id === cardId);
          if (card) {
            fromColumn.items = fromColumn.items.filter(item => item.id !== cardId);
            toColumn.items = [...toColumn.items, card];
          }
        } else {
          console.error(`Cannot find columns with ids: from ${fromColumn?.id}, to ${movedTo}`);
        }
      },
      error: err => console.error('Error during card move:', err)
    });
  }

  public board: RetroBoard = {
    id: this.retroId,
    name: 'Jakisname',
    columns: [
      { name: '', id: '', items: [] },
      { name: '', id: '', items: [] },
      { name: '', id: '', items: [] },
      { name: '', id: '', items: [] },
      { name: '', id: '', items: [] },
      { name: '', id: '', items: [] }
    ]
  };

  openDialog(column: RetroBoardColumn): void {
    const dialogRef = this.dialog.open(CardContentDialogComponent, {
      width: '300px',
      data: { content: '' },
      scrollStrategy: new NoopScrollStrategy()
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.addCard(column, result);
      }
    });
  }

  addCard(column: RetroBoardColumn, cardContent: string): void {

    var addCard : AddCard = {
      columnId: column.id!,
      content: cardContent,
      boardId: this.retroId
    }

    this.retroService.addCard(addCard)
  }

  getConnectedListIds(): string[] {
    return this.board.columns.map(c => `cdk-drop-list-${c.id}`);
  }

  drop(event: CdkDragDrop<RetroBoardColumnItem[]>): void {
    console.log('drop');
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      const itemBeingMoved = event.previousContainer.data[event.previousIndex] as RetroBoardColumnItem;
    
    var moveCard : MoveCard = {
      boardId : this.retroId,
      cardId : itemBeingMoved.id,
      moveTo : event.container.id.replace('cdk-drop-list-', ''),
    }

    this.retroService.moveCard(moveCard);
    }
  }


  openEditDialog(column: RetroBoardColumn, card: string): void {
    const dialogRef = this.dialog.open(EditCardDialogComponent, {
      width: '300px',
      data: { content: card },
      scrollStrategy: new NoopScrollStrategy()
    });
  
    dialogRef.afterClosed().subscribe(result => {
      // if (result || result === '') {
      //   const cardIndex = column.items.indexOf();
      //   if (cardIndex !== -1) {
      //     column.cards[cardIndex] = result;
      //   }
      // }
    });
  }
}

