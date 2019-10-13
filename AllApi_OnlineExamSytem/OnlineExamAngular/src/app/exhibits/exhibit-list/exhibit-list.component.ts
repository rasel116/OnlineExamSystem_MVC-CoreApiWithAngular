import { Component, OnInit } from '@angular/core';
import { ExhibitService } from 'src/app/shared/exhibit.service';
import { Exhibit } from 'src/app/shared/exhibit.model';

@Component({
  selector: 'app-exhibit-list',
  templateUrl: './exhibit-list.component.html',
  styleUrls: ['./exhibit-list.component.css']
})
export class ExhibitListComponent implements OnInit {

  constructor(private service: ExhibitService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(sub: Exhibit) {
    this.service.formData = Object.assign({}, sub);
  }

  onDelete(id: number) {
    if (confirm('Are you sure?')) {
      this.service.deleteExh(id).subscribe(res => {
        this.service.refreshList();
      });
    }
  }

}
