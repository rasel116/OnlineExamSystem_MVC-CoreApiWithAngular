import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class QuizService {

  //----------------------properties--------------------------------
  rootURL = localStorage.getItem("url")
  qns: any[];
  seconds: number;
  timer;
  qnProgress: number;
  correctAnswerCount: number = 0;


  constructor(private http: HttpClient) { }

  displayTimeElapsed() {
    return Math.floor(this.seconds / 3600) + ':' + Math.floor(this.seconds / 60) + ':' + Math.floor(this.seconds % 60);
  }

  getParticipantName() {
    var participant = JSON.parse(localStorage.getItem('participant'));
    return participant.Name;
  }

  //---------------------Http Method------------------------------


  insertParticipant(name: string, email: string) {
    var body = {
      Name: name,
      Email: email
    }
    return this.http.post(this.rootURL + '/InsertParticipant', body);
  }

  getQuestions() {
    return this.http.get(this.rootURL + '/QuizQuestions');
  }

  getAnswers() {
    var body = this.qns.map(x => x.QnID);
    return this.http.post(this.rootURL + '/Answers', body);
  }

  submitScore() {
    var body = JSON.parse(localStorage.getItem('participant'));
    body.Score = this.correctAnswerCount;
    body.TimeSpent = this.seconds;
    return this.http.post(this.rootURL + "/UpdateOutput", body);
  }
}
