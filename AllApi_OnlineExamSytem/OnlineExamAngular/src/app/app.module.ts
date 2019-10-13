import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { SocialComponent } from './social/social.component';


import { FooterComponent } from './footer/footer.component';

import { AppRoutingModule } from './/app-routing.module';
import { ConfigService } from './config.service';
import { ContactusComponent } from './contactus/contactus.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './in-memory-data.service';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown';
import { NavmenuComponent } from './navmenu/navmenu.component';
import { UserDashboardModule } from './user-dashboard/user-dashboard.module';
import { SubscribeComponent } from './subscribe/subscribe.component';
import { HomeModule } from './home/home.module';
import { AboutModule } from './about/about.module';
import { ServicesModule } from './services/services.module';
import { GalleryModule } from './gallery/gallery.module';
import { NotfoundModule } from './notfound/notfound.module';
import { ClientsModule } from './clients/clients.module';
import { TestimonialModule } from './testimonial/testimonial.module';
import { PricingModule } from './pricing/pricing.module';
import { BlogModule } from './blog/blog.module';
import { WebsiteBlockComponent } from './website-block/website-block.component';
import { ToastrModule } from 'ngx-toastr';
import { UserService } from './shared/user.service';
import { RootComponent } from './root/root.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { AuthGuard } from './auth/auth.guard';
import { RouterModule } from '@angular/router';
import { AuthInterceptor } from './auth/auth.interceptor';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { SubjectComponent } from './subjects/subject/subject.component';
import { SubjectsComponent } from './subjects/subjects.component';
import { CategoriesComponent } from './categories/categories.component';
import { ExhibitsComponent } from './exhibits/exhibits.component';
import { QuizquestionsComponent } from './quizquestions/quizquestions.component';
import { RegisterComponent } from './registerexam/register.component';
import { QuizComponent } from './quiz/quiz.component';
import { ResultComponent } from './result/result.component';
import { SubjectService } from './shared/subject.service';
import { QuizService } from './shared/quiz.service';
import { QuizquistionService } from './shared/quizquistion.service';
import { CategoryService } from './shared/category.service';
import { ExhibitService } from './shared/exhibit.service';
import { SubjectListComponent } from './subjects/subject-list/subject-list.component';
import { NavbarComponent } from './navbar/navbar.component';
import { QuizquestionComponent } from './quizquestions/quizquestion/quizquestion.component';
import { CategoryComponent } from './categories/category/category.component';
import { CategoryListComponent } from './categories/category-list/category-list.component';
import { ExhibitComponent } from './exhibits/exhibit/exhibit.component';
import { ExhibitListComponent } from './exhibits/exhibit-list/exhibit-list.component';
import { QuizquestionListComponent } from './quizquestions/quizquestion-list/quizquestion-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    SocialComponent,
    FooterComponent,
    SignInComponent,
    SignUpComponent,
    ContactusComponent,
    NavmenuComponent,
    SubscribeComponent,
    WebsiteBlockComponent,
    RootComponent,
    AdminPanelComponent,
    ForbiddenComponent,
    AppComponent,
 
    RootComponent,
    SubjectsComponent,
    SubjectComponent,
    SubjectListComponent,
    RegisterComponent,
    NavbarComponent,
    QuizComponent,
    ResultComponent,
    QuizquestionsComponent,
    QuizquestionComponent,
    QuizquestionListComponent,
    CategoriesComponent,
    CategoryComponent,
    CategoryListComponent,
    ExhibitsComponent,
    ExhibitComponent,
    ExhibitListComponent
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    HomeModule,
    AboutModule,
    ServicesModule,
    GalleryModule,
    UserDashboardModule,
    NotfoundModule,
    ClientsModule,
    TestimonialModule,
    ToastrModule.forRoot(),
    PricingModule,
    BlogModule,
    FormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
   
// The HttpClientInMemoryWebApiModule module intercepts HTTP requests
// and returns simulated server responses.
// Remove it when a real server is ready to receive requests.
HttpClientInMemoryWebApiModule.forRoot(
  InMemoryDataService, { dataEncapsulation: false,
  passThruUnknownUrl: true }
)
  ],
  providers: [ConfigService, UserService, AuthGuard,SubjectService, 
    QuizService, 
    AuthGuard, 
    QuizquistionService, 
    CategoryService,
    ExhibitService],
  bootstrap: [AppComponent]
})
export class AppModule { }
