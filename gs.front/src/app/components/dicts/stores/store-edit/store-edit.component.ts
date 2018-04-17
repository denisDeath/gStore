import {Component, Input, OnInit} from '@angular/core';
import {Store} from '../../../../models/dicts/stores/store';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {GetStoreDetailsRequest} from '../../../../models/dicts/stores/get-store-details-request';
import {StoresService} from '../../../../services/dicts/stores/stores.service';
import {AddStoreRequest} from '../../../../models/dicts/stores/add-store-request';
import {SaveStoreDetailsRequest} from '../../../../models/dicts/stores/save-store-details-request';

@Component({
  selector: 'app-store-edit',
  templateUrl: './store-edit.component.html',
  styleUrls: ['./store-edit.component.css']
})
export class StoreEditComponent implements OnInit {

  @Input() storeId: number;
  editedStore: Store;
  isLoading: boolean;

  constructor(public activeModal: NgbActiveModal,
              private storesService: StoresService) { }

  ngOnInit() {
    this.editedStore = new Store();
    if (this.storeId === undefined) {
      this.isLoading = false;
      return;
    }

    this.isLoading = true;
    this.storesService.GetStoreDetails(new GetStoreDetailsRequest(this.storeId)).subscribe(response => {
      this.editedStore = response.entityDetails;
      this.isLoading = false;
    });
  }

  public Close() {
    this.activeModal.close(this.editedStore);
  }

  public SaveAndClose() {
    this.isLoading = true;
    if (this.storeId === undefined) {
      // new entityDetails
      this.storesService.AddStore(new AddStoreRequest(this.editedStore))
        .subscribe(addStoreResponse => {
          this.isLoading = false;
          this.editedStore.entityId = addStoreResponse.addedId;
          this.activeModal.close(this.editedStore);
        });
    } else {
      this.storesService.SaveStoreDetails(new SaveStoreDetailsRequest(this.editedStore))
        .subscribe(() => {
          this.isLoading = false;
          this.activeModal.close(this.editedStore);
        });
    }
  }
}
