import {Component, Input, OnInit} from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {Good} from "../../models/good";
import {GoodsService} from "../../services/goods/goods.service";
import {AddGoodRequest} from "../../models/add-good-request";
import {GetGoodDetailsRequest} from "../../models/get-good-details-request";

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
    this.editedGood = new Good();
    if (this.goodId == undefined) {
      this.isLoading = false;
      return;
    }

    this.isLoading = true;
    this.goodsService.GetGoodDetails(new GetGoodDetailsRequest(this.goodId)).subscribe(goodResponse => {
      this.editedGood = goodResponse.goodDetails;
      this.isLoading = false;
    })
  }

  public Close() {
    this.activeModal.close('Close click')
  }

  public SaveAndClose() {
    this.isLoading = true;
    if (this.goodId == undefined) {
      // new good
      this.goodsService.AddGood(new AddGoodRequest(this.editedGood))
        .subscribe(addGoodResponse => {
          this.isLoading = false;
          this.editedGood.id = addGoodResponse.addedGoodId;
          this.activeModal.close(this.editedGood);
        });
    }
    else {
      this.goodsService.SaveGoodDetails(this.editedGood)
        .subscribe(() => {
          this.isLoading = false;
          this.activeModal.close('Close click');
        });
    }
  }
}
