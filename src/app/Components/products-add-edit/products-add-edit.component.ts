import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { ConfirmationService } from 'primeng/api';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Product } from 'src/app/Models/product';

@Component({
  selector: 'app-products-add-edit',
  templateUrl: './products-add-edit.component.html',
  styleUrls: ['./products-add-edit.component.css'],
  providers: [ConfirmationService]
})
export class ProductsAddEditComponent implements OnInit {

  productAddForm: FormGroup;
  productEditForm: FormGroup;

  @Input() product: Product;
  @Input() currentProductId: number;
  @Input() displayModal: boolean = false;
  @Output() updatedProduct = new EventEmitter<Product[]>();

  constructor(private service: ProductService) {}

  ngOnInit(): void {
    this.setCreateForm();
    this.setEditForm();
  }

  setEditForm(){
    this.productEditForm = new FormGroup({
      name: new FormControl(this.product?.name,[
        Validators.required,
        Validators.minLength(3),
      ]),
      price: new FormControl(this.product?.price,[
        Validators.required,
      ]),
      country: new FormControl(this.product?.country,[
        Validators.required,
        Validators.minLength(3),
      ]),
      type: new FormControl(this.product?.type,[
        Validators.required,
        Validators.minLength(3),
      ]),
    })
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
  }


}

