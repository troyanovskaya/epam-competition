import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BasketPageComponent } from './components/basket-page/basket-page.component';
import { EmailConfirmationComponent } from './components/email-confirmation/email-confirmation.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { PasswordRecoveryComponent } from './components/password-recovery/password-recovery.component';
import { ProductPageComponent } from './components/product-page/product-page.component';
import { UserHistoryComponent } from './components/user-history/user-history.component';
import { UserInfoComponent } from './components/user-info/user-info.component';
import { UserStatusComponent } from './components/user-status/user-status.component';
import { VendorGoodsComponent } from './components/vendor-goods/vendor-goods.component';
import { VendorItemPageComponent } from './components/vendor-item-page/vendor-item-page.component';
import { VendorOrdersComponent } from './components/vendor-orders/vendor-orders.component';

const routes: Routes = [
  {  path: '', component: MainPageComponent},
  {  path: 'user/info', component: UserInfoComponent},
  {  path: 'user/status', component: UserStatusComponent},
  {  path: 'user/history', component: UserHistoryComponent},
  {  path: 'basket', component: BasketPageComponent},
  {  path: 'product/:id', component: ProductPageComponent},
  {  path: 'vendor/goods', component: VendorGoodsComponent},
  {  path: 'vendor/orders', component: VendorOrdersComponent},
  {  path: 'auth/confirm-email', component: EmailConfirmationComponent},
  {  path: 'auth/password-recovery', component: PasswordRecoveryComponent},
  { path: `:i/products`, component: VendorItemPageComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
