import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Product } from 'src/app/Models/product';
@Component({
  selector: 'app-products-add-edit',
  templateUrl: './products-add-edit.component.html',
  styleUrls: ['./products-add-edit.component.css'],
})
export class ProductsAddEditComponent implements OnInit {

  @Input() product: Product;
  @Input() currentProductId: number;

  @Input() displayModal: boolean = false;

  @Input() productEditForm: FormGroup; 
  @Input() productAddForm: FormGroup;

  @Output() updatedProduct = new EventEmitter<Product[]>();

  constructor(private service: ProductService, private fb: FormBuilder) {}

  ngOnInit(): void {}

  submitCreateForm(): void{
    this.service
      .addProduct(this.productAddForm.value)
      .subscribe(
        (products: Product[]) => this.updatedProduct.emit(products)
      );
      console.log(this.productAddForm.value);
  }

  submitEditForm(): void{
    this.currentProductId = this.product?.productId;
    this.service
      .updateProduct(this.currentProductId, this.productEditForm.value)
      .subscribe(
        (products: Product[]) => this.updatedProduct.emit(products)
      );
  }
}

