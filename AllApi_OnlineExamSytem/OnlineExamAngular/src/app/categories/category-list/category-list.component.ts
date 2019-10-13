import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/shared/category.service';
import { Category } from 'src/app/shared/category.model';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  constructor(private service: CategoryService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(sub: Category) {
    this.service.formData = Object.assign({}, sub);
  }

  onDelete(id: number) {
    if (confirm('Are you sure?')) {
      this.service.deleteCategory(id).subscribe(res => {
        this.service.refreshList();
      });
    }
  }

}
