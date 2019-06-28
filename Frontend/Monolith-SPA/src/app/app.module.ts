import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrderMenuComponent } from './order-menu/order-menu.component';
import { ItemMenuComponent } from './item-menu/item-menu.component';
import { ItemListComponent } from './item-list/item-list.component';
import { ItemComponent } from './item/item.component';
import { HttpService } from './_services/http.service';
import { OrderService } from './_services/order.service';
import { HttpClientModule } from '@angular/common/http';
import { OrderItemComponent } from './order-item/order-item.component';
import { ProductService } from './_services/product.service';

@NgModule({
  declarations: [
    AppComponent,
    OrderMenuComponent,
    ItemMenuComponent,
    ItemListComponent,
    ItemComponent,
    OrderItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    HttpService,
    OrderService,
    ProductService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
