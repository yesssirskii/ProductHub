import { Component, Input, Output,  OnInit, EventEmitter } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from 'src/app/Models/product';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  products: Product[] = [];
  productToEdit: Product; 
  currentProductId: number;
  displayModal: boolean = false;

  productEditForm: FormGroup;


  constructor(private service: ProductService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.getProducts();
  }
  
  getProducts(){
    this.service.getProducts().subscribe((response: Product[]) =>
      (this.products = response));
  }

  deleteProduct(id: number){
    if(confirm("Are you sure you want to delete this product?")){
      this.service.deleteProduct(id).subscribe(response => {
        alert("Product deleted successfully.")
        this.getProducts();
      })
    }
  }

  updateProductList(products: Product[]){
    this.products = products;
  }

  // Function to initialize a new product:
  initNewProduct(){
    this.productToEdit = new Product();
  }
  
  // Function to initialize product to update:
  initUpdatedProduct(id: number, product: Product){
    this.currentProductId = id;
    this.productToEdit = product;
    console.log(product);

    this.productEditForm = this.fb.group({
      name: new FormControl(this.productToEdit?.name,[
        Validators.required,
        Validators.minLength(3),
      ]),
      price: new FormControl(this.productToEdit?.price,[
        Validators.required,
      ]),
      country: new FormControl(this.productToEdit?.country,[
        Validators.required,
        Validators.minLength(3),
      ]),
      type: new FormControl(this.productToEdit?.type,[
        Validators.required,
        Validators.minLength(3),
      ]),
    })
    this.productEditForm.patchValue({
      name: this.productToEdit?.name,
      price: this.productToEdit?.price,
      country: this.productToEdit?.country,
      type: this.productToEdit?.type,
    });
    console.log(this.productEditForm.value);
  }
}