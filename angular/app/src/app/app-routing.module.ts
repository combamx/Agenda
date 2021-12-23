import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//Importar mis componentes
import { HomeComponent } from './home/home.component';
import { ActivityComponent } from './activity/activity.component';
import { PropertyComponent } from './property/property.component';
import { SurveyComponent } from './survey/survey.component';

//Rutas de mi sitio
const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'activity', component: ActivityComponent },
  { path: 'property', component: PropertyComponent },
  { path: 'survey', component: SurveyComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
