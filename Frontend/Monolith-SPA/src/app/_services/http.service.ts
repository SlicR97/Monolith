import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../_models/Product';
import { environment } from '../../environments/environment';
import { VatRate } from '../_models/VatRate';
import { Size } from '../_models/Size';
import { Order } from '../_models/Order';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + 'product');
  }

  getVatRates(): Promise<VatRate[]> {
    return this.http.get<VatRate[]>(this.baseUrl + 'vatrate').toPromise();
  }

  getSizes(): Promise<Size[]> {
    return this.http.get<Size[]>(this.baseUrl + 'size').toPromise();
  }

  sendOrder(order: any) {
    this.http.post(this.baseUrl + 'order', order).subscribe(x => console.log(x), err => console.log(err));
  }
}
