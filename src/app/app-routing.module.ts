import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProductsAddEditComponent } from './products-add-edit/products-add-edit.component';

const routes: Routes = [
  {path: 'newProduct', component: ProductsAddEditComponent},
  {path: 'editProduct', component: ProductsAddEditComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
