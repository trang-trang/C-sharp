using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Xml.Serialization;

namespace DanhSachHocSinh
{
    internal class Func
    {
        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static T ReadFromXmlFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public static void NhapSinhVien(List<KetQuaThi> dssv)
        {
            Console.WriteLine("Sinh Vien ");
            KetQuaThi sv = new KetQuaThi();
            Console.WriteLine("Ma Sinh Vien :");
            sv.MaSinhVien = Console.ReadLine();

            Console.WriteLine("Ho Va Ten Dem : ");
            sv.HoVaTenDem = Console.ReadLine();

            Console.WriteLine("Ten : ");
            sv.Ten = Console.ReadLine();

            int Nam_Sinh;
            while (true)
            {
                Console.WriteLine("Nhap nam sinh: ");
                Nam_Sinh = Int32.Parse(Console.ReadLine());
                if (Nam_Sinh > 1990 && Nam_Sinh < 2020)
                {
                    sv.NamSinh = Nam_Sinh;
                    break;
                }
            }
            dssv.Add(sv);
        }

        public static void NhapMonHoc(MonHoc Mh)
        {
            Console.WriteLine("Mon Hoc");

            Console.WriteLine("Ma Mon Hoc :");
            Mh.MaMonHoc = Console.ReadLine();

            Console.WriteLine("Ten Mon Hoc :");
            Mh.TenMonHoc = Console.ReadLine();
        }

        public static void NhapDiemMonhoc(KetQuaThi Diem)
        {
            Console.WriteLine("Diem kiem tra:");
            Console.WriteLine("Diem kiem tra mieng :");
            float kt;
            while (true)
            {
                Console.WriteLine("Nhap diem:");
                kt = float.Parse(Console.ReadLine());
                if (kt > 10)
                {
                    Console.WriteLine("Ban da nhap sai!!!\nVui long nhap lai!");
                }
                else
                {
                    Diem.kt_mieng = kt;
                    break;
                }
            }
            Console.WriteLine("Diem kiem tra 15 phut :");
            while (true)
            {
                Console.WriteLine("Nhap diem:");
                kt = float.Parse(Console.ReadLine());
                if (kt > 10)
                {
                    Console.WriteLine("Ban da nhap sai!!!\nVui long nhap lai!");
                }
                else
                {
                    Diem.kt_15_phut = kt;
                    break;
                }
            }

            Console.WriteLine("Diem kiem tra 30 phut :");
            while (true)
            {
                Console.WriteLine("Nhap diem:");
                kt = float.Parse(Console.ReadLine());
                if (kt > 10)
                {
                    Console.WriteLine("Ban da nhap sai!!!\nVui long nhap lai!");
                }
                else
                {
                    Diem.kt_30_phut = kt;
                    break;
                }
            }

            Console.WriteLine("Diem kiem tra 45 phut :");
            while (true)
            {
                Console.WriteLine("Nhap diem:");
                kt = float.Parse(Console.ReadLine());
                if (kt > 10)
                {
                    Console.WriteLine("Ban da nhap sai!!!\nVui long nhap lai!");
                }
                else
                {
                    Diem.kt_45_phut = kt;
                    break;
                }
            }

            Diem.DiemTb = (Diem.kt_mieng + Diem.kt_15_phut + Diem.kt_30_phut * 2 + Diem.kt_45_phut * 3) / 7;
            Console.WriteLine("Diem trung binh :" + Diem.DiemTb);

            if (Diem.DiemTb >= 5)
            {
                Diem.KetQua = "Qua mon";
                Console.WriteLine("Ket qua: " + Diem.KetQua);
            }
            else
            {
                Diem.KetQua = "Hoc lai";
                Console.WriteLine("Ket qua: " + Diem.KetQua);
            }
        }
    }
}