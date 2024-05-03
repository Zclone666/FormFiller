using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppPir.Models;

namespace TestAppPir.Methods
{
    internal static class Binary
    {
        internal static List<Casuelty> Deserialize(byte[] message)
        {
            List<Casuelty> items;
            using (var stream = new MemoryStream(message)) { items = Serializer.Deserialize<List<Casuelty>>(stream); }
            return items;
        }

        internal static byte[] Serialize(List<Casuelty> items)
        {
            byte[] result;
            using (var stream = new MemoryStream()) { Serializer.Serialize(stream, items); result = stream.ToArray(); }
            return result;
        }
    }
}
