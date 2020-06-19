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
    totalPages:0
  }
  product: any ={
    idSanPham : 0,
    IdLoai : 0,
    ten : null,
    moTa : null,
    gia : null
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
        console.log(this.products);
      },error=>console.error(error));
    }
    searchNext(){
      if(this.products.page < this.products.totalPages){
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
      if(this.products.page <= this.products.totalPages){
        let prePage = this.products.page-1;
        if (prePage == 0 ){
          alert("Bạn đang ở trang đầu tiên !")
        }else{
          let x={
            page:prePage,
            size:5,
            keyword:""
          }
          this.http.post("https://localhost:44357/api/SanPham/tim-kiem-san-pham", x).subscribe(result =>{
            this.products = result;
            this.products = this.products.data;
          },error=>console.error(error));
        }
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
        console.log(index)
        console.log(this.products.data[index])
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
            alert("Thêm sản phẩm thành công !!!")
          }
        },error=>console.error(error));
    }
    updateProduct()
    {
      var x = this.product;
      this.http.post("https://localhost:44357/api/SanPham/cap-nhap-san-pham", x).subscribe(result =>{
          var res:any = result;
          if(res.success){
            this.products = res.data;
            this.isEdit = true;
            this.searchProduct(1);
            alert("Cập nhập sản phẩm thành công !!!")
          }
        },error=>console.error(error));
    }
    deleteProduct()
    {
      var x = this.product;
      this.http.post("https://localhost:44357/api/SanPham/xoa-san-pham", x).subscribe(result =>{
          var res:any = result;
          if(res.success){
            this.products = res.data;
            this.searchProduct(1);
            alert("Xóa sản phẩm thành công !!!")
          }
        },error=>console.error(error));
    }
}
