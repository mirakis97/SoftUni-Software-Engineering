using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
   public class ArrayCreator
    {

       public static T[] Create<T>(int lenght, T defaultItem)
        {
            T[] array = new T[lenght];
            for (int i = 0; i < lenght; i++)
            {
                array[i] = defaultItem;
            }
            return array;
        }
    }
}
