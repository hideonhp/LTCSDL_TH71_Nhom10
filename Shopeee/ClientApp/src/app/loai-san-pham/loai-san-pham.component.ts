import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-loai-san-pham',
  templateUrl: './loai-san-pham.component.html',
  styleUrls: ['./loai-san-pham.component.css']
})
export class LoaiSanPhamComponent {
  public res: any;
  public lstLoaiSanPham: [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string){
    http.post('https://localhost:44357/api/LoaiSanPham/get-all', null).subscribe(result =>{
      this.res = result;
      this.lstLoaiSanPham = this.res.data;
      console.log(this.lstLoaiSanPham);
    }, error => console.error(error));
  }

  ngOnInit(){
  }
}
