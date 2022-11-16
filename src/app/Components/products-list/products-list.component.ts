import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../Services/product.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  constructor(private service: ProductService) {}

  products: any = [];

  ngOnInit(): void {
    this.service.getProducts().subscribe((response: any) => {
      this.products = response;
      console.log(this.products);
    })
  }

  deleteProducts(val: any){
    if(confirm("Are you sure?")){
      this.service.deleteProducts(val).subscribe(response =>{
        this.service.getProducts();
      })
    }
  }
}

