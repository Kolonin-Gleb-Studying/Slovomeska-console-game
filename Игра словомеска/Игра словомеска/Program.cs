using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Игра_словомеска
{
	internal class Program
	{
	// Основная программа
	static void Main(string[] args)
        {
			Console.Title = "Игра Словомеска";
			Console.WriteLine("\t\t\t\t\t\t Игра Словомеска");

            int gameAction = int.Parse(Game.enterAction());

            if (gameAction == 1)
            {
				Game.showGameRules();
				Console.WriteLine("Для продолжения нажмите Enter");
				Console.ReadLine();
            }

			// Запуск игры

			Game.startLevel();
			Console.ReadKey();
		}
    }
}
