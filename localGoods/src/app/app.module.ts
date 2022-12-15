import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthPannelComponent } from './components/auth-pannel/auth-pannel.component';
import { LocalVendorsSearchAdverbComponent } from './components/local-vendors-search-adverb/local-vendors-search-adverb.component';
import { VendorsSearchComponent } from './components/vendors-search/vendors-search.component';
import { VendorsAdverbComponent } from './components/vendors-adverb/vendors-adverb.component';
import { FooterComponent } from "./components/footer/footer.component";
import { AboutUsContainerComponent } from './components/about-us-container/about-us-container.component';
import { MenyLeftPanelComponent } from './components/meny-left-panel/meny-left-panel.component';
import { MenyOptionComponent } from './components/meny-option/meny-option.component';
import { SearchInputComponent } from './components/search-input/search-input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BasketItemComponent } from './components/basket-item/basket-item.component';
import { PayForOrderComponent } from './components/pay-for-order/pay-for-order.component';
import { UserInfoComponent } from './components/user-info/user-info.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { Routes, RouterModule } from '@angular/router';
import { UserStatusComponent } from './components/user-status/user-status.component';
import { UserHistoryComponent } from './components/user-history/user-history.component';
import { UserNavigationComponent } from './components/user-navigation/user-navigation.component';
import { LogInPageComponent } from './components/log-in-page/log-in-page.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations'
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { MatDialogModule } from '@angular/material/dialog';
import { SignUpPageComponent } from './components/sign-up-page/sign-up-page.component';
import { HttpClientModule } from '@angular/common/http';
import { RegVendorComponent } from './components/reg-vendor/reg-vendor.component';
import { BasketPageComponent } from './components/basket-page/basket-page.component';
import { BasketPanelComponent } from './components/basket-panel/basket-panel.component';
import { ProductPageComponent } from './components/product-page/product-page.component';
import { VendorGoodsComponent } from './components/vendor-goods/vendor-goods.component';
import { VendorOrdersComponent } from './components/vendor-orders/vendor-orders.component';
import { VendorOrderItemComponent } from './components/vendor-order-item/vendor-order-item.component';
import { VendorGoodItemComponent } from './components/vendor-good-item/vendor-good-item.component';
import { BasketVendorPipe } from '../app/pipes/basket-vendor.pipe';
import { GoodsComponent } from './components/goods/goods.component';
import { GoodItemComponent } from './components/good-item/good-item.component';
import { GoodsByKeywordPipe } from './pipes/goods-by-keyword.pipe';
import { EmailConfirmationComponent } from './components/email-confirmation/email-confirmation.component';
import { PasswordRecoveryComponent } from './components/password-recovery/password-recovery.component';
import { NotifierComponent } from './components/notifier/notifier.component';
import { VendorItemPageComponent } from './components/vendor-item-page/vendor-item-page.component';
import { SendEmailConfirmationComponent } from './components/send-email-confirmation/send-email-confirmation.component';
import { UserForgotPasswordComponent } from './components/user-forgot-password/user-forgot-password.component';
import { VendorGoodCraeationComponent } from './components/vendor-goods/vendor-good-craeation/vendor-good-craeation.component';
import { OrderDetailsComponent } from './components/order-details/order-details.component';

const appRoutes:Routes = [
]

// export function tokenGetter() {
//   // let user1:{token:string} = JSON.parse(localStorage.getItem('user')??JSON.stringify({token:'none'}));
//   console.log('!!!!!!!!!!1');
//   console.log(localStorage.getItem('token'));
//   return localStorage.getItem('token');
// }
@NgModule({
    declarations: [
        AppComponent,
        AuthPannelComponent,
        LocalVendorsSearchAdverbComponent,
        VendorsSearchComponent,
        VendorsAdverbComponent,
        FooterComponent,
        AboutUsContainerComponent,
        MenyLeftPanelComponent,
        MenyOptionComponent,
        SearchInputComponent,
        BasketItemComponent,
        PayForOrderComponent,
        UserInfoComponent,
        MainPageComponent,
        UserStatusComponent,
        UserHistoryComponent,
        UserNavigationComponent,
        LogInPageComponent,
        SignUpPageComponent,
        RegVendorComponent,
        BasketPageComponent,
        BasketPanelComponent,
        BasketVendorPipe,
        ProductPageComponent,
        VendorGoodsComponent,
        VendorOrdersComponent,
        VendorOrderItemComponent,
        VendorGoodItemComponent,
        GoodsComponent,
        GoodItemComponent,
        GoodsByKeywordPipe,
        EmailConfirmationComponent,
        PasswordRecoveryComponent,
        NotifierComponent,
        VendorItemPageComponent,
        SendEmailConfirmationComponent,
        UserForgotPasswordComponent,
        VendorGoodCraeationComponent,
        OrderDetailsComponent
    ],
    providers: [],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        ReactiveFormsModule,
        FormsModule,
        RouterModule.forRoot(appRoutes),
        NoopAnimationsModule,
        MatDialogModule,
        HttpClientModule,
        MatSnackBarModule,
        // JwtModule.forRoot({
        //   config: {
        //     tokenGetter: tokenGetter,
        //     allowedDomains: ["https://localgoodsapi.azurewebsites.net"]
        //   },
        // }),
    ]
})
export class AppModule { }
