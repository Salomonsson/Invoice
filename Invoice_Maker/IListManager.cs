using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Maker
{
    interface IListManager<T>
    {

        int Count { get; }

        bool Add(T aType);

        bool DeleteAt(int Index);

        string[] ToStringArray();

        bool BinarySerialize(string fileName);
        bool BinaryDeSerialize(string fileName);


        //bool XMLSerialize(string fileName);
    }



}
