using System.Collections.Generic;

using UnityEngine;

namespace Test.Extension
{
    public static class ListExtension
    {
        public static T GetRandom<T>(this List<T> list)
        {
            var temp = new T[list.Count];

            for (var i = 0; i < temp.Length; i++)
            {
                temp[i] = list[i];
            }

            var randomNumber = Random.Range(0, temp.Length);
            return temp[randomNumber];
        }
    }
}