import {Component, Input, OnInit} from '@angular/core';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {Good} from '../../../../models/dicts/goods/good';
import {GoodsService} from '../../../../services/dicts/goods/goods.service';
import {AddGoodRequest} from '../../../../models/dicts/goods/add-good-request';
import {GetGoodDetailsRequest} from '../../../../models/dicts/goods/get-good-details-request';
import {SaveGoodDetailsRequest} from '../../../../models/dicts/goods/save-good-details-request';

@Component({
  selector: 'app-good-edit',
  templateUrl: './good-edit.component.html',
  styleUrls: ['./good-edit.component.css']
})
export class GoodEditComponent implements OnInit {

  @Input() entityId: number;
  editedGood: Good;
  isLoading: boolean;

  constructor(public activeModal: NgbActiveModal,
              private goodsService: GoodsService) {
  }

  ngOnInit() {
    this.editedGood = new Good();
    if (this.entityId === undefined) {
      this.isLoading = false;
      return;
    }

    this.isLoading = true;
    this.goodsService.GetGoodDetails(new GetGoodDetailsRequest(this.entityId)).subscribe(goodResponse => {
      this.editedGood = goodResponse.entityDetails;
      this.isLoading = false;
    });
  }

  public Close() {
    if (!confirm('Вы хотите выйти без сохранения?')) {
      return;
    }
    this.activeModal.close(null);
  }

  public SaveAndClose() {
    this.isLoading = true;
    if (this.entityId === undefined) {
      // new good
      this.goodsService.AddGood(new AddGoodRequest(this.editedGood))
        .subscribe(addGoodResponse => {
          this.isLoading = false;
          this.editedGood.id = addGoodResponse.addedEntityId;
          this.activeModal.close(this.editedGood);
        });
    } else {
      this.goodsService.SaveGoodDetails(new SaveGoodDetailsRequest(this.editedGood))
        .subscribe(() => {
          this.isLoading = false;
          this.activeModal.close(this.editedGood);
        });
    }
  }
}
