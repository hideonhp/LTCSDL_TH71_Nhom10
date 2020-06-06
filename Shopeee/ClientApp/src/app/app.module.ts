import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoaiSanPhamComponent } from './loai-san-pham/loai-san-pham.component';
import { SanPhamComponent } from './san-pham/san-pham.component';
import { DangNhapComponent } from './dang-nhap/dang-nhap.component';
import { AdminComponent } from './admin/admin.component';
import { FailLoginComponent } from './fail-login/fail-login.component';
import { KhachHangComponent } from './khach-hang/khach-hang.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    LoaiSanPhamComponent,
    SanPhamComponent,
    FetchDataComponent,
    DangNhapComponent,
    AdminComponent,
    FailLoginComponent,
    KhachHangComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'loai-san-pham', component: LoaiSanPhamComponent },
      { path: 'search-product', component: SanPhamComponent },
      { path: 'dang-nhap', component: DangNhapComponent },
      { path: 'admin', component: AdminComponent},
      { path: 'fail-login', component: FailLoginComponent},
      { path: 'khach-hang', component: KhachHangComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
