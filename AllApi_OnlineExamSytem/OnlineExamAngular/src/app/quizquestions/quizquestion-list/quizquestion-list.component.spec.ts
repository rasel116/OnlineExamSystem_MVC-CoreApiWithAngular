import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizquestionListComponent } from './quizquestion-list.component';

describe('QuizquestionListComponent', () => {
  let component: QuizquestionListComponent;
  let fixture: ComponentFixture<QuizquestionListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuizquestionListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizquestionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
