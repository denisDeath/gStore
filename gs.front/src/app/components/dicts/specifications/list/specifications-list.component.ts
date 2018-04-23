import {Component, OnInit, ViewChild} from '@angular/core';
import {DictPanelComponent} from "../../../common/dict-panel/dict-panel.component";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {Specification} from "../../../../models/dicts/specifications/specification";
import {SpecificationsService} from "../../../../services/dicts/specifications/specifications.service";
import {RemoveRequest} from "../../../../models/dicts/specifications/remove-request";

@Component({
  selector: 'app-specifications-list',
  templateUrl: './specifications-list.component.html',
  styleUrls: ['./specifications-list.component.css']
})
export class SpecificationsListComponent implements OnInit {

  @ViewChild('topPanel') topPanel: DictPanelComponent;

  specifications: Specification[];
  isLoading: boolean;

  constructor(private modalService: NgbModal,
              private dataService: SpecificationsService) { }

  ngOnInit() {
    this.topPanel.InitDelegates(this.Add, this.Load);
    this.Load();
  }

  public Load() {
    this.isLoading = true;
    this.specifications = [];
    this.dataService.Get()
      .subscribe(getsResponse => {
        if (!getsResponse) {
          return;
        }
        this.isLoading = false;
        this.specifications = getsResponse.entities;
        this.sort();
      });
  }

  public Add() {
    // const modalRef = this.modalService.open(EditComponent);
    // modalRef.result.then(new => {
    //   this.features.push(new);
    // })
    //   .catch(e => {
    //   });
  }

  public Remove(entityId: number) {
    if (!confirm('Вы хотите удалить характеристику и её значения?')) {
      return;
    }

    this.isLoading = true;
    this.dataService.Remove(new RemoveRequest([entityId]))
      .subscribe(_ => {
        this.isLoading = false;
        this.specifications.splice(this.getGoodIndexById(entityId), 1);
      });
  }

  public Edit(storeId: number) {
    // const modalRef = this.modalService.open(EditComponent);
    // modalRef.componentInstance.storeId = storeId;
    //
    // modalRef.result.then(editedGood => {
    //   this.features.splice(this.getGoodIndexById(storeId), 1);
    //   this.features.push(editedGood);
    //   this.sort();
    // })
    //   .catch(e => {
    //   });
  }

  private getGoodIndexById(storeId: number): number {
    const index = this.specifications.findIndex((g, _, __) => {
      if (g.id === storeId) {
        return true;
      }
    });
    return index;
  }

  private sort() {
    this.specifications.sort((s1, s2) => s1.name > s2.name ? 1 : 0);
  }

}
