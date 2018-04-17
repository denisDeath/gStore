import {Component, Input, OnInit} from '@angular/core';
import {AddEntityRequest} from '../../../../models/common/add-entity-request';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {GoodCategoriesService} from '../../../../services/dicts/good-categories/good-categories.service';
import {GetEntityDetailsRequest} from '../../../../models/common/get-entity-details-request';
import {GoodCategory} from '../../../../models/dicts/good-categories/good-category';
import {SaveEntityDetailsRequest} from '../../../../models/common/save-entity-details-request';

@Component({
  selector: 'app-good-category-edit',
  templateUrl: './good-category-edit.component.html',
  styleUrls: ['./good-category-edit.component.css']
})
export class GoodCategoryEditComponent implements OnInit {

  @Input() goodCategoryId: number;
  editedGoodCategory: GoodCategory;
  isLoading: boolean;

  constructor(public activeModal: NgbActiveModal,
              private goodCategoriesService: GoodCategoriesService) {
  }

  ngOnInit() {
    this.editedGoodCategory = new GoodCategory();
    if (this.goodCategoryId === undefined) {
      this.isLoading = false;
      return;
    }

    this.isLoading = true;
    this.goodCategoriesService.getDetails(new GetEntityDetailsRequest(this.goodCategoryId)).subscribe(response => {
      this.editedGoodCategory = response.entityDetails;
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
    if (this.goodCategoryId === undefined) {
      // new good
      this.goodCategoriesService.add(new AddEntityRequest(this.editedGoodCategory))
        .subscribe(addEntityResponse => {
          this.isLoading = false;
          this.editedGoodCategory.id = addEntityResponse.addedEntityId;
          this.activeModal.close(this.editedGoodCategory);
        });
    } else {
      this.goodCategoriesService.save(new SaveEntityDetailsRequest(this.editedGoodCategory))
        .subscribe(() => {
          this.isLoading = false;
          this.activeModal.close(this.editedGoodCategory);
        });
    }
  }

}
