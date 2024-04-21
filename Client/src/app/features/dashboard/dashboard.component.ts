import { Component, OnInit } from '@angular/core';
import { SaveTemplateService } from '../../services/save-template.service';
import { SavedTemplates } from '../../interfaces/savedtemplates.interface';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnInit {

  savedTemplates : SavedTemplates[] = [];

  constructor(private templateService: SaveTemplateService){}
  ngOnInit(): void {
    console.log("yoo");
    this.templateService.getSavedTemplates()
      .subscribe(data => {
        this.savedTemplates = data.content;
      })
  }
}
