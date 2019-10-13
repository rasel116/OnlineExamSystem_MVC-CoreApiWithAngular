import { Injectable } from '@angular/core';
import { Subject } from './subject.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  formData: Subject;
  list: Subject[];
  rootURL = localStorage.getItem("url")

  constructor(private http: HttpClient) { }

  postSubject(formData: Subject) {
    return this.http.post(this.rootURL + '/Subject/InsertSubject', formData);
  }

  refreshList() {
    this.http.get(this.rootURL + '/Subject/GetSubject')
      .toPromise().then(res => this.list = res as Subject[]);
  }

  putSubject(formData: Subject) {
    return this.http.put(this.rootURL + '/Subject/UpdateSubject/' + formData.SubjectID, formData);
  }

  deleteSubject(id: number) {
    return this.http.delete(this.rootURL + '/Subject/DeleteSubject/' + id);
  }
}
