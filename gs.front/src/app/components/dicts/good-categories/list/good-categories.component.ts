import { Component, OnInit } from '@angular/core';
import {GoodCategoryEditComponent} from '../good-category-edit/good-category-edit.component';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {GoodCategoriesService} from '../../../../services/dicts/good-categories/good-categories.service';
import {GoodCategory} from '../../../../models/dicts/good-categories/good-category';
import {RemoveEntitiesRequest} from '../../../../models/dicts/good-categories/remove-entities-request';

@Component({
  selector: 'app-good-categories',
  templateUrl: './good-categories.component.html',
  styleUrls: ['./good-categories.component.css']
})
export class GoodCategoriesComponent implements OnInit {

  goodCategories: GoodCategory[];
  isLoading: boolean;

  constructor(private modalService: NgbModal,
              private goodCategoriesService: GoodCategoriesService) { }

  ngOnInit() {
    this.Load();
  }

  public Load() {
    this.isLoading = true;
    this.goodCategories = [];
    this.goodCategoriesService.GetAll()
      .subscribe(getEntitiesResponse => {
        if (!getEntitiesResponse) {
          return;
        }
        this.isLoading = false;
        this.goodCategories = getEntitiesResponse.entities;
        this.sort();
      });
  }

  public Add() {
    const modalRef = this.modalService.open(GoodCategoryEditComponent);
    modalRef.result.then(newGoodCategory => {
      if (newGoodCategory === null) {
        return;
      }

      this.goodCategories.push(newGoodCategory);
    })
      .catch(e => {
      });
  }

  public Remove(goodCategoryId: number) {
    if (!confirm('Вы хотите удалить товар?')) {
      return;
    }

    this.isLoading = true;
    this.goodCategoriesService.Remove(new RemoveEntitiesRequest([goodCategoryId]))
      .subscribe(_ => {
        this.isLoading = false;
        this.goodCategories.splice(this.getGoodCategoryIndexById(goodCategoryId), 1);
      });
  }

  public Edit(goodCategoryId: number) {
    const modalRef = this.modalService.open(GoodCategoryEditComponent);
    modalRef.componentInstance.goodCategoryId = goodCategoryId;

    modalRef.result.then(editedGoodCategory => {
      if (editedGoodCategory === null) {
        return;
      }

      this.goodCategories.splice(this.getGoodCategoryIndexById(goodCategoryId), 1);
      this.goodCategories.push(editedGoodCategory);
      this.sort();
    })
      .catch(e => {
      });
  }

  private getGoodCategoryIndexById(goodCategoryId: number): number {
    const index = this.goodCategories.findIndex((g, _, __) => {
      if (g.id === goodCategoryId) {
        return true;
      }
    });
    return index;
  }

  private sort() {
    this.goodCategories.sort((s1, s2) => s1.name > s2.name ? 1 : 0);
  }

}
