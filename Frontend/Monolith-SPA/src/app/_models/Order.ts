import { Product } from './Product';
import { VatRate } from './VatRate';

export class Order {
    id?: number;
    products: Product[];
    vatRate: VatRate;
    basePrice: number;
    amountGiven: number;
    changeReceived: number;
    priceWithVat: number;
}
