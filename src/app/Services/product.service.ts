import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../Models/product';
import { environment } from 'src/environments/environment';
import { identifierName } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  
  constructor(private http: HttpClient) { }

  // Declaring variable 'api' which grabs the 'apiUrl' variable from the 'environment.ts' file:
  private api = environment.apiUrl;
  private url = 'api/Products';
  private putUrl = 'api/Products/';

  // GET method:
  public getProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(this.api + this.url);
  }

  // POST method:
  public addProduct(product: Product): Observable<Product[]>{
    return this.http.post<Product[]>(this.api + this.url, product);
  }

  // PUT method:
  public updateProduct(product: Product, id: any): Observable<Product[]>{
    return this.http.put<Product[]>(this.api + this.putUrl + id, product);
  }

  // DELETE method:
  public deleteProduct(id: any){
    return this.http.delete<Product[]>(this.api + this.putUrl + id);
  }
}
