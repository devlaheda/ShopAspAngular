import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss']
})
export class PagerComponent implements OnInit ,AfterViewInit{
  @Input() count:number;
  @Input() size:number;
  @Output() pageChanged :EventEmitter<number>

  constructor() { 
    this.pageChanged = new EventEmitter<number>();
  }
  ngAfterViewInit(): void {
    console.log(`Count : ${this.count} Size: ${this.size}`);
    
  }

  ngOnInit(): void {
  }
  
  onPagerPageChanged(event : any){
    this.pageChanged.emit(event.page)
  }

}
