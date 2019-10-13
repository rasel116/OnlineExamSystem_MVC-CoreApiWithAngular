import { Component, OnInit } from '@angular/core';
import { SubjectService } from 'src/app/shared/subject.service';
import { Subject } from 'src/app/shared/subject.model';

@Component({
  selector: 'app-subject-list',
  templateUrl: './subject-list.component.html',
  styleUrls: ['./subject-list.component.css']
})
export class SubjectListComponent implements OnInit {

  constructor(private service: SubjectService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(sub: Subject) {
    this.service.formData = Object.assign({}, sub);
  }

  onDelete(id: number) {
    if (confirm('Are you sure?')) {
      this.service.deleteSubject(id).subscribe(res => {
        this.service.refreshList();
      });
    }
  }

}
