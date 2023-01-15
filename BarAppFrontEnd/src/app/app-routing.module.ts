import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddBarComponent } from './components/add-bar/add-bar.component';
import { EditBarComponent } from './components/edit-bar/edit-bar.component';
import { HomeComponent } from './components/home/home.component';
import { ViewBarComponent } from './components/view-bar/view-bar.component';

//const routes: Routes = []
const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: 'full'},
  { path: 'Home', component: HomeComponent },
  { path: 'ViewBar/:barId', component: ViewBarComponent },
  { path: 'AddBar', component: AddBarComponent },
  { path: 'EditBar/:barId', component: EditBarComponent } 
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
