import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { IProductBrand } from '../shared/models/productBrand';
import { IProductType } from '../shared/models/productType';
import { ProductParams } from './productParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search')  searchTerm :ElementRef;
  public products : IProduct[];
  public brands :IProductBrand[];
  public types : IProductType[];
  shopParams : ProductParams;
  totalCount :number;  
  sortOptions =[
    {name:"Alphabetical",value:"name"},
    {name:"Price: Low to High",value:"priceAsc"},
    {name:"Price: High to Low",value:"priceDesc"}
  ]

  constructor(private shopService : ShopService) { 
    this.shopParams = new ProductParams()  
  }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }
  
  getProducts(){
    this.shopService.getProducts(this.shopParams).subscribe( 
      response => 
      {        
        this.shopParams.pagesize = response.pageSize;
        this.shopParams.pageNumber = response.pageIndex;
        this.totalCount = response.count;
        this.products = response.data; 
        console.log(this.shopParams);
        console.log(response);
        
        
      }, 
      error => 
      {
        console.log(error);
      }
      );
  }
  getBrands(){
    this.shopService.getProductBrands().subscribe( 
      response => 
      {        
        this.brands = [{"id":0,"name":"All"},...response]; 
      }, 
      error => 
      {
        console.log(error);
      }
      );
  }
  getTypes(){
    this.shopService.getProductTypes().subscribe( 
      response => 
      {        
        this.types = [{"id":0,"name":"All"},...response];
      }, 
      error => 
      {
        console.log(error);
      }
      );
  }
  
  onBrandSelected(brandId :number){
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  onTypeSelected(typeId:number){
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  onSortChanged(sortOption:string){
    this.shopParams.sort = sortOption;
    this.getProducts()
  }
  onPageChenged(event:any){
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event
      this.getProducts();
    }
    
  }
  onSearch(){
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;   
    this.getProducts();
  }
  onReset(){
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ProductParams();
    this.getProducts();
  }

}
