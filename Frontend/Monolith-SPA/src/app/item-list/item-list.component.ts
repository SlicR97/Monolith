import { Component, OnInit, Input } from '@angular/core';
import { Product } from '../_models/Product';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {
  @Input() products: Product[];
  @Input() name: string;

  constructor() { }

  ngOnInit() {
  }
}
