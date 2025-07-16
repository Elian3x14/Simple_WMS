namespace TKS_intern_client.Services
{
    public static class PrintHelper
    {
        private static readonly string[] ChuSo = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        private static readonly string[] DonVi = { "", "nghìn", "triệu", "tỷ" };

        public static string ToWords(decimal number)
        {
            if (number == 0) return "Không đồng";

            var s = ((long)Math.Floor(number)).ToString();
            var groups = new List<string>();
            while (s.Length > 0)
            {
                int len = s.Length >= 3 ? 3 : s.Length;
                groups.Insert(0, s.Substring(s.Length - len, len));
                s = s.Remove(s.Length - len, len);
            }

            string result = "";
            for (int i = 0; i < groups.Count; i++)
            {
                string groupText = DocBaSo(groups[i]);
                if (!string.IsNullOrEmpty(groupText))
                {
                    result += groupText + " " + DonVi[groups.Count - i - 1] + " ";
                }
            }

            result = result.Trim();
            return char.ToUpper(result[0]) + result.Substring(1);
        }

        private static string DocBaSo(string so)
        {
            while (so.Length < 3)
                so = "0" + so;

            int tram = int.Parse(so[0].ToString());
            int chuc = int.Parse(so[1].ToString());
            int donVi = int.Parse(so[2].ToString());

            string result = "";

            if (tram > 0)
            {
                result += ChuSo[tram] + " trăm";
                if (chuc == 0 && donVi > 0)
                    result += " linh";
            }
            else if (chuc > 0 || donVi > 0)
            {
                result += "không trăm";
                if (chuc == 0 && donVi > 0)
                    result += " linh";
            }

            if (chuc > 1)
            {
                result += " " + ChuSo[chuc] + " mươi";
                if (donVi == 1) result += " mốt";
                else if (donVi == 5) result += " lăm";
                else if (donVi > 0) result += " " + ChuSo[donVi];
            }
            else if (chuc == 1)
            {
                result += " mười";
                if (donVi == 1) result += " một";
                else if (donVi == 5) result += " lăm";
                else if (donVi > 0) result += " " + ChuSo[donVi];
            }
            else if (chuc == 0 && donVi > 0)
            {
                result += " " + ChuSo[donVi];
            }

            return result.Trim();
        }
    }

}
