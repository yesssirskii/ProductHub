import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProductsListComponent } from './Components/products-list/products-list.component';
import { ProductsAddEditComponent } from './products-add-edit/products-add-edit.component';
const routes: Routes = [
  {path: 'product', component: ProductsListComponent},
  {path: 'newProduct', component: ProductsAddEditComponent},
  {path: 'editProduct', component: ProductsAddEditComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
