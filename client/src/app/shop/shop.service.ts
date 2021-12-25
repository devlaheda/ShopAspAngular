import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { delay, map } from 'rxjs';
import { IPagination } from '../shared/models/pagination';
import { IProduct } from '../shared/models/product';
import{IProductBrand} from '../shared/models/productBrand'
import{IProductType} from '../shared/models/productType'
import { ProductParams } from './productParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private _baseUrl = 'https://localhost:5001/api/';
  constructor(private http:HttpClient) { }
  getProducts(shopParams:ProductParams){
    let params = new HttpParams();
    if (shopParams.typeId !== 0 ) {
      params = params.append('typeId',shopParams.typeId.toString());
    }
    if (shopParams.brandId !== 0) {
      params = params.append('brandId',shopParams.brandId.toString());
    }
    if (shopParams.search) {
      params = params.append("search",shopParams.search);
    }
    params = params.append("sort",shopParams.sort);
    params = params.append("pageIndex",shopParams.pageNumber.toString());
    params = params.append("pageSize", shopParams.pagesize.toString()); 

    return this.http.get<IPagination>(this._baseUrl+'products',{params:params});
  }

  getProduct(id:number){
   return this.http.get<IProduct>(this._baseUrl+'products/'+id);
  }

  getProductBrands(){
    return this.http.get<IProductBrand[]>(this._baseUrl+'products/brands');
  } 
  getProductTypes(){
    return this.http.get<IProductType[]>(this._baseUrl+'products/types');
  }
  
}

