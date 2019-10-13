import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.css']
})
export class RootComponent implements OnInit {

  constructor(private routes: Router) { }

  ngOnInit() {

  }

  UseMvc() {
    this.routes.navigate(['/home']);
    sessionStorage.setItem("url", "http://localhost:51343/api");
    sessionStorage.setItem("home", "Yes");
    localStorage.setItem("url", "http://localhost:51343/api");
    window.location.href = "http://localhost:4200/home";

  }

  UseCore() {
    this.routes.navigate(['/home']);
    sessionStorage.setItem("home", "Yes");
    sessionStorage.setItem("url", "http://localhost:50382/api");
    localStorage.setItem("url", "http://localhost:50382/api");
    window.location.href = "http://localhost:4200/home";
  }

}
