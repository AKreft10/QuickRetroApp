import { Component, OnInit } from '@angular/core';
import { SaveTemplateService } from '../../services/save-template.service';
import { SavedTemplates } from '../../interfaces/savedtemplates.interface';
import { ImageListItem } from '../../interfaces/image-list-item';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnInit {

  savedTemplates : SavedTemplates[] = [];

  imageListItems: ImageListItem[] = [];

  constructor(private templateService: SaveTemplateService){}
  ngOnInit(): void {
    this.templateService.getSavedTemplates()
      .subscribe(data => {
        this.savedTemplates = data.content;
        this.mapImages();
      })
  }

  mapImages() {
    this.imageListItems = this.savedTemplates.map(template => ({
      src: template.backgroundUrl,
      caption: template.name
    }));
    console.log(this.imageListItems);
  }

  onImageListItemClick(imageListItem: ImageListItem) {
    
  }
}
