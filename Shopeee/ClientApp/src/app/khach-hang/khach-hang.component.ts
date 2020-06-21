import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $:any;
@Component({
  selector: 'khach-hang',
  templateUrl: './khach-hang.component.html',
})
export class KhachHangComponent implements OnInit {
  productX: any ={
    data:[],
    totalRecord:0,
    page:0,
    size:5,
    totalPages:0
  }
  productY: any ={
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
    this.searchProductX(2);
  }
  searchProductX(cPage){
    let x={
      page:cPage,
      size:5,
      keyword:""
    }
    this.http.post("https://localhost:44357/api/SanPham/tim-kiem-san-pham", x).subscribe(result =>{
      this.productX = result;
      this.productX = this.productX.data;
      console.log(this.productX);
    },error=>console.error(error));
  }
  searchNextSp(){
    if(this.productX.page < this.productX.totalPages){
      let nextPage = this.productX.page+1;
      let x={
        page:nextPage,
        size:5,
        keyword:""
      }
      this.http.post("https://localhost:44357/api/SanPham/tim-kiem-san-pham", x).subscribe(result =>{
        this.productX = result;
        this.productX = this.productX.data;
      },error=>console.error(error));
    }
    else{
      alert("Bạn đang ở trang cuối cùng !")
    }
  }
  searchPreviousSp(){
    if(this.productX.page <= this.productX.totalPages){
      let prePage = this.productX.page-1;
      if (prePage == 0 ){
        alert("Bạn đang ở trang đầu tiên !")
      }else{
        let x={
          page:prePage,
          size:5,
          keyword:""
        }
        this.http.post("https://localhost:44357/api/SanPham/tim-kiem-san-pham", x).subscribe(result =>{
          this.productX = result;
          this.productX = this.productX.data;
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
        this.productY ={
          IdLoai : 0,
          ten : null,
          moTa : null,
          gia : null
        }
      }else{
        this.isEdit= true;
        console.log(index)
        console.log(this.productX.data[index])
        this.productY = this.productX.data[index];
      }
      $('#exampleModalSp').modal("show");
    }
    addProductX()
    {
      var x = this.productY;
      this.http.post("https://localhost:44357/api/SanPham/tao-san-pham", x).subscribe(result =>{
          var res:any = result;
          if(res.success){
            this.productX = res.data;
            this.isEdit = true;
            this.searchProductX(1);
            alert("Thêm sản phẩm thành công !!!")
          }
        },error=>console.error(error));
    }
  
}
