import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from '../Models/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  
  constructor(private http: HttpClient) { }

  private apiUrl = 'https://localhost:7213/';

  public getProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(this.apiUrl + 'GetProducts');
  }

  public AddProducts(val: any){
    return this.http.post<Product[]>(this.apiUrl + 'AddProducts', val)
  }

  public EditProducts(val: any){
    return this.http.put<Product[]>(this.apiUrl + '/Editproducts?id=', val)
  }

  public DeleteProducts(val: any){
    return this.http.delete<Product[]>(this.apiUrl + 'DeleteProducts?id=' + val)
  }
}
