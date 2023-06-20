import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ProductDto} from "../models/productDto"
@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  public products: ProductDto[] = [];

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    console.log('get');
    this.http.get<ProductDto[]>("https://fakestoreapi.com/products")
      .subscribe((productDto) => {
        this.products = productDto;
      });
  }
}
