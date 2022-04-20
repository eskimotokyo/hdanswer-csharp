using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuadingTest
{
    internal class PugItem : IPugItem
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = "物品";
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; } = "个";
    }

    internal sealed class Toothpick : PugItem
    {
        public Toothpick()
        {
            Name = "牙签";
            Unit = "根";
        }
    }
}
