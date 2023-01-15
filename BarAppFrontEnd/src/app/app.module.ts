import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { ValueComponent } from './valueslist/valueslist.component';
import { HomeComponent } from './components/home/home.component';
import { AddBarComponent } from './components/add-bar/add-bar.component';
import { EditBarComponent } from './components/edit-bar/edit-bar.component';
import { ViewBarComponent } from './components/view-bar/view-bar.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    ValueComponent,
    HomeComponent,
    AddBarComponent,
    EditBarComponent,
    ViewBarComponent,
  ],
  imports: [
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserModule,    
    
    ToastrModule.forRoot({
      positionClass :'toast-bottom-right'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
