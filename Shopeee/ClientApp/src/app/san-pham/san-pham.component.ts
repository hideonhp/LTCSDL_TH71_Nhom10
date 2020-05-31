import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $:any;

@Component({
  selector: 'app-san-pham',
  templateUrl: './san-pham.component.html',
  styleUrls: ['./san-pham.component.css']
})
export class SanPhamComponent implements OnInit {

  products: any ={
    data:[],
    totalRecord:0,
    page:0,
    size:5,
    TotalPage:0
  }
  product: any ={
    idSanPham : 2,
    IdLoai : 2,
    ten : "Samsung S20",
    moTa : "Điện thoại cùi bắp",
    gia : 1200
  }
  isEdit : boolean = true;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
    this.searchProduct(1);
  }
    searchProduct(cPage){
      let x={
        page:cPage,
        size:5,
        keyword:""
      }
      this.http.post("https://localhost:44357/api/SanPham/tim-kiem-san-pham", x).subscribe(result =>{
        this.products = result;
        this.products = this.products.data;
      },error=>console.error(error));
    }
    searchNext(){
      if(this.products.page<this.products.TotalPage){
        let nextPage = this.products.page+1;
        let x={
          page:nextPage,
          size:5,
          keyword:""
        }
        this.http.post("https://localhost:44357/api/SanPham/tim-kiem-san-pham", x).subscribe(result =>{
          this.products = result;
          this.products = this.products.data;
        },error=>console.error(error));
      }
      else{
        alert("Bạn đang ở trang cuối cùng !")
      }
    }
    searchPrevious(){
      if(this.products.page<this.products.TotalPage){
        let nextPage = this.products.page-1;
        let x={
          page:nextPage,
          size:5,
          keyword:""
        }
        this.http.post("https://localhost:44357/api/SanPham/tim-kiem-san-pham", x).subscribe(result =>{
          this.products = result;
          this.products = this.products.data;
        },error=>console.error(error));
      }
      else{
        alert("Bạn đang ở trang đầu tiên !")
      }
    }
    openModal(isNew, index)
    {
      if(isNew)
      {
        this.isEdit = false;
        this.product ={
          IdLoai : 0,
          ten : null,
          moTa : null,
          gia : null
        }
      }else{
        this.isEdit= true;
        this.product = this.products.data[index];
      }
      $('#exampleModal').modal("show");
    }
    addProduct()
    {
      var x = this.product;
      this.http.post("https://localhost:44357/api/SanPham/tao-san-pham", x).subscribe(result =>{
          var res:any = result;
          if(res.success){
            this.products = res.data;
            this.isEdit = true;
            this.searchProduct(1);
          }
        },error=>console.error(error));
    }
}
