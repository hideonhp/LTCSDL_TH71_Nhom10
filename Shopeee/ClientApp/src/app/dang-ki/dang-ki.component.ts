import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'dang-ki-component',
  templateUrl: './dang-ki.component.html'
})
export class DangKiComponent {
    TenDangNhap:Text =null;
    IdTypeUser:Text = null;
    MatKhau:Text =null;
    HoVaTen:Text =null;
    SoDienThoai:Text =null;
    DiaChi:Text =null;
    result:any =[];
  
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string){
    }

    dangki()
    {
        var x ={
            TenDangNhap: this.TenDangNhap,
            MatKhau: this.MatKhau,
            IdTypeUser: 2,
            HoVaTen: this.HoVaTen,
            SoDienThoai: this.SoDienThoai,
            DiaChi: this.DiaChi
        };
    
        this.http.post('https://localhost:44357/api/NguoiDung/NguoiDung_Insert', x).subscribe(result =>{
        var res:any = result;
        console.log(res);
        this.result = res.data;
        alert("Tạo tài khoản thành công, hãy quay lại đăng nhập")
        window.open("https://localhost:44357/dang-nhap","_self")
      }, error => console.error(error));
    }
  
}