import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from '../Services/product.service';

@Component({
  selector: 'app-products-add-edit',
  templateUrl: './products-add-edit.component.html',
  styleUrls: ['./products-add-edit.component.css']
})
export class ProductsAddEditComponent implements OnInit {

  @Input() products: any;

  productId: number;
  name: string;
  price: number;
  country: string;
  productTypeId: number;

  constructor(private service: ProductService) { }

  ngOnInit(): void {
    this.productId = this.products.productId;
    this.name =  this.products.name;
    this.price = this.products.price;
    this.country = this.products.country;
    this.productTypeId =  this.products.productTypeId;
  }

  addProducts(){
    var val = {name: this.name, price: this.price, country: this.country};
    this.service.addProducts(val).subscribe(response => {
      this.products.val = response;
      alert("Product added.");
      this.products.getProducts();
    })
  }

  editProducts(val: any){
    this.service.editProducts(val).subscribe(response => {
      this.products = response;
      alert("Product updated successfully.");
      window.location.reload();
    })
  }


  displayModal: boolean;
  showAddModal() {
    this.displayModal = true;
  }

  showEditModal() {
    this.displayModal = true;
  }

}
