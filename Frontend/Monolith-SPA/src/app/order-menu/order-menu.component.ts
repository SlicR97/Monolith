import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../_models/Product';
import { OrderService } from '../_services/order.service';
import { VatRate } from '../_models/VatRate';

@Component({
  selector: 'app-order-menu',
  templateUrl: './order-menu.component.html',
  styleUrls: ['./order-menu.component.css']
})
export class OrderMenuComponent implements OnInit {
  vatRates: VatRate[];
  orderConfirmation: boolean;
  products: Product[];
  orderIsToGo: boolean;
  totalAmountGiven: number[] = new Array<number>();

  get totalPrice(): number {
    return this.getTotalPrice() + this.getVat();
  }

  get change(): number {
    if (this.amountGiven > this.totalPrice) {
      return Math.round((this.amountGiven - this.totalPrice) * 100) / 100;
    }
    return 0;
  }

  get amountGiven(): number {
    let amount = 0;
    this.totalAmountGiven.forEach(x => amount += x);
    return amount;
  }

  constructor(private orderService: OrderService) { }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
      this.orderService.get().subscribe(x => {
          this.products = x;
      });
  }

  removeProduct(product: Product) {
    this.orderService.remove(product);
  }

  productLengthOk(): boolean {
    return this.products.length > 0;
  }

  toggleOrderConfirmation() {
    this.orderConfirmation = !this.orderConfirmation;
  }

  getTotalPrice(): number {
    let price = 0;
    this.products.forEach(x => {
      if (x.size !== undefined) {
        price += x.price * x.size.costMultiplier;
      } else {
        price += x.price;
      }
    });
    price = Math.round(price * 100) / 100;
    return price;
  }

  getVat(): number {
    let vat: number = this.getTotalPrice() * .19;
    if (this.orderService.order.vatRate !== undefined) {
      vat = vat * this.orderService.order.vatRate.multiplier;
    }
    return vat;
  }

  getVatRate(): number {
    if (this.orderService.order.vatRate !== undefined) {
      return this.orderService.order.vatRate.multiplier;
    }
    return .19;
  }

  toggleVatRate() {
    this.orderService.changeVatRate();
  }

  addToAmountGiven(amount: number) {
    this.totalAmountGiven.push(amount);
  }

  reduceFromAmountGiven() {
    this.totalAmountGiven.pop();
  }

  confirmOrder() {
    if (this.amountGiven > this.totalPrice) {
      this.orderConfirmation = !this.orderConfirmation;
      this.orderService.update(this.getTotalPrice(), this.amountGiven, this.change, this.totalPrice);
      this.totalAmountGiven = new Array<number>();
      this.orderService.confirm();
      this.orderService.reset();
      this.orderService.get().subscribe(x => this.products = x);
    }
  }

  amountGivenOk(): boolean {
    return this.amountGiven > this.totalPrice;
  }
}
