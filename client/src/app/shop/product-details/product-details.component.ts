import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from 'src/app/basket/basket.service';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product:IProduct;
  quantity = 1
  constructor(private shopService:ShopService , private activatedRoute:ActivatedRoute,private basketservice:BasketService) { }

  ngOnInit(): void {
    this.getProduct();
  }
  getProduct(){
    this.shopService.getProduct(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe({
      next: res =>{ this.product = res},
      error: (r) => {console.log(r);
      }
      
    })
  }
  onAddToBasket(){
    this.basketservice.AddItemToBasket(this.product,this.quantity);
  }
  onIncrement(){
    this.quantity++
  }
  onDecrement(){
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

}
