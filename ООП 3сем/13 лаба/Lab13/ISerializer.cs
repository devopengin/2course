using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    interface ISerializer<T> {
        public void Serializer(string filename, T obj);
        public T Deserializer(string filename);
    }

}
