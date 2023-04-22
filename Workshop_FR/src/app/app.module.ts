import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductsListComponent } from './Components/products-list/products-list.component';
import { TableModule } from 'primeng/table';
import { HttpClientModule } from '@angular/common/http';
import { ButtonModule} from 'primeng/button';
import { ProductService } from './Services/product.service';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { DialogModule } from 'primeng/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { ConfirmPopupModule } from 'primeng/confirmpopup';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ProductsAddEditComponent } from './Components/products-add-edit/products-add-edit.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CardModule } from 'primeng/card';
import { TooltipModule } from 'primeng/tooltip';
import { ConfirmationService } from 'primeng/api';
import { MessagesModule } from 'primeng/messages';
import { Toast, ToastModule } from 'primeng/toast';

@NgModule({
  declarations: [
    AppComponent,
    ProductsListComponent,
    ProductsAddEditComponent,
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
    ConfirmDialogModule,
    ReactiveFormsModule,
    CardModule,
    TooltipModule,
    MessagesModule,
    ToastModule
  ],
  providers: [ProductService, ConfirmationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
