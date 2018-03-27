import { Component, OnInit } from '@angular/core';
import {GoodsService} from "../../services/goods.service";
import {Good} from "../../models/good";
import {Observable} from "rxjs/Observable";
import {NgbCarouselConfig} from '@ng-bootstrap/ng-bootstrap';
import { ViewEncapsulation } from '@angular/core'
import {NgbModal, NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {GoodEditComponent} from "../good-edit/good-edit.component";

@Component({
  selector: 'app-goods',
  templateUrl: './goods.component.html',
  styleUrls: ['./goods.component.css'],
  providers: [NgbCarouselConfig],
  encapsulation: ViewEncapsulation.None,
})
export class GoodsComponent implements OnInit {

  goods: Good[];

  constructor(config: NgbCarouselConfig,
              private goodsService: GoodsService,
              private modalService: NgbModal) {
    // customize default values of carousels used by this component tree
    console.log('asdfhasldkjg');
    console.log(config);

    config.interval = 3000;
    config.wrap = true;
    config.keyboard = false;
  }

  ngOnInit() {
    this.goodsService.GetGoods()
      .subscribe(goods => this.goods = goods);
  }

  public EditGood(goodId: number) {
    const modalRef = this.modalService.open(GoodEditComponent);
    modalRef.componentInstance.goodId = goodId;
  }

  public AddGood() {
    const modalRef = this.modalService.open(GoodEditComponent);
  }
}
