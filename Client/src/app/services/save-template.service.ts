import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { SaveTemplate } from '../interfaces/savetemplate.interface';
import { NotificationService } from './notification.service';
import { Result } from '../interfaces/result';
import { SavedTemplates } from '../interfaces/savedtemplates.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SaveTemplateService {

  constructor(private httpClient: HttpClient, private notifitactionService : NotificationService) { }


  sendSaveTemplateForm(saveTemplateData: SaveTemplate) {
    this.httpClient.post<Result<string>>(`${environment.apiUrl}/Templates/SaveTemplate`, saveTemplateData)
    .subscribe(data => {
      if(data.success) {
        this.notifitactionService.show(data.message, "Ok", 3000);
      }
      else {
        this.notifitactionService.show('Cant save template', 'Ok', 3000);
      }
    })
  }

  getSavedTemplates() : Observable<Result<SavedTemplates[]>> {
    return this.httpClient.get<Result<SavedTemplates[]>>(`${environment.apiUrl}/Templates/GetSavedTemplates`)
  }

}
