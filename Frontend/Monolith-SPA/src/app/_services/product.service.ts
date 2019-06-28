import { Injectable } from '@angular/core';
import { Product } from '../_models/Product';
import { Category } from '../_models/Category';
import { Size } from '../_models/Size';
import { HttpService } from './http.service';

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    products: Product[];
    sizes: Size[];
    categories: Category[];

    constructor(private http: HttpService) {
        this.http.getSizes().then(x => this.sizes = x);
        this.http.getProducts().subscribe(x => this.products = x);
    }
}
