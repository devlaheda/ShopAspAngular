import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Basket, IBasket, IBasketItem, IBasketTotals } from '../shared/models/Basket';
import { map } from 'rxjs/operators'
import { IProduct } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.baseUrl;
  private basketSource = new BehaviorSubject<IBasket>(null)
  private basketTotalSource = new BehaviorSubject<IBasketTotals>(null)
  basketTotal$ = this.basketTotalSource.asObservable();
  basket$ = this.basketSource.asObservable();
  private readonly _basketId = 'basket_id';
   
  
  constructor(private http: HttpClient) { }

  getBasket(id: string) {
    return this.http.get(this.baseUrl + 'basket?id=' + id)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          this.calculateTotals()
          
        })
      );
  }
  setBasket(basket: IBasket) {
    this.http.post(this.baseUrl + 'basket', basket).subscribe({
      next: (res: IBasket) => 
      { 
        this.basketSource.next(res);
        this.calculateTotals();
        
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

 deleteBasket(basket: IBasket) {
    this.http.delete(this.baseUrl+'basket?id='+basket.id).subscribe({
      next: (res)=>{
        console.log(res);        
        this.basketSource.next(null);
        this.basketTotalSource.next(null);
        localStorage.removeItem(this._basketId);
      },
      error: (er) =>{console.log(er);
      }

    });
  }
  AddItemToBasket(item: IProduct, quantity = 1) {
    const itemToAd: IBasketItem = this.mapProductToBasketItem(item, quantity);
    const basket = this.getCurrentBasketValue() ?? this.createNewBasket();
    basket.items = this.addOrUpdateItem(basket.items, itemToAd, quantity);
    this.setBasket(basket);

  }
  addOrUpdateItem(items: IBasketItem[], itemToAd: IBasketItem, quantity: number): IBasketItem[] {
    const index = items.findIndex(i => i.id === itemToAd.id);
    if (index === -1) {
      items.push(itemToAd);
    } else {
      items[index].quantity += quantity;
    }
    return items;
  }
  decrementItemQuantity(item:IBasketItem){
    const basket = this.getCurrentBasketValue();
    const itemIndex = basket.items.findIndex(i => i.id === item.id)
    if (basket.items[itemIndex].quantity > 1) {
      basket.items[itemIndex].quantity--
      this.setBasket(basket);     
    }else{
      this.removeItemFromBasket(item);
    }    
  }
  
  incrementItemQuantity(item:IBasketItem){
    const basket = this.getCurrentBasketValue();
    const itemIndex = basket.items.findIndex(i => i.id === item.id)
    basket.items[itemIndex].quantity++
    this.setBasket(basket);
  }
  removeItemFromBasket(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    if (basket.items.some(x=> x.id === item.id)) {
      basket.items = basket.items.filter(i=>i.id !== item.id)
      if (basket.items.length > 0){
        this.setBasket(basket);
      }else{
        this.deleteBasket(basket);
      }
    }
  }
  
  private createNewBasket(): IBasket {
    const basket = new Basket();
    localStorage.setItem(this._basketId, basket.id);
    return basket;
  }
  private calculateTotals(){
    const basket = this.getCurrentBasketValue();
    const shipping = 0;
    const subtotal = basket?.items.reduce((a,b)=> (b.price*b.quantity)+a,0);
    const total = subtotal+shipping;
    this.basketTotalSource.next({shipping,subtotal,total})
  }

  private mapProductToBasketItem(item: IProduct, quantity: number): IBasketItem {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      pictureUrl: item.pictureUrl,
      quantity: quantity,
      brand: item.productBrand,
      type: item.productType
    };
  }
   private getCurrentBasketValue() {
    return this.basketSource.value;
  }
}


