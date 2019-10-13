import { Component, OnInit } from '@angular/core';
import { QuizquistionService } from 'src/app/shared/quizquistion.service';
import { Quizquistion } from 'src/app/shared/quizquistion.model';

@Component({
  selector: 'app-quizquestion-list',
  templateUrl: './quizquestion-list.component.html',
  styleUrls: ['./quizquestion-list.component.css']
})
export class QuizquestionListComponent implements OnInit {

  constructor(private service: QuizquistionService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(sub: Quizquistion) {
    this.service.formData = Object.assign({}, sub);
  }

  onDelete(id: number) {
    if (confirm('Are you sure?')) {
      this.service.deleteQuizquistion(id).subscribe(res => {
        this.service.refreshList();
      });
    }
  }

}
