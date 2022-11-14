import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProductsEditComponent } from './Components/products-edit/products-edit.component';
import { ProductsInsertComponent } from './Components/products-insert/products-insert.component';

const routes: Routes = [
  {path: 'newProduct', component: ProductsInsertComponent},
  {path: 'editProduct', component: ProductsEditComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
