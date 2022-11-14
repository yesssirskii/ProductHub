import { Component, Input, OnInit } from '@angular/core';
import { ProductService } from '../../Services/product.service';

@Component({
  selector: 'app-products-insert',
  templateUrl: './products-insert.component.html',
  styleUrls: ['./products-insert.component.css'],
})

export class ProductsInsertComponent implements OnInit {
  
  @Input() products: any;

  ProductId: number;
  Name: string;
  Price: number;
  Country: string;
  ProductTypeId: number;

  constructor(private service: ProductService) { }

  ngOnInit(): void {
    console.log("Imported products",this.products)
    this.Name = this.products.Name;
    this.Price = this.products.Price;
    this.Country = this.products.Country;
    this.ProductTypeId = this.products.ProductTypeId;
  }

  addProducts(){
    var val = {Name: this.Name, Price: this.Price, Country: this.Country, Type: this.ProductTypeId};
    this.service.AddProducts(val).subscribe(response => {
      alert("Product added.");
      window.location.reload();
    })
  }

  displayModal: boolean;
  showAddModal() {
    this.displayModal = true;
  }
}
