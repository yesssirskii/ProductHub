import { Component, Input, Output,  OnInit, EventEmitter } from '@angular/core';
import { ProductService } from '../../Services/product.service';
import { Product } from 'src/app/Models/product';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css'],
  providers: [ConfirmationService, MessageService]
})
export class ProductsListComponent implements OnInit {

  products: Product[] = [];
  productToEdit: Product; 
  currentProductId: number;
  
  addDialogVisible: boolean;
  editDialogVisible: boolean;
  deleteDialogVisible: boolean;

  productEditForm: FormGroup;
  productAddForm: FormGroup;

  constructor(
    private productService: ProductService,
    private fb: FormBuilder,
    private confirmationService: ConfirmationService,
    private messageService: MessageService) {}

  ngOnInit(): void {
    this.getProducts();
  }
  
  getProducts(){
    this.productService.getProducts().subscribe((response: Product[]) =>
      (this.products = response));
  }

  deleteProduct(id: number){
    this.confirmationService.confirm({
      accept: () => {
        this.productService.deleteProduct(id).subscribe(response => {this.getProducts()});
        this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'You have accepted' });
      },
      reject: () => {
        this.messageService.add({ severity: 'warn', summary: 'Cancelled', detail: 'You have cancelled' });
      }
  });
}

  updateProductList(products: Product[]){
    this.products = products;
  }

  // Function to initialize a new product:
  initNewProduct(){
    this.productToEdit = new Product();

    this.productAddForm = new FormGroup({
      name: new FormControl('',[
        Validators.required,
        Validators.minLength(3),
      ]),
      price: new FormControl('',[
        Validators.required,
      ]),
      country: new FormControl('',[
        Validators.required,
        Validators.minLength(2),
      ]),
      type: new FormControl('',[
        Validators.required,
        Validators.minLength(3),
      ]),
    })
    this.addDialogVisible = true;
  }
  
  // Function to initialize product to update:
  initUpdatedProduct(id: number, product: Product){
    this.editDialogVisible = true;
    this.currentProductId = id;
    this.productToEdit = product;

    this.productEditForm = this.fb.group({
      name: new FormControl(this.productToEdit?.name,[
        Validators.required,
        Validators.minLength(3),
      ]),
      price: new FormControl(this.productToEdit?.price,[
        Validators.required,
      ]),
      country: new FormControl(this.productToEdit?.country,[
        Validators.required,
        Validators.minLength(2),
      ]),
      type: new FormControl(this.productToEdit?.type,[
        Validators.required,
        Validators.minLength(3),
      ]),
    })
  }
}