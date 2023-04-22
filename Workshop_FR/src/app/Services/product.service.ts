import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../Models/product';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})

export class ProductService {
  
  constructor(private http: HttpClient) {}

  private apiURL = environment.apiUrl + 'api/Products/';

  public getProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(this.apiURL);
  }

  public addProduct(product: Product): Observable<Product[]>{
    return this.http.post<Product[]>(this.apiURL, product);
  }

  public updateProduct(id: number, product: Product): Observable<Product[]>{
    return this.http.put<Product[]>(this.apiURL + id, product);
  }

  public deleteProduct(id: number): Observable<Product[]>{
    return this.http.delete<Product[]>(this.apiURL + id);
  }
}
