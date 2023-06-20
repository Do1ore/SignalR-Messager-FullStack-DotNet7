export class ProductDto {
  public id: number = 0;
  public title: string = "";
  public price: number = 0;
  public description: string = "";
  public category: string = "";
  public image: string = "";
  public rating: Rating = new Rating();
}

class Rating {
  public count: number = 0;
  public rate: number = 0;
}
