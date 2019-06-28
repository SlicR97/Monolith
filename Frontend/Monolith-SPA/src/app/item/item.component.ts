import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../_models/Product';
import { OrderService } from '../_services/order.service';
import { Size } from '../_models/Size';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  @Input() product: Product;
  viewingProductDetails = false;
  selectedSize: Size;

  constructor(private order: OrderService) { }

  ngOnInit() {
  }

  addToOrder() {
    this.order.add({
      id: this.product.id,
      name: this.product.name,
      description: this.product.description,
      imageUrl: this.product.imageUrl,
      price: this.product.price,
      categoryId: this.product.categoryId,
      category: this.product.category,
      size: this.product.size,
      totalPrice: this.product.totalPrice,
    });
  }

  toggleProductInfo() {
    this.viewingProductDetails = !this.viewingProductDetails;
  }
}
