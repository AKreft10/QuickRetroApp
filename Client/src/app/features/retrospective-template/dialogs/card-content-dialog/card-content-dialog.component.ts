import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-card-content-dialog',
  templateUrl: './card-content-dialog.component.html',
  styleUrl: './card-content-dialog.component.scss'
})
export class CardContentDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<CardContentDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}