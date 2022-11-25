import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthPannelComponent } from './components/auth-pannel/auth-pannel.component';
import { NavPanelComponent } from './components/nav-panel/nav-panel.component';
import { NavOptionComponent } from './nav-option/nav-option.component';
import { LocalVendorsSearchAdverbComponent } from './components/local-vendors-search-adverb/local-vendors-search-adverb.component';
import { VendorsSearchComponent } from './components/vendors-search/vendors-search.component';
import { VendorsAdverbComponent } from './components/vendors-adverb/vendors-adverb.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthPannelComponent,
    NavPanelComponent,
    NavOptionComponent,
    LocalVendorsSearchAdverbComponent,
    VendorsSearchComponent,
    VendorsAdverbComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
