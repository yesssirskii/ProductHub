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

  productAddForm: FormGroup;

  @Input() product: Product;
  @Input() currentProductId: number;
  @Input() displayModal: boolean = false;
  @Output() updatedProduct = new EventEmitter<Product[]>();

  @Input() productEditForm: FormGroup; 

  constructor(private service: ProductService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.setCreateForm();
  }


  setCreateForm(){
    this.productAddForm = new FormGroup({
    name: new FormControl('',[
      Validators.required,
      Validators.minLength(3),
    ]),
    price: new FormControl('',[
      Validators.required,
    ]),
    country: new FormControl('',[
      Validators.required,
      Validators.minLength(3),
    ]),
    type: new FormControl('',[
      Validators.required,
      Validators.minLength(3),
    ]),
  })
  console.log(this.productAddForm.value);
  }

  submitCreateForm(): void{
    if(!this.productAddForm.valid){
      return;
    }
    this.service
      .addProduct(this.productAddForm.value)
      .subscribe(
        (products: Product[]) => this.updatedProduct.emit(products)
      );
      console.log(this.productAddForm.value);
  }

  submitEditForm(): void{
    if(!this.productEditForm.valid){
      return;
    }
    this.currentProductId = this.product?.productId;
    this.service
      .updateProduct(this.currentProductId, this.productEditForm.value)
      .subscribe(
        (products: Product[]) => this.updatedProduct.emit(products)
      );
      console.log(this.productEditForm.value);
  }
}

