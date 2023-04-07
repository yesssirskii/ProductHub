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
  productAddForm: FormGroup;

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
        Validators.minLength(2),
      ]),
      type: new FormControl('',[
        Validators.required,
        Validators.minLength(3),
      ]),
    })
  }
  
  // Function to initialize product to update:
  initUpdatedProduct(id: number, product: Product){
    this.currentProductId = id;
    this.productToEdit = product;

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
        Validators.minLength(2),
      ]),
      type: new FormControl(this.productToEdit?.type,[
        Validators.required,
        Validators.minLength(3),
      ]),
    })
  }
}