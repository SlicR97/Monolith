import { Category } from './Category';
import { Size } from './Size';

export class Product {
    id?: number;
    name: string;
    description: string;
    imageUrl: string;
    price: number;
    categoryId: number;
    category: Category;
    size: Size;
    createdAt?: Date;
    modifiedAt?: Date;

    get totalPrice(): number {
        let sum: number;
        if (this.size != null) {
            sum = this.price + this.size.costMultiplier;
        }
        sum = this.price;
        return sum;
    }
}
