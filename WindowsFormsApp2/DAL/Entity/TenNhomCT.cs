using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.DAL.Entity
{
    
    class TenNhomCT
    {

        public string tennhom { get; set; }
        public string tentrongnhom { get; set; }
        public string email { get; set; }
        public string sodienthoai { get; set; }
        public string diachi { get; set; }
        
        public static List<TenNhomCT> GetListFromFile(string pathData, string tennhom)
        {
            var arrayLines = File.ReadAllLines(pathData);
            List<TenNhomCT> ketQua = new List<TenNhomCT>();
            foreach (var line in arrayLines)
            {
                var lsValue = line.Split(new char[] { '#' });
                var Nhom = new TenNhomCT
                {
                    tennhom = lsValue[0],
                    tentrongnhom = lsValue[1],
                    email = lsValue[2],
                    sodienthoai = lsValue[3],
                    diachi = lsValue[4]
                };
                if (Nhom.tennhom == tennhom)
                    ketQua.Add(Nhom);
            }
            return ketQua;
        }
        public static List<TenNhomCT> GetListFromFilesdt(string pathData, string sdt)
        {
            var arrayLines = File.ReadAllLines(pathData);
            List<TenNhomCT> ketQua = new List<TenNhomCT>();
            foreach (var line in arrayLines)
            {
                var lsValue = line.Split(new char[] { '#' });
                var Nhom = new TenNhomCT
                {
                    tennhom = lsValue[0],
                    tentrongnhom = lsValue[1],
                    email = lsValue[2],
                    sodienthoai = lsValue[3],
                    diachi = lsValue[4]
                };
                if (Nhom.sodienthoai == sdt)
                    ketQua.Add(Nhom);
            }
            return ketQua;
        }
    }
}
