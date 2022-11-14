import { Component, Input, OnInit } from '@angular/core';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-products-edit',
  templateUrl: './products-edit.component.html',
  styleUrls: ['./products-edit.component.css']
})
export class ProductsEditComponent implements OnInit {

  constructor(private service: ProductService) { }

  @Input() products!: any;

  ProductId: number;
  Name: string;
  Price: number;
  Country: string;
  ProductTypeId: number;

  ngOnInit(): void {
    this.ProductId = this.products.ProductId;
    this.Name = this.products.Name;
    this.Price = this.products.Price;
    this.Country = this.products.Country;
    this.ProductTypeId = this.products.Type;
  }

  editProducts(val: any){
    this.service.EditProducts(val).subscribe(response => {
      this.products = response;
      alert("Product updated successfully.");
      window.location.reload();
    })
  }

  displayModal: boolean;

  showEditModal() {
    this.displayModal = true;
  }
}
