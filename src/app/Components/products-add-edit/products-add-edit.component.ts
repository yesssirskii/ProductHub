import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from 'src/app/Models/product';
import { ColdObservable } from 'rxjs/internal/testing/ColdObservable';

@Component({
  selector: 'app-products-add-edit',
  templateUrl: './products-add-edit.component.html',
  styleUrls: ['./products-add-edit.component.css']
})
export class ProductsAddEditComponent implements OnInit {

  @Input() product: Product;
  @Input() currentProductId: number;
  @Input() displayModal: boolean;
  @Output() updatedProduct = new EventEmitter<Product[]>();

  constructor(private service: ProductService) {
    this.currentProductId = this.product?.productId;
  }

  ngOnInit(): void {}
  
  // create new product
  createProduct(product: Product){
    this.service.addProduct(product).subscribe((products: Product[]) => this.updatedProduct.emit(products));
    this. displayModal = !this.displayModal;
  }

  // update product details
  updateProduct(product: Product){
    this.currentProductId = product.productId; // the line which was missing to get the product ID
    this.service.updateProduct(this.currentProductId, product).subscribe((products: Product[]) => this.updatedProduct.emit(products));
    this.displayModal = !this.displayModal;
  }
}