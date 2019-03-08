using Neo;
using Neo.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class Program
    {
        static void Main(string[] args)
        {
            //address 2 script hash
            Console.WriteLine("Ae8AD6Rc3cvQapqttJcUTj9ULfLi2tLHmc".ToScriptHash());
            //script hash 2 address
            Console.WriteLine(new UInt160("0x505663a29d83663a838eee091249abd167e928f5".Remove(0, 2).HexToBytes().Reverse().ToArray()).ToAddress());            

            //hex string 2 string
            Console.WriteLine("7472616e73666572".HexToString());
            //string 2 hex string
            Console.WriteLine("transfer".ToHexString());

            //big-endian 2 little-endian
            Console.WriteLine("0x4701ee0b674ff2d8893effc2607be85327733c1f".Remove(0, 2).HexToBytes().Reverse().ToHexString());
            //little-endian 2 big-endian
            Console.WriteLine("0x" + "b1ad4a4093e7b918d19b013b7347cf0a67bed8ac6ca393ea9a473841b6ef3523".HexToBytes().Reverse().ToHexString());

            //hex string 2 biginteger
            Console.WriteLine(new BigInteger("00e1f505".HexToBytes()));
            //biginteger 2 hex string
            Console.WriteLine(new BigInteger(100000000).ToByteArray().ToHexString());

            Console.ReadLine();
        }

        static string HexToString(this string hex)
        {
            if (hex.Length % 2 != 0)
            {
                throw new ArgumentException();
            }
            var output = "";
            for (int i = 0; i <= hex.Length - 2; i+=2)
            {
                try
                {
                    var result = Convert.ToByte(new string(hex.Skip(i).Take(2).ToArray()), 16);
                    output += (Convert.ToChar(result));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return output;
        }
        static string ToHexString(this string str)
        {
            byte[] byteArray = Encoding.Default.GetBytes(str.ToCharArray());
            return byteArray.ToHexString();
        }
    }
}
