using System;
using System.Text;


namespace Base64Encoder
{
    public class Base64
    {
        private string charTable = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        public Base64() { }
        public string Encode(byte[] data)
        {
            string result = "";
            int len = data.Length;


            string tmp2 = "";
            for (int i = 0; i < len; i++)
            {
                //bajty na binarne zapisane jako string
                tmp2 += Convert.ToString(data[i], 2).PadLeft(8, '0');
            }

            //dodanie zer jeśli liczba bajtów nie dzieli się przez 3
            switch (len % 3)
            {
                case 1:
                    tmp2 += "0000";
                    break;
                case 2:
                    tmp2 += "00";
                    break;
            }

            string pom = "";

            for (int a = 0; a < tmp2.Length; a += 6)
            {
                pom = "";
                for (int z = 0; z < 6; z++)
                {

                    pom += tmp2[a + z];

                }
                //odczyt znaku
                result += this.charTable[Convert.ToInt32(pom, 2)];
            }
            if (len % 3 == 1)
            {
                result += "==";
            }
            if (len % 3 == 2)
            {
                result += "=";
            }
            return result;

        }


        public byte[] Decode(string data)
        {


            if (data.EndsWith("="))
            {
                StringBuilder newStr = new StringBuilder(data);
                newStr[data.Length - 1] = 'A';
                data = newStr.ToString();
            }
            string pom = data.Substring(0, data.Length - 1);

            if (pom.EndsWith("="))
            {
                StringBuilder newStr = new StringBuilder(data);
                newStr[data.Length - 2] = 'A';
                data = newStr.ToString();
            }

            string byteString = "";
            for (int a = 0; a < data.Length; a++)
            {
                int xa = this.charTable.IndexOf(data[a]);

                string tmp = Convert.ToString(xa, 2);

                string aux = "";
                for (int x = 0; x < 6 - tmp.Length; x++)
                {
                    aux += "0";
                }
                aux += tmp;
                byteString += aux;
            };

            string tmp2 = "";
            byte[] result = new byte[byteString.Length / 8];
            int flag = 0;
            for (int a = 0; a < byteString.Length; a += 8)
            {
                string pom2 = "";
                for (int x = a; x < a + 8; x++)
                {
                    pom2 += byteString[x];
                }
                tmp2 += pom2 + ".";
                result[flag] = Convert.ToByte(pom2, 2);
                flag++;

            }

            return result;
        }

    }
}
