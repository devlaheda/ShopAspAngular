import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PaginationModule} from 'ngx-bootstrap/pagination';
import { PaginationHeaderComponent } from './pagination-header/pagination-header.component';
import { PagerComponent } from './pager/pager.component';
import { OrderTotalComponent } from './order-total/order-total.component';


@NgModule({
  declarations: [
    PaginationHeaderComponent,
    PagerComponent,
    OrderTotalComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot()
    ],
  exports:[
    PaginationModule,
    PaginationHeaderComponent,
    PagerComponent,
    OrderTotalComponent

  ]
})
export class SharedModule { }
