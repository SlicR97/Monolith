import { Injectable } from '@angular/core';
import { Product } from '../_models/Product';
import { Order } from '../_models/Order';
import { of } from 'rxjs';
import { HttpService } from './http.service';
import { VatRate } from '../_models/VatRate';
import { Size } from '../_models/Size';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  vatRates: VatRate[];

  order: Order =  {
    products: new Array<Product>(),
    vatRate: null,
    basePrice: 0,
    amountGiven: 0,
    changeReceived: 0,
    priceWithVat: 0
  };

  constructor(private http: HttpService) {
    this.http.getVatRates().then(x => this.vatRates = x);
    if (this.vatRates !== undefined) {
      const rate = this.vatRates.find(x => x.id === 1);
      this.order.vatRate = rate;
    }
  }

  add(product: Product) {
    this.order.products.push(product);
  }

  remove(product: Product) {
    const index = this.order.products.indexOf(product);
    if (index > -1) {
      this.order.products.splice(index, 1);
    }
  }

  get() {
    return of(this.order.products);
  }

  changeVatRate() {
    if (this.order.vatRate.id === 1) {
      this.order.vatRate = this.vatRates.find(x => x.id === 2);
    } else {
      this.order.vatRate = this.vatRates.find(x => x.id === 1);
    }
  }

  confirm() {
      const productList: {
          id: number;
          size: Size;
      }[] = new Array<{id: number, size: Size}>();
    this.order.products.forEach(x => productList.push({
      id: x.id,
      size: x.size
    }));
    this.http.sendOrder({
      products: productList,
      vatRate: this.order.vatRate,
      basePrice: this.order.basePrice,
      amountGiven: this.order.amountGiven,
      changeReceived: this.order.changeReceived,
      priceWithVat: this.order.priceWithVat
    });
  }

  update(basePrice: number, amountGiven: number, changeReceived: number, priceWithVat: number) {
    this.order.basePrice = basePrice;
    this.order.amountGiven = amountGiven;
    this.order.changeReceived = changeReceived;
    this.order.priceWithVat = priceWithVat;
  }

  reset() {
    this.order.products = new Array<Product>();
  }
}
