import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-set-background-dialog',
  templateUrl: './set-background-dialog.component.html',
  styleUrls: ['./set-background-dialog.component.scss']
})
export class SetBackgroundDialogComponent {
  backgroundUrl: string = '';

  constructor(
    public dialogRef: MatDialogRef<SetBackgroundDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
      this.backgroundUrl = data ? data.backgroundUrl : '';
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSaveClick(): void {
    this.dialogRef.close(this.backgroundUrl);
  }
}