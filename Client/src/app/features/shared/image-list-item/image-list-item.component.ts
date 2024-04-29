import {
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { ImageListItem } from '../../../interfaces/image-list-item';


@Component({
  selector: 'app-image-list-item',
  templateUrl: './image-list-item.component.html',
  styleUrls: ['./image-list-item.component.scss']
})
export class ImageListItemComponent {
  @Input()
  image?: ImageListItem;

  @Output()
  click = new EventEmitter<void>();

  onImageListItemClick() {
    this.click.emit();
  }
}
