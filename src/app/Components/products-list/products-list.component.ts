import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../Services/product.service';

interface Product {
  ProductId: number,
  Name: string,
  Price: number,
  Country: string,
  ProductTypeId: number;
}

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  constructor(private service: ProductService) {}

  products: Product[] = [];

  ngOnInit(): void {
    this.service.getProducts().subscribe((response: Product[]) => {
      this.products = response;
      console.log(this.products);
    })
  }

  deleteProducts(val: any){
    if(confirm("Are you sure?")){
      this.service.DeleteProducts(val).subscribe(response =>{
        window.location.reload();
      })
    }
  }
}

