import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'dang-nhap-component',
  templateUrl: './dang-nhap.component.html'
})
export class DangNhapComponent {
    TenDangNhap:Text =null;
    MatKhau:Text =null;
    result:any =[];
  
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string){
    }

    dangnhap()
    {
        var x ={
            TenDangNhap: this.TenDangNhap,
            MatKhau: this.MatKhau
        };
    
        this.http.post('https://localhost:44357/api/NguoiDung/NguoiDung_DangNhap_Select', x).subscribe(result =>{
        var res:any = result;
        console.log(res);
        this.result = res.data;
        
        if (res.data.find(s => s.idTypeUser == 1)){
          alert("Đăng Nhập thành công với tư cách QUẢN TRỊ VIÊN !!!")
          window.open("https://localhost:44357/admin","_self")
        }else if(res.data.find(s => s.idTypeUser == 2)){
          alert("Đăng Nhập thành công với tư cách KHÁCH HÀNG THƯỢNG ĐẲNG !!!")
          window.open("https://localhost:44357/khach-hang","_self")
        }else{
          alert("Đăng Nhập thất bại !!!")
          window.open("https://localhost:44357/fail-login","_self")
        }
      }, error => console.error(error));
    }
  
}