import { Component, OnInit } from '@angular/core';
import { QuizquistionService } from 'src/app/shared/quizquistion.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-quizquestion',
  templateUrl: './quizquestion.component.html',
  styleUrls: ['./quizquestion.component.css']
})
export class QuizquestionComponent implements OnInit {

  constructor(private service: QuizquistionService) { }

  ngOnInit() {
    this.resetForm();
    this.service.refreshSub();
    this.service.refreshCat();
    this.service.refreshExh();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formData = {
      QuizQuestionID: null,
      SubjectID: null,
      QuestionCategoryId: null,
      ExhibitId: null,
      Qn: '',
      Option1: '',
      Option2: '',
      Option3: '',
      Option4: '',
      Answer: null
    }
  }

  onSubmit(form: NgForm) {
    if (form.value.QuizQuestionID == null) {
      this.insertRecord(form);
    }
    else {
      this.updateRecord(form);
    }
  }

  insertRecord(form: NgForm) {
    this.service.postQuizquistion(form.value).subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
    });
  }

  updateRecord(form: NgForm) {
    this.service.putQuizquistion(form.value).subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
    });
  }

}
