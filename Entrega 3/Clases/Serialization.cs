using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Entrega_3.Clases
{
    class Serialization
    {
        
            public void Serialize<Object>(Object list, Stream stream)
            {
                try
                {
                    using (stream)
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, list);
                    }
                }
                catch (IOException)
                {

                }
            }
            public Object Deserialize<Object>(Stream stream) where Object : new()
            {
                Object ret = CreateInstance<Object>();
                try
                {
                    using (stream)
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        ret = (Object)bin.Deserialize(stream);
                    }
                }
                catch (IOException)
                {

                }
                return ret;
            }

            private static Object CreateInstance<Object>() where Object : new()
            {
                return (Object)Activator.CreateInstance(typeof(Object));
            }


        
    }
}
