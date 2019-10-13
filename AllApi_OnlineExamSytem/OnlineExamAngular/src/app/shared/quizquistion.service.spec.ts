import { TestBed, inject } from '@angular/core/testing';

import { QuizquistionService } from './quizquistion.service';

describe('QuizquistionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QuizquistionService]
    });
  });

  it('should be created', inject([QuizquistionService], (service: QuizquistionService) => {
    expect(service).toBeTruthy();
  }));
});
