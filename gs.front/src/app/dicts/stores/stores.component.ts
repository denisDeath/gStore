import { Component, OnInit } from '@angular/core';
import {Store} from "../../models/dicts/stores/store";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {StoresService} from "../../services/dicts/stores/stores.service";
import {RemoveStoreRequest} from "../../models/dicts/stores/remove-store-request";
import {StoreEditComponent} from "../store-edit/store-edit.component";
// import {RemoveStoresRequest} from "../../models/remove-stores-request";

@Component({
  selector: 'app-stores',
  templateUrl: './stores.component.html',
  styleUrls: ['./stores.component.css']
})
export class StoresComponent implements OnInit {

  stores: Store[];
  isLoading: boolean;

  constructor(private modalService: NgbModal,
              private storesService: StoresService) { }

  ngOnInit() {
    this.Load();
  }

  public Load() {
    this.isLoading = true;
    this.stores = [];
    this.storesService.GetStores()
      .subscribe(getStoresResponse => {
        this.isLoading = false;
        this.stores = getStoresResponse.stores;
        this.sort();
      });
  }

  public Add() {
    const modalRef = this.modalService.open(StoreEditComponent);
    modalRef.result.then(newStore => {
      this.stores.push(newStore);
    })
    .catch(e => {
    });
  }

  public Remove(storeId: number) {
    if (!confirm('Вы хотите удалить товар?')) {
      return;
    }

    this.isLoading = true;
    this.storesService.Remove(new RemoveStoreRequest(storeId))
      .subscribe(_ => {
        this.isLoading = false;
        this.stores.splice(this.getGoodIndexById(storeId), 1);
      });
  }

  public Edit(storeId: number) {
    const modalRef = this.modalService.open(StoreEditComponent);
    modalRef.componentInstance.storeId = storeId;

    modalRef.result.then(editedGood => {
      this.stores.splice(this.getGoodIndexById(storeId), 1);
      this.stores.push(editedGood);
      this.sort();
    })
      .catch(e => {
      });
  }

  private getGoodIndexById(storeId: number): number {
    let index = this.stores.findIndex((g, _, __) => {
      if (g.id == storeId){
        return true;
      }
    });
    return index;
  }

  private sort() {
    this.stores.sort((s1, s2) => s1.name > s2.name ? 1 : 0);
  }
}
