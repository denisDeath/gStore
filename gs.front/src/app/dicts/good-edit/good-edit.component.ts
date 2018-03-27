import {Component, Input, OnInit} from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {Good} from "../../models/good";
import {GoodsService} from "../../services/goods.service";

@Component({
  selector: 'app-good-edit',
  templateUrl: './good-edit.component.html',
  styleUrls: ['./good-edit.component.css']
})
export class GoodEditComponent implements OnInit {

  @Input() goodId: number;
  editedGood: Good;
  isLoading: boolean;

  constructor(public activeModal: NgbActiveModal,
              private goodsService:GoodsService) {
  }

  ngOnInit() {
    console.log(this.goodId);
    if (this.goodId == undefined) {
      console.log('created');
      this.editedGood = new Good();
      this.isLoading = false;
      return;
    }

    this.isLoading = true;
    this.goodsService.GetGoodDetails(this.goodId).subscribe(good => {
      this.editedGood = good;
      this.isLoading = false;
    })
  }

  public Close() {
    this.activeModal.close('Close click')
  }

  public SaveAndClose() {
    this.activeModal.close('Close click')
  }
}
