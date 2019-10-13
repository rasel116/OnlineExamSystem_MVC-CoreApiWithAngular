import { Injectable } from '@angular/core';
import { Exhibit } from './exhibit.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ExhibitService {

  formData: Exhibit;
  list: Exhibit[];
  rootURL = localStorage.getItem("url")

  constructor(private http: HttpClient) { }

  postExh(formData: Exhibit) {
    return this.http.post(this.rootURL + '/Exhibit/InsertExhibit', formData);
  }

  refreshList() {
    this.http.get(this.rootURL + '/Exhibit/GetExhibit')
      .toPromise().then(res => this.list = res as Exhibit[]);
  }

  putExh(formData: Exhibit) {
    return this.http.put(this.rootURL + '/Exhibit/UpdateExhibit/' + formData.ExhibitId, formData);
  }

  deleteExh(id: number) {
    return this.http.delete(this.rootURL + '/Exhibit/DeleteExhibit/' + id);
  }
}
