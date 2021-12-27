import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasketTotals } from '../models/Basket';

@Component({
  selector: 'app-order-total',
  templateUrl: './order-total.component.html',
  styles: [
  ]
})
export class OrderTotalComponent implements OnInit {
  basketTotals$: Observable<IBasketTotals>;

  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
    this.basketTotals$ = this.basketService.basketTotal$
  }

}
