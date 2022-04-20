// See https://aka.ms/new-console-template for more information
using HuadingTest;

Console.WriteLine("游戏开始!");
var game = new PickUpGame<Toothpick>();
Console.WriteLine("初始化排列为" + game.CurrentItemGroupString());
var players = new string[] { "A", "B" };
int round = 1;

while(!game.CheckEnded())
{
    Console.WriteLine($"****操作回合{round}开始****");
    var player = players[(round - 1) % 2];
    Console.WriteLine($"玩家{player}，请输入需要选取的行序号……");
    var row = Console.ReadLine();
    Console.WriteLine("请输入需要拿走的物品数量……");
    var take = Console.ReadLine();
    if (int.TryParse(row, out int rowInt) && int.TryParse(take, out int takeInt))
    {
        var result = game.Pick(rowInt, takeInt);
        if (result.Success)
        {
            Console.WriteLine($"操作成功，当前剩余: {game.CurrentItemGroupString()}");
            Console.WriteLine($"****操作回合{round}结束****");
            Console.WriteLine("");
            round++;
        }
        else
        { // 有异常
            Console.WriteLine($"!!!!!!!!!!!操作失败: {result.Message}，请玩家{player}重新拿取!!!!!!!!!!!");
        }
    }
    else
    {
        Console.WriteLine($"!!!!!!!!!!!必须输入整数，请玩家{player}重新拿取!!!!!!!!!!!");
    }
}
Console.WriteLine("你输了！！");