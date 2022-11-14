export class Product {

    ProductId: number;
    Name: string;
    Price: number;
    Country: string;
    ProductTypeId: number;

    constructor (id: number, _name: string, _price: number, _country: string, _ProductTypeId: number){
        this.ProductId = id;
        this.Name = _name;
        this.Price = _price;
        this.Country = _country;
    }
  }

