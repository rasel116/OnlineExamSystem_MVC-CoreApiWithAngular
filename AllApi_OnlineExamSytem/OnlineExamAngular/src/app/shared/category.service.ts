import { Injectable } from '@angular/core';
import { Category } from './category.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  formData: Category;
  list: Category[];
  rootURL = localStorage.getItem("url")

  constructor(private http: HttpClient) { }

  postCategory(formData: Category) {
    return this.http.post(this.rootURL + '/QuestionCategory/InsertQuestionCategory', formData);
  }

  refreshList() {
    this.http.get(this.rootURL + '/QuestionCategory/GetQuestionCategory')
      .toPromise().then(res => this.list = res as Category[]);
  }

  putCategory(formData: Category) {
    return this.http.put(this.rootURL + '/QuestionCategory/UpdateQuestionCategory/' + formData.QuestionCategoryId, formData);
  }

  deleteCategory(id: number) {
    return this.http.delete(this.rootURL + '/QuestionCategory/DeleteQuestionCategory/' + id);
  }
}
