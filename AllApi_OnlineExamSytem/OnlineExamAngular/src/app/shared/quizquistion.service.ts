import { Injectable } from '@angular/core';
import { Quizquistion } from './quizquistion.model'
import { HttpClient } from '@angular/common/http';
import { Subject } from './subject.model';
import { Category } from './category.model';
import { Exhibit } from './exhibit.model';

@Injectable({
  providedIn: 'root'
})
export class QuizquistionService {

  formData: Quizquistion;
  list: Quizquistion[];
  listSub: Subject[];
  listCat: Category[];
  listExh: Exhibit[];
  rootURL = localStorage.getItem("url")

  constructor(private http: HttpClient) { }

  postQuizquistion(formData: Quizquistion) {
    return this.http.post(this.rootURL + '/QuizQuesMake/InsertQuizQuesMake', formData);
  }

  refreshList() {
    this.http.get(this.rootURL + '/QuizQuesMake/GetQuizQuesMake')
      .toPromise().then(res => this.list = res as Quizquistion[]);
  }

  putQuizquistion(formData: Quizquistion) {
    return this.http.put(this.rootURL + '/QuizQuesMake/UpdateQuizQuesMake/' + formData.SubjectID, formData);
  }

  deleteQuizquistion(id: number) {
    return this.http.delete(this.rootURL + '/QuizQuesMake/DeleteQuizQuesMake/' + id);
  }

  refreshSub() {
    this.http.get(this.rootURL + '/Subject/GetSubject')
      .toPromise().then(res => this.listSub = res as Subject[]);
  }

  refreshCat() {
    this.http.get(this.rootURL + '/QuestionCategory/GetQuestionCategory')
      .toPromise().then(res => this.listCat = res as Category[]);
  }

  refreshExh() {
    this.http.get(this.rootURL + '/Exhibit/GetExhibit')
      .toPromise().then(res => this.listExh = res as Exhibit[]);
  }
}
