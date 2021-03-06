import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasket, IBasketItem } from '../shared/models/Basket';
import { BasketService } from './basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {
  basket$:Observable<IBasket>;

  constructor(private basketService:BasketService) { }

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$
  }

  onRemoveItem(item:IBasketItem){
    this.basketService.removeItemFromBasket(item);
  }
  onIncrementItemQuantity(item:IBasketItem){
    this.basketService.incrementItemQuantity(item)
  }
  onDecrementItemQuantity(item:IBasketItem){
    this.basketService.decrementItemQuantity(item);
  }

}
