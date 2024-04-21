import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ColumnService } from '../../../../services/column-service.service';

@Component({
  selector: 'app-set-columns-dialog',
  templateUrl: './set-columns-dialog.component.html'
})
export class SetColumnsDialogComponent {
  columnCount: number = 4;

  constructor(
    public dialogRef: MatDialogRef<SetColumnsDialogComponent>,
    private columnService: ColumnService
  ) {}

  onChange() {
    this.columnService.changeColumnCount(this.columnCount);
  }

  closeDialog() {
    this.dialogRef.close();
  }
}