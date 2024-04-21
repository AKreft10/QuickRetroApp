import { Component, OnDestroy } from '@angular/core';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { RetrospectiveBoard, RetrospectiveColumn } from './retrospective-board-model';
import { MatDialog } from '@angular/material/dialog';
import { CardContentDialogComponent } from './dialogs/card-content-dialog/card-content-dialog.component';
import { NoopScrollStrategy } from '@angular/cdk/overlay';
import { EditCardDialogComponent } from './dialogs/edit-dialog/edit-dialog.component';
import { BackgroundService } from '../../services/background.service';
import { Subscription } from 'rxjs';
import { SaveTemplate } from '../../interfaces/savetemplate.interface';

@Component({
  selector: 'app-retrospective-board',
  templateUrl: './retrospective-board.component.html',
  styleUrls: ['./retrospective-board.component.scss']
})
export class RetrospectiveBoardComponent implements OnDestroy {
  private subscription: Subscription;
  backgroundUrl = 'https://img.freepik.com/free-photo/beautiful-aerial-shot-fronalpstock-mountains-switzerland-beautiful-pink-blue-sky_181624-9315.jpg?w=1800&t=st=1713660388~exp=1713660988~hmac=3eac2b800be6c8514e6b45ef6fafc2914237462fa6c49d920604268fae6e0c59';
  constructor(public dialog : MatDialog, private backgroundService: BackgroundService) {
    this.subscription = this.backgroundService.backgroundUrl$.subscribe(url => {
      this.backgroundUrl = url;
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  openDialog(column: RetrospectiveColumn): void {
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
  
  board: RetrospectiveBoard = {
    columns: [
      { name: 'Start', cards: ['Example 1', 'Example 2', 'Example 2', 'Example 2', 'Example 2', 'Example 2', 'Example 2', 'Example 2', 'Example 2', 'Example 2', 'Example 2'] },
      { name: 'Stop', cards: ['Example 3'] },
      { name: 'Continue', cards: [] },
      { name: 'Less of', cards: [] },
      { name: 'More of', cards: [] },
      { name: 'More xc', cards: [] }
    ]
  };

  getTemplate() : SaveTemplate {
    var templateData : SaveTemplate = {
      name: "dasdasd34",
      columns: this.board.columns.map(column => column.name),
      bacgroundUrl: this.backgroundUrl
    }

    return templateData;
  }

  addCard(column: RetrospectiveColumn, cardContent: string): void {
    column.cards.push(cardContent);
  }

  drop(event: CdkDragDrop<string[]>): void {
    console.log('drop');
    if (event.previousContainer === event.container) {
      console.log(event.previousContainer)
      console.log(event.container)
      console.log('sd')
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );
    }
  }

  editColumnName(column: RetrospectiveColumn, newName: string): void {
    column.name = newName;
  }

  getConnectedListIds(): string[] {
    return this.board.columns.map(c => `cdk-drop-list-${c.name}`);
  }

  openEditDialog(column: RetrospectiveColumn, card: string): void {
    const dialogRef = this.dialog.open(EditCardDialogComponent, {
      width: '300px',
      data: { content: card },
      scrollStrategy: new NoopScrollStrategy()
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result || result === '') {
        const cardIndex = column.cards.indexOf(card);
        if (cardIndex !== -1) {
          column.cards[cardIndex] = result;
        }
      }
    });
  }
  
  deleteCard(column: RetrospectiveColumn, cardContent: string) {
    const index = column.cards.indexOf(cardContent);
    if (index > -1) {
      column.cards.splice(index, 1);
    }
  }
}