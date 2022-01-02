using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Игра_словомеска
{
	internal class Game
    {
		// Методы
		static string enterAction()
		{
			string action = "";

			while (true)
			{
				Console.WriteLine("Введите 1, чтобы ознакомится с правилами.");
				Console.WriteLine("Введите 2, чтобы начать играть!");
				action = Console.ReadLine();
				if (action == "1" || action == "2")
				{
					return action;
				}
				else
				{
					Console.WriteLine("Выбранное действие отсутствует!");
				}
			}
		}
		static void showGameRules()
		{
			Console.WriteLine("\t\t Правила игры:");
			Console.WriteLine("Компьютер говорит вам слово, буквы которого перемешались.");
			Console.WriteLine("Ваша задача угадать, что это за слово и ввести его.");
			Console.WriteLine("У вас есть 3 жизни.");
			Console.WriteLine("Одна жизнь отнимается, если вы неправильно вводите загаданное слово.");
			Console.WriteLine("Если жизни закончатся, то вы проиграли.");
			Console.WriteLine("Если вы отгадали все слова, то вы победили.");
			Console.WriteLine("У вас также есть 3 подсказки.");
			Console.WriteLine("Для каждого слова можно использовать только 1 подсказку.");
			Console.WriteLine("Подсказкой является первая половина загаданного слова.");
			Console.WriteLine("Чтобы использовать подсказку введите \"подсказка\" в поле вашего ответа");
			Console.WriteLine("Удачи и приятной игры!");
			Console.Write("\n\n");
		}

		// Основная программа
		static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\t\t Игра Словомеска");

			showGameRules();

            //int gameAction = int.Parse(Game_functions.enterAction());

            //if (gameAction == 1)
            //{
            //    Console.ReadLine(); // Для продолжения нажмите любую клавишу
            //}

            // Запуск игры
        }
    }
}
