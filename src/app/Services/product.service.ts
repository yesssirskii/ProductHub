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

  // Declaring variable 'api' which grabs the 'apiUrl' variable from the 'environment.ts' file:
  private api = environment.apiUrl;

  private url = 'api/Products';
  private putDeleteURL = this.api + 'api/Products/';

  public getProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(this.api + this.url);
  }

  public addProduct(product: Product): Observable<Product[]>{
    return this.http.post<Product[]>(this.api + this.url, product);
  }

  public updateProduct(id: number, product: Product): Observable<Product[]>{
    return this.http.put<Product[]>(this.putDeleteURL + id, product);
  }

  public deleteProduct(id: number): Observable<Product[]>{
    return this.http.delete<Product[]>(this.putDeleteURL + id);
  }
}
