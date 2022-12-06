import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { ConfirmationService } from 'primeng/api';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Product } from 'src/app/Models/product';

@Component({
  selector: 'app-products-add-edit',
  templateUrl: './products-add-edit.component.html',
  styleUrls: ['./products-add-edit.component.css'],
  providers: [ConfirmationService]
})
export class ProductsAddEditComponent implements OnInit {

  @Input() product: Product;
  @Input() currentProductId: number;
  @Input() displayModal: boolean = false;
  @Output() updatedProduct = new EventEmitter<Product[]>();

  constructor(private service: ProductService) {}

  ngOnInit(): void {}

  name: FormControl = new FormControl('', [Validators.required, Validators.minLength(3)]);
  price: FormControl = new FormControl('', [Validators.required]);
  country: FormControl = new FormControl('', [Validators.required, Validators.minLength(3)]);
  type: FormControl = new FormControl('', [Validators.required, Validators.minLength(3)]);
  
  createProduct(product: Product){
    this.service.addProduct(product).subscribe((products: Product[]) => this.updatedProduct.emit(products));
  }

  updateProduct(product: Product){
    this.currentProductId = product.productId; // the line which was missing to get the product ID
    this.service.updateProduct(this.currentProductId, product).subscribe((products: Product[]) => this.updatedProduct.emit(products));
  }
}

