import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from 'src/app/Models/product';

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

  constructor(private service: ProductService) {}

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
  }
}