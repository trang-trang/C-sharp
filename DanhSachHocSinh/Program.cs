using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSachHocSinh
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 5; i++)
            //{
            //    Sv[i] = new SinhVien();
            //    Console.WriteLine("Sinh Vien " + (i + 1));
            //    Console.WriteLine("Nhap ma sinh vien : ");
            //    Sv[i].MaSinhVien = Console.ReadLine();
            //    Console.WriteLine("Nhap ho va ten dem sinh vien : ");
            //    Sv[i].HoVaTenDem = Console.ReadLine();
            //    Console.WriteLine("Nhap ten sinh vien : ");
            //    Sv[i].Ten = Console.ReadLine();
            //    Console.WriteLine("Nhap nam sinh vien : ");
            //    Sv[i].NamSinh = Console.ReadLine();
            //}
            string password = "trangle";
            Console.WriteLine("Nhap mat khau:");
            
            while (true)
            {
                string tr = Console.ReadLine();
                if (password == tr)
                {
                    Console.WriteLine("Ban da dang nhap thanh cong!!!!");
                    goto main;
                }
            }
            main:
            string Chon;
            List<KetQuaThi> dssv = new List<KetQuaThi>();
            dssv = Func.ReadFromXmlFile<List<KetQuaThi>>("dulieu.dat");
            MonHoc Mh = new MonHoc();
            KetQuaThi Diem = new KetQuaThi();
            Console.WriteLine("Chon so sau day:\n 1.Nhap Sinh Vien\n 2.Nhap mon hoc\n 3.Nhap diem mon hoc\n 0.Danh sach");
            Console.Write("Chon: ");
            Chon = Console.ReadLine();
            
            while (Chon != "")
            {
                switch (Chon)
                {
                    case "1":
                        Func.NhapSinhVien(dssv);
                        Func.NhapMonHoc(Mh);
                        break;
                    case "2":
                        Func.NhapMonHoc(Mh);
                        Func.NhapDiemMonhoc(Diem);
                        break;
                    case "3":
                        if (dssv.Count > 0)
                        {
                            int i = 0;
                            foreach (KetQuaThi item in dssv)
                            {
                                Console.WriteLine("Sinh vien {4}: \nMa Sinh Vien: {0}\n Ho Va Ten : {1} {2}\n Nam Sinh: {3}", item.MaSinhVien, item.HoVaTenDem, item.Ten, item.NamSinh,i + 1);
                                i++;
                            }
                            Console.WriteLine("Moi ban chon sinh vien de nhap diem");
                            var tmp = int.Parse(Console.ReadLine());
                            Func.NhapDiemMonhoc(dssv[tmp-1]);
                           
                        }
                        else
                        {
                            Console.WriteLine("Ban chua nhap sinh vien nao!!!");
                            Console.WriteLine("Vui long nhap sinh vien!");
                        }

                        break;
                   
                    case "0":
                        foreach (KetQuaThi item in dssv)
                        {
                            Console.WriteLine(" Ma Sinh Vien: {0}\n Ho Va Ten : {1} {2}\n Nam Sinh: {3}", item.MaSinhVien,item.HoVaTenDem,item.Ten,item.NamSinh);
                        }
                        break;
                    //case "5":
                    //    foreach (KetQuaThi item in dssv)
                    //    {
                    //        Console.WriteLine(" Ma Sinh Vien: {0}\n Ho Va Ten : {1} {2}\n Nam Sinh: {3}", item.MaSinhVien, item.HoVaTenDem, item.Ten, item.NamSinh);
                    //    }
                    //    break;

                }
                Console.WriteLine("Chon so sau day:\n 1.Nhap Sinh Vien\n 2.Nhap mon hoc\n 3.Nhap diem mon hoc\n 0.Danh sach");
                Console.Write("Chon: ");
                Chon = Console.ReadLine();
            }
            Func.WriteToXmlFile("dulieu.dat",dssv);
        } 
    }
}
