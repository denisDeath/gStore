import { Component, OnInit } from '@angular/core';
import {GoodsService} from '../../../../services/dicts/goods/goods.service';
import {Good} from '../../../../models/dicts/goods/good';
import {Observable} from 'rxjs/Observable';
import {NgbCarouselConfig} from '@ng-bootstrap/ng-bootstrap';
import { ViewEncapsulation } from '@angular/core';
import {NgbModal, NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {GoodEditComponent} from '../good-edit/good-edit.component';
import {RemoveGoodsRequest} from '../../../../models/dicts/goods/remove-goods-request';

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
        if (!getGoodsResponse) {
          return;
        }
        this.isLoading = false;
        this.goods = getGoodsResponse.goods;
        this.sortGoods();
      });
  }

  public EditGood(goodId: number) {
    const modalRef = this.modalService.open(GoodEditComponent);
    modalRef.componentInstance.goodId = goodId;

    modalRef.result.then(editedGood => {
      if (editedGood === null) {
        return;
      }

      this.goods.splice(this.getGoodIndexById(goodId), 1);
      this.goods.push(editedGood);
      this.sortGoods();
    })
    .catch(e => {
    });
  }

  public AddGood() {
    const modalRef = this.modalService.open(GoodEditComponent);
    modalRef.result.then(newGood => {
      if (newGood === null) {
        return;
      }

      this.goods.push(newGood);
    })
    .catch(e => {
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
        this.goods.splice(this.getGoodIndexById(goodId), 1);
      });
  }

  private getGoodIndexById(goodId: number): number {
    const index = this.goods.findIndex((g, _, __) => {
      if (g.id === goodId) {
        return true;
      }
    });
    return index;
  }

  private sortGoods() {
    this.goods.sort((g1, g2) => g1.name > g2.name ? 1 : 0);
  }
}
