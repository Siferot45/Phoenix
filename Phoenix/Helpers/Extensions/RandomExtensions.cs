using System;

namespace Phoenix.Helpers.Extensions
{
    static class RandomExtensions
    {
        /// <summary>
        /// Передает ссылку следующего елемента одномерного массива
        /// </summary>
        public static ref T NextItem<T>(this Random rnd, params T[] items)
        {
            return ref items[rnd.Next(items.Length)];
        }
    }
}
