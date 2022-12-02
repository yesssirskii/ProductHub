import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from 'src/app/Models/product';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-products-add-edit',
  templateUrl: './products-add-edit.component.html',
  styleUrls: ['./products-add-edit.component.css']
})
export class ProductsAddEditComponent implements OnInit {

  productForm: FormGroup;

  @Input() product: Product;
  @Input() currentProductId: number;
  @Input() displayModal: boolean = false;
  @Output() updatedProduct = new EventEmitter<Product[]>();

  constructor(private service: ProductService, private fb: FormBuilder) {this.currentProductId = this.product?.productId;}

  ngOnInit(): void {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      price: ['', Validators.required],
      country: ['', Validators.required],
    });
  }

  get registerFormControl() {
    return this.productForm.controls;
  }
  
  // create new product
  createProduct(product: Product){
    this.service.addProduct(product).subscribe((products: Product[]) => this.updatedProduct.emit(products));
  }

  // update product details
  updateProduct(product: Product){
    this.currentProductId = product.productId; // the line which was missing to get the product ID
    console.log(this.currentProductId);
    this.service.updateProduct(this.currentProductId, product).subscribe((products: Product[]) => this.updatedProduct.emit(products));
  }
}