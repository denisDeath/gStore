import { Component, OnInit } from '@angular/core';
import {GoodsIncomingService} from "../../../../services/docs/store/goodsIncoming/goods-incoming.service";

@Component({
  selector: 'app-goods-incoming-list',
  templateUrl: './goods-incoming-list.component.html',
  styleUrls: ['./goods-incoming-list.component.css']
})
export class GoodsIncomingListComponent implements OnInit {

  documents: any[];
  isLoading: boolean;

  constructor(private docsService: GoodsIncomingService) { }

  ngOnInit() {
    this.Load();
  }

  public Add() {

  }

  public Load() {
    this.documents = [];
    this.isLoading = true;
    this.docsService.GetDocuments().subscribe(response => {
      this.isLoading = false;
      if (!response) {
        return;
      }

      this.documents = response.documents;
    });
  }

  public Edit(id: number) {

  }

  public Remove(id: number) {

  }

}
