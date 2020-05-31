import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoaiSanPhamComponent } from './loai-san-pham.component';

describe('LoaiSanPhamComponent', () => {
  let component: LoaiSanPhamComponent;
  let fixture: ComponentFixture<LoaiSanPhamComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoaiSanPhamComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoaiSanPhamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
