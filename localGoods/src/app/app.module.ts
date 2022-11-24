import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthPannelComponent } from './components/auth-pannel/auth-pannel.component';
import { NavPanelComponent } from './components/nav-panel/nav-panel.component';
import { NavOptionComponent } from './nav-option/nav-option.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthPannelComponent,
    NavPanelComponent,
    NavOptionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
