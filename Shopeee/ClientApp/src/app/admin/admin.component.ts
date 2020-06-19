import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $:any;

@Component({
  selector: 'admin',
  templateUrl: './admin.component.html',
})
export class AdminComponent implements OnInit {
  NguoiDungX: any = {
    data: [],
    totalRecord: 0,
    pageUs: 0,
    sizeUs: 5,
    totalPages: 0
  }
  NguoiDung: any = {
    IdUser: 0,
    IdTypeUser: 0,
    TenDangNhap: null,
    MatKhau: null,
    HoVaTen: null,
    SoDienThoai: null,
    DiaChi: null
  }
  isEdit: boolean = true;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) { }
  ngOnInit() {
    this.searchNguoiDung(1);
  }
  searchNguoiDung(cPage) {
    let x = {
      pageUs: cPage,
      sizeUs: 5,
      keywordUs: ""
    }
    this.http.post("https://localhost:44357/api/NguoiDung/tim-kiem-nguoi-dung", x).subscribe(result => {
      this.NguoiDungX = result;
      this.NguoiDungX = this.NguoiDungX.data;
      console.log(this.NguoiDungX);
    }, error => console.error(error));
  }
  searchNguoiDungNext() {
    if (this.NguoiDungX.pageUs < this.NguoiDungX.totalPages) {
      let nextPage = this.NguoiDungX.pageUs + 1;
      let x = {
        pageUs: nextPage,
        sizeUs: 5,
        keywordUs: ""
      }
      this.http.post("https://localhost:44357/api/NguoiDung/tim-kiem-nguoi-dung", x).subscribe(result => {
        this.NguoiDungX = result;
        this.NguoiDungX = this.NguoiDungX.data;
      }, error => console.error(error));
    }
    else {
      alert("Bạn đang ở trang cuối cùng !")
    }
  }
  searchNguoiDungPrevious() {
    if (this.NguoiDungX.pageUs <= this.NguoiDungX.totalPages) {
      let nextPage = this.NguoiDungX.pageUs - 1;
      if(nextPage ==0){
        alert("Bạn đang ở trang đầu tiên !")
      }else{
        let x = {
          pageUs: nextPage,
          sizeUs: 5,
          keywordUs: ""
        }
        this.http.post("https://localhost:44357/api/NguoiDung/tim-kiem-nguoi-dung", x).subscribe(result => {
          this.NguoiDungX = result;
          this.NguoiDungX = this.NguoiDungX.data;
        }, error => console.error(error));
      }
    }
    else {
      alert("Bạn đang ở trang đầu tiên !")
    }
  }
  openModalX(isNew, index) {
    if (isNew) {
      this.isEdit = false;
      this.NguoiDung = {
        IdTypeUser: 0,
        TenDangNhap: null,
        MatKhau: null,
        HoVaTen: null,
        SoDienThoai: null,
        DiaChi: null
      }
    } else {
      this.isEdit = true;
      console.log(index)
      console.log(this.NguoiDungX.data[index])
      this.NguoiDung = this.NguoiDungX.data[index];
    }
    $('#exampleModalX').modal("show");
  }
  addNguoiDung() {
    var x = this.NguoiDung;
    this.http.post("https://localhost:44357​/api​/NguoiDung​/tao-nguoi-dung", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.NguoiDungX = res.data;
        this.isEdit = true;
        this.searchNguoiDung(1);
        alert("Thêm sản phẩm thành công !!!")
      }
    }, error => console.error(error));
  }
  updateNguoiDung() {
    var x = this.NguoiDung;
    this.http.post("https://localhost:44357/api/NguoiDung/cap-nhap-nguoi-dung", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.NguoiDungX = res.data;
        this.isEdit = true;
        this.searchNguoiDung(1);
        alert("Cập nhập sản phẩm thành công !!!")
      }
    },error => console.error(error));
  }
  deleteNguoiDung() {
    var x = this.NguoiDung;
    this.http.post("https://localhost:44357/api/NguoiDung/xoa-nguoi-dung", x).subscribe(result => {
      var res: any = result;
      if (res.success) {
        this.NguoiDungX = res.data;
        this.searchNguoiDung(1);
        alert("Xóa sản phẩm thành công !!!")
      }
    }, error => console.error(error));
  }
}
