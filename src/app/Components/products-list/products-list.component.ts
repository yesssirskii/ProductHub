import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from 'src/app/Models/product';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  // Defining variables to be used in other components:
  products: Product[] = [];
  productToEdit: Product; 
  currentProductId: number;
  displayModal: boolean = false;

  constructor(private service: ProductService) {}

  ngOnInit(): void {
   this.getProducts();
  }
  
  // Function to get all products:
  getProducts(){
    this.service.getProducts().subscribe((response: Product[]) =>
      (this.products = response));
  }

    // Function to delete a product:
  deleteProduct(id: any){
    if(confirm("Are you sure?")){
      console.log(id);
      this.service.deleteProduct(id).subscribe(response => {
        this.getProducts(); 
      })
    }
  }

  // Function which updates product list:
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