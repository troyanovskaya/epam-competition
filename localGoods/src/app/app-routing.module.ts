import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendorItemPageComponent } from './components/vendor-item-page/vendor-item-page.component';

const routes: Routes = [

  { path: `:i/products`, component: VendorItemPageComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
