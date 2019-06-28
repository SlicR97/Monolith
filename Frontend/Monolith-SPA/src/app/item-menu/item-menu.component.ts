import { Component, OnInit } from '@angular/core';
import { Product } from '../_models/Product';
import { HttpService } from '../_services/http.service';

@Component({
  selector: 'app-item-menu',
  templateUrl: './item-menu.component.html',
  styleUrls: ['./item-menu.component.css']
})
export class ItemMenuComponent implements OnInit {

  products: Product[];

  burgers: Product[];
  drinks: Product[];
  sideDishes: Product[];

  constructor(private http: HttpService) { }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
      this.http.getProducts().subscribe((products: Product[]) => {
          this.products = products;
          this.divideProducts();
      });
  }

  divideProducts() {
    this.burgers = this.products.filter(prod => prod.category.name === 'Burger');
    this.drinks = this.products.filter(prod => prod.category.name === 'Drink');
    this.sideDishes = this.products.filter(prod => prod.category.name === 'Side Dish');
  }

}
