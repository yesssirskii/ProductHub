import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from 'src/app/Models/product';

@Component({
  selector: 'app-products-add-edit',
  templateUrl: './products-add-edit.component.html',
  styleUrls: ['./products-add-edit.component.css']
})
export class ProductsAddEditComponent implements OnInit {

  @Input() product?: Product;
  @Output() updatedProduct = new EventEmitter<Product[]>();

  constructor(private service: ProductService) { }

  ngOnInit(): void {
  }

  createProduct(product: Product){
    this.service.addProduct(product).subscribe((products: Product[]) => this.updatedProduct.emit(products));
  }

  updateProduct(product: Product){
    this.service.updateProduct(product).subscribe((products: Product[]) => this.updatedProduct.emit(products));
  }

  displayModal: boolean;
  showAddModal() {
    this.displayModal = true;
  }

  showEditModal() {
    this.displayModal = true;
  }

}