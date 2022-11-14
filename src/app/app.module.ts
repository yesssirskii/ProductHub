import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductsListComponent } from './Components/products-list/products-list.component';
import {TableModule} from 'primeng/table';
import { HttpClientModule } from '@angular/common/http';
import { ButtonModule} from 'primeng/button';
import { ProductService } from './Services/product.service';
import { ProductsInsertComponent } from './Components/products-insert/products-insert.component';
import { ProductsEditComponent } from './Components/products-edit/products-edit.component';
import {InputTextModule} from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import {DialogModule} from 'primeng/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import {ConfirmPopupModule} from 'primeng/confirmpopup';
import { ConfirmDialogModule } from 'primeng/confirmdialog';


@NgModule({
  declarations: [
    AppComponent,
    ProductsListComponent,
    ProductsInsertComponent,
    ProductsEditComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ButtonModule,
    TableModule,
    HttpClientModule,
    InputTextModule,
    FormsModule,
    DialogModule,
    BrowserAnimationsModule,
    ConfirmPopupModule,
    ConfirmDialogModule
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
