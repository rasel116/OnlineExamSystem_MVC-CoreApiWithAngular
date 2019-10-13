import { Component, OnInit } from '@angular/core';
import { ExhibitService } from 'src/app/shared/exhibit.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-exhibit',
  templateUrl: './exhibit.component.html',
  styleUrls: ['./exhibit.component.css']
})
export class ExhibitComponent implements OnInit {

  constructor(private service: ExhibitService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formData = {
      ExhibitId: null,
      ExhibitData: ''
    }
  }

  onSubmit(form: NgForm) {
    if (form.value.QuestionCategoryId == null) {
      this.insertRecord(form);
    }
    else {
      this.updateRecord(form);
    }
  }

  insertRecord(form: NgForm) {
    this.service.postExh(form.value).subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
    });
  }

  updateRecord(form: NgForm) {
    this.service.putExh(form.value).subscribe(res => {
      this.resetForm(form);
      this.service.refreshList();
    });
  }

}
