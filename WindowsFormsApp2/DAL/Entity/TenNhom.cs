using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.DAL.Entity
{
    class TenNhom
    {

        public string tennhom { get; set; }
        public virtual ICollection<TenNhomCT> ListTenNhomCT { get; set; }
        public  List<TenNhom> ListTenNhom { get; set; }
        public static List<TenNhom> GetListFromFile(string pathData)
        {
            var arrayLines = File.ReadAllLines(pathData);
            List<TenNhom> ketQua = new List<TenNhom>();
            foreach (var line in arrayLines)
            {
                  var lsValue = line.Split(new char[] { '#' });
                //   Console.WriteLine(line);
                var Nhom = new TenNhom
                {
                    tennhom = lsValue[0],
                   
                    
                };
                ketQua.Add(Nhom);
            }
            return ketQua;
        }
    }
}
