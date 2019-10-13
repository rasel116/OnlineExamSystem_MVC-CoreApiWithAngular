import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { RoutegaurdService } from './routegaurd.service';
import { ContactusComponent } from './contactus/contactus.component';

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
import { RootComponent } from './root/root.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { AuthGuard } from './auth/auth.guard';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { SubjectsComponent } from './subjects/subjects.component';
import { ExhibitsComponent } from './exhibits/exhibits.component';
import { CategoriesComponent } from './categories/categories.component';
import { RegisterComponent } from './registerexam/register.component';
import { QuizComponent } from './quiz/quiz.component';
import { QuizquestionsComponent } from './quizquestions/quizquestions.component';
import { ResultComponent } from './result/result.component';



const routes: Routes = [
  { path: '', redirectTo: '/root', pathMatch: 'full' },
  { path: 'root', component: RootComponent },

  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', loadChildren: () => HomeModule },
  { path: 'login', component: SignInComponent },
  { path: 'sign-up', component: SignUpComponent },
  { path: 'root', component: RootComponent },
  { path: 'subject', component: SubjectsComponent, canActivate: [AuthGuard]},
  { path: 'category', component: CategoriesComponent, canActivate: [AuthGuard]},
  { path: 'exhibit', component: ExhibitsComponent, canActivate: [AuthGuard]},
  { path: 'QuizQuest', component: QuizquestionsComponent, canActivate: [AuthGuard]},
  { path: 'register', component: RegisterComponent, canActivate: [AuthGuard] },
  { path: 'quiz', component: QuizComponent},
  { path: 'result', component: ResultComponent},

  { path: 'contactus', component: ContactusComponent, outlet: 'popup'  },
  { path: 'about', loadChildren: () => AboutModule },
  { path: 'services', loadChildren: () => ServicesModule },
  { path: 'testimonials', loadChildren: () => TestimonialModule },
  { path: 'gallery', loadChildren: () => GalleryModule },
  { path: 'clients', loadChildren: () => ClientsModule },
  { path: 'pricing', loadChildren: () => PricingModule },
  { path: 'subscribe', component: SubscribeComponent, outlet: 'popup' },
  { path: 'dashboard', loadChildren: () => UserDashboardModule, canActivate: [AuthGuard]   },
  { path: 'blog', loadChildren: () => BlogModule, canActivate: [AuthGuard] },
  { path: '404', loadChildren: () => NotfoundModule },
  { path: '**', redirectTo: '/404' },
  { path: 'forbidden', component: ForbiddenComponent, canActivate: [AuthGuard] },
  { path: 'adminPanel', component: AdminPanelComponent, canActivate: [AuthGuard] , data: { roles: ['Admin'] }},
];


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  declarations: [],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
