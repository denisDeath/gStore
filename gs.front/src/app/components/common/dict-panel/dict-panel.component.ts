import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dict-panel',
  templateUrl: './dict-panel.component.html',
  styleUrls: ['./dict-panel.component.css']
})
export class DictPanelComponent implements OnInit {
  private addFunc: () => void;
  private refreshFunc: () => void;

  constructor() { }

  ngOnInit() {
  }

  public InitDelegates(addFunc: () => void, refreshFunc: () => void) {
    this.addFunc = addFunc;
    this.refreshFunc = refreshFunc;
  }

  Add() {
    if (this.addFunc) {
      this.addFunc();
    }
  }

  Refresh() {
    if (this.refreshFunc) {
      this.refreshFunc();
    }
  }

}
