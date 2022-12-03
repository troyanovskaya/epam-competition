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
import { MenyOptionComponent } from './components/meny-option/meny-option.component';
import { SearchInputComponent } from './components/search-input/search-input.component';
import { BasketComponent } from './components/basket/basket.component'
import { FormsModule } from '@angular/forms';
import { BasketItemComponent } from './components/basket-item/basket-item.component';
import { PayForOrderComponent } from './components/pay-for-order/pay-for-order.component';
import { UserInfoComponent } from './components/user-info/user-info.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { Routes, RouterModule } from '@angular/router';
import { UserStatusComponent } from './components/user-status/user-status.component';
import { UserHistoryComponent } from './components/user-history/user-history.component';

const appRoutes:Routes = [{
  path: '', component: MainPageComponent
},
{
  path: 'user/info', component: UserInfoComponent
},
{
  path: 'user/status', component: UserStatusComponent
},
{
  path: 'user/history', component: UserHistoryComponent
}

]
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
        MenyOptionComponent,
        SearchInputComponent,
        BasketComponent,
        BasketItemComponent,
        PayForOrderComponent,
        UserInfoComponent,
        MainPageComponent,
        UserStatusComponent,
        UserHistoryComponent

    ],
    providers: [],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        ReactiveFormsModule,
        FormsModule,
        RouterModule.forRoot(appRoutes),
    ]
})
export class AppModule { }
