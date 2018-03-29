import { Component, OnInit } from '@angular/core';
import {GoodsService} from "../../services/goods/goods.service";
import {Good} from "../../models/good";
import {Observable} from "rxjs/Observable";
import {NgbCarouselConfig} from '@ng-bootstrap/ng-bootstrap';
import { ViewEncapsulation } from '@angular/core'
import {NgbModal, NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {GoodEditComponent} from "../good-edit/good-edit.component";
import {RemoveGoodsRequest} from "../../models/remove-goods-request";

@Component({
  selector: 'app-goods',
  templateUrl: './goods.component.html',
  styleUrls: ['./goods.component.css'],
  providers: [NgbCarouselConfig],
  encapsulation: ViewEncapsulation.None,
})
export class GoodsComponent implements OnInit {

  goods: Good[];
  isLoading: boolean;

  constructor(config: NgbCarouselConfig,
              private goodsService: GoodsService,
              private modalService: NgbModal) {
    // customize default values of carousels used by this component tree
    config.interval = 3000;
    config.wrap = true;
    config.keyboard = false;
  }

  ngOnInit() {
    this.LoadGoods();
  }

  public LoadGoods() {
    this.isLoading = true;
    this.goods = [];
    this.goodsService.GetGoods()
      .subscribe(getGoodsResponse => {
        this.isLoading = false;
        this.goods = getGoodsResponse.goods;
      });
  }

  public EditGood(goodId: number) {
    const modalRef = this.modalService.open(GoodEditComponent);
    modalRef.componentInstance.goodId = goodId;
  }

  public AddGood() {
    const modalRef = this.modalService.open(GoodEditComponent);
    modalRef.result.then(newGood => {
      this.goods.push(newGood);
    });
  }

  public RemoveGood(goodId: number) {
    if (!confirm('Вы хотите удалить товар?')) {
      return;
    }

    this.isLoading = true;
    this.goodsService.RemoveGoods(new RemoveGoodsRequest([goodId]))
      .subscribe(_ => {
        this.isLoading = false;

        let index = this.goods.findIndex((g, _, __) => {
          if (g.id == goodId){
            return true;
          }
        });
        this.goods.splice(index, 1);
      });
  }
}
