import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import{IProductBrand} from '../shared/models/productBrand'
import{IProductType} from '../shared/models/productType'

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private _baseUrl = 'https://localhost:5001/api/';
  constructor(private http:HttpClient) { }
  getProducts(){
    return this.http.get<IPagination>(this._baseUrl+'products?pageSize=50');
  }
  getProductBrands(){
    return this.http.get<IProductBrand>(this._baseUrl+'products/brands');
  } 
  getProductTypes(){
    return this.http.get<IProductType>(this._baseUrl+'products/types');
  }
}

