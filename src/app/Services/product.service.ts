import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  
  constructor(private http: HttpClient) { }

  // Declaring variable 'api' which grabs the 'apiUrl' variable from the 'environment.ts' file:
  api = environment.apiUrl;

  // GET method:
  public getProducts(): Observable<any[]>{
    return this.http.get<any>(this.api + 'getProducts');
  }

  // POST method:
  public addProducts(val: any){
    return this.http.post(this.api + 'addProducts', val)
  }

  // PUT method:
  public editProducts(val: any){
    return this.http.put(this.api + 'editproducts?id=', val)
  }

  // DELETE method:
  public deleteProducts(val: any){
    return this.http.delete(this.api + 'deleteProducts?id=' + val)
  }
}
