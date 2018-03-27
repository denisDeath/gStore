import { Injectable } from '@angular/core';
import {Observable} from "rxjs/Observable";
import {Good} from "../models/good";
import {of} from "rxjs/observable/of";

@Injectable()
export class GoodsService {

  private goods = [
    {
      id: 0,
      name: "good1",
      description:"d1",
      imageUris: ["https://as.ftcdn.net/r/v1/pics/ea2e0032c156b2d3b52fa9a05fe30dedcb0c47e3/landing/images_photos.jpg",
        "https://www.gettyimages.ca/gi-resources/images/Homepage/Hero/UK/CMS_Creative_164657191_Kingfisher.jpg"]},
    {
      id: 1,
      name: "good2",
      description:"d2",
      imageUris: ["https://images.pexels.com/photos/248797/pexels-photo-248797.jpeg?auto=compress&cs=tinysrgb&h=350",
        "https://cdn.pixabay.com/photo/2017/01/06/19/15/soap-bubble-1958650_960_720.jpg"]}];

  constructor() { }

  public GetGoods(): Observable<Good[]> {
    return of<Good[]>(this.goods);
  }

  public GetGoodDetails(goodId: number): Observable<Good> {
    return of<Good>(this.goods[goodId]);
  }
}
