using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuadingTest
{
    /// <summary>
    /// 游戏类
    /// </summary>
    internal class PickUpGame<T> where T : PugItem, new()
    {
        /// <summary>
        /// 物品信息
        /// </summary>
        public readonly T Item;
        /// <summary>
        /// 物品摆放组
        /// </summary>
        internal int[] ItemGroup { get; private set; }
        /// <summary>
        /// 无参构造
        /// </summary>
        public PickUpGame()
        {
            Item = new T();
            ItemGroup = new int[] {3, 5, 7};
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemGroup"></param>
        public PickUpGame(T item, int[] itemGroup)
        {
            Item = item;
            ItemGroup = itemGroup;
        }

        /// <summary>
        /// 拿走物品
        /// </summary>
        /// <param name="row">拿第几行</param>
        /// <param name="take">拿多少</param>
        /// <returns>操作结果</returns>
        public PickResult Pick(int row, int take)
        {
            try
            {
                if (take <= 0)
                    throw new Exception("至少拿走一" + Item.Unit);
                if (row >= ItemGroup.Length || row < 0) // 选取了不存在的行
                    throw new Exception("不存在的行");
                if (take > ItemGroup[row]) // 数量超出
                    throw new Exception($"这一行已经没有这么多{Item.Name}了");

                // 对应行减掉对应数量
                ItemGroup[row] -= take;
                // 是否结束
                var ended = CheckEnded();
                var message = ended ? "你输了" : "";
                return new PickResult(true, ended, ItemGroup, message);
            }
            catch(Exception ex)
            {
                return new PickResult(false, false, ItemGroup, ex.Message);
            }
        }

        /// <summary>
        /// 检查游戏是否结束
        /// </summary>
        /// <returns></returns>
        public bool CheckEnded()
        {
            // TODO 若是假设游戏双方都不会失误，则是尼姆博弈问题
            return !ItemGroup.Any(x => x > 0);
        }

        /// <summary>
        /// 当前摆放状态的字符串格式
        /// </summary>
        /// <returns></returns>
        public string CurrentItemGroupString()
        {
            return $"[{string.Join(',', ItemGroup)}]";
        }
    }

    /// <summary>
    /// 拿取操作结果
    /// </summary>
    internal class PickResult
    {
        /// <summary>
        /// 成功标志
        /// </summary>
        public bool Success { get; private set; }
        /// <summary>
        /// 是否已结束
        /// </summary>
        public bool Ended { get; private set; }
        /// <summary>
        /// 当前摆放
        /// </summary>
        public int[] ItemGroup { get; private set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; private set; }

        public PickResult(bool success, bool ended, int[] itemGroup, string message)
        {
            Success = success;
            Ended = ended;
            ItemGroup = itemGroup;
            Message = message;
        }
    }
}
