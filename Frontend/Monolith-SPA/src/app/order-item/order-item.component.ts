import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../_models/Product';
import { OrderService } from '../_services/order.service';
import { ProductService } from '../_services/product.service';
import { Size } from '../_models/Size';

@Component({
  selector: 'app-order-item',
  templateUrl: './order-item.component.html',
  styleUrls: ['./order-item.component.css']
})
export class OrderItemComponent implements OnInit {
  @Input() product: Product;
  selectedSize: Size;

  constructor(private order: OrderService, private productService: ProductService) {
   }

  ngOnInit() {
    this.product.size = {
      id: 1,
      name: 'Small',
      costMultiplier: 1,
      fillSize: 0.2
    };
    this.selectedSize = this.product.size;
  }

  removeProduct() {
    this.order.remove(this.product);
  }

  getPrice(): number {
    if (this.product.size === undefined) {
      return this.product.price;
    }
    return this.product.price * this.product.size.costMultiplier;
  }

  setSize(id: number) {
    this.product.size = this.productService.sizes.find(x => x.id === id);
  }
}
