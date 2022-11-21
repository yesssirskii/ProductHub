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

  productToEdit?: Product;

  constructor(private service: ProductService) { }

  ngOnInit(): void {
  }
  
  createProduct(product: Product){
    this.service.addProduct(product).subscribe((products: Product[]) => this.updatedProduct.emit(products));
  }

  updateProduct(id: any){
    this.service.updateProduct(id).subscribe((products: Product[]) => this.updatedProduct.emit(products));
  }

  displayModal: boolean;
  showModal() {
    this.displayModal = true;
  }
}