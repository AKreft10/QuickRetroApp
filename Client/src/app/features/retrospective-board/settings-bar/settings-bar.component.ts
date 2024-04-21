import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ColumnService } from '../../../services/column-service.service';
import { SetColumnsDialogComponent } from '../dialogs/set-columns-dialog/set-columns-dialog.component';
import { SetBackgroundDialogComponent } from '../dialogs/set-background-dialog/set-background-dialog.component';
import { NoopScrollStrategy } from '@angular/cdk/overlay';
import { BackgroundService } from '../../../services/background.service';
import { SaveTemplate } from '../../../interfaces/savetemplate.interface';
import { SaveTemplateService } from '../../../services/save-template.service';

@Component({
  selector: 'app-settings-bar',
  templateUrl: './settings-bar.component.html',
  styleUrl: './settings-bar.component.scss'
})
export class SettingsBarComponent {
  @Input() getTemplate: (() => SaveTemplate) | undefined;

  constructor(public dialog: MatDialog, private columnService: ColumnService, private backgroundService: BackgroundService, private saveTemplateService : SaveTemplateService) {
    this.columnService.currentColumnCount.subscribe(count => {
      console.log('Aktualna liczba kolumn:', count);
    });
  }

  openSetColumnsDialog() {
    const dialogRef = this.dialog.open(SetColumnsDialogComponent, {
      width: '300px',
      scrollStrategy: new NoopScrollStrategy()
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('Dialog został zamknięty');
    });
  }

  openSetBackgroundDialog() {
    const dialogRef = this.dialog.open(SetBackgroundDialogComponent, {
      width: '300px',
      scrollStrategy: new NoopScrollStrategy()
    });

    dialogRef.afterClosed().subscribe(backgroundUrl => {
      if (backgroundUrl) {
        this.backgroundService.setBackgroundUrl(backgroundUrl);
      }
    });
  }

  saveTemplate() : void {
    if(this.getTemplate) {
      this.saveTemplateService.sendSaveTemplateForm(this.getTemplate())
    }
  }
}
