import { Component, OnInit } from '@angular/core';
import { SubjectService } from 'src/app/shared/subject.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css']
})
export class SubjectComponent implements OnInit {

  constructor(private service: SubjectService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formData = {
      SubjectID: null,
      SubjectName: ''
    }
  }

  onSubmit(form: NgForm) {
    if (form.value.SubjectID == null) {
      this.insertRecord(form);
    }
    else {
      this.updateRecord(form);
    }
  }

  insertRecord(form: NgForm) {
    this.service.postSubject(form.value).subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
    });
  }

  updateRecord(form: NgForm) {
    this.service.putSubject(form.value).subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
    });
  }
}
