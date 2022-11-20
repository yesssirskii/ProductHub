import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from 'src/app/Models/product';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  constructor(private service: ProductService) {}

  products: Product[] = [];
  productToEdit?: Product; 

  ngOnInit(): void {
   this.getProducts();
  }

  getProducts(){
    this.service.getProducts().subscribe((response: Product[]) =>
      (this.products = response));
  }

  deleteProduct(id: any){
    if(confirm("Are you sure?")){
      this.service.deleteProduct(id).subscribe(response => {
        this.getProducts(); 
      })
    }
  }

  updateProductList(products: Product[]){
    this.products = products;
  }

  // Funtcion to initialize new product:
  initNewProduct(){
    this.productToEdit = new Product();
  }

  updateProduct(product: Product){
    this.productToEdit = product;
  }
}