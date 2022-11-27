import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthPannelComponent } from './components/auth-pannel/auth-pannel.component';
import { LocalVendorsSearchAdverbComponent } from './components/local-vendors-search-adverb/local-vendors-search-adverb.component';
import { VendorsSearchComponent } from './components/vendors-search/vendors-search.component';
import { VendorsAdverbComponent } from './components/vendors-adverb/vendors-adverb.component';
import { RowOfDiscountsComponent } from './components/row-of-discounts/row-of-discounts.component';
import { DiscountItemComponent } from './components/discount-item/discount-item.component';
import { FooterComponent } from "./components/footer/footer.component";
import { AboutUsContainerComponent } from './components/about-us-container/about-us-container.component';
import { MenyLeftPanelComponent } from './components/meny-left-panel/meny-left-panel.component';
import { MenyOptionComponent } from './components/meny-option/meny-option.component'

@NgModule({
    declarations: [
        AppComponent,
        AuthPannelComponent,
        LocalVendorsSearchAdverbComponent,
        VendorsSearchComponent,
        VendorsAdverbComponent,
        RowOfDiscountsComponent,
        DiscountItemComponent,
        FooterComponent,
        AboutUsContainerComponent,
        MenyLeftPanelComponent,
        MenyOptionComponent

    ],
    providers: [],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        ReactiveFormsModule
    ]
})
export class AppModule { }
