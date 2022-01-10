using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Игра_словомеска
{
    public static class Game
    {
		// Методы
		public static string enterAction()
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
		public static void showGameRules()
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

		public static void startLevel()
		{
			Console.Clear();

			short playerLives = 3;
			short playerHints = 3;
			const short COUNT_OF_WORDS = 10;

			string[] words =
			{
				"акула"  , "белка" , "камень" , "горка"  , "дракон",
				"ежевика", "желудь", "заклад", "крапива", "лимонад"
			};
			// Подача слов в случайном порядке для игры
			var random = new Random(DateTime.Now.Millisecond); // Создание ранодмизатора
			words = words.OrderBy(word => random.Next()).ToArray(); // Перемешивание массива с его помощью

			Console.WriteLine("\t\tИгра началась!");

			for (int i = 0; i < COUNT_OF_WORDS; i++)
			{
				string playerAnswer;
				string playerQuestion = generateQuestion(words[i]);

				Console.WriteLine("\nВы отгадываете " + (i + 1) + " слово из " + COUNT_OF_WORDS);
				Console.WriteLine("Загаданное слово: " + playerQuestion);
				Console.WriteLine("Это слово: ");

				playerAnswer = Console.ReadLine();

				if (playerAnswer == "подсказка")
				{
					if (playerHints != 0)
					{
						string hint = generateHint(words[i]);
						useHint(playerHints, playerQuestion, hint);
						playerAnswer = Console.ReadLine();
					}
					else
					{
						Console.WriteLine("Количество ваших подсказок = 0!");
						Console.WriteLine("Загаданное слово: " + playerQuestion);
						Console.Write("Это слово: ");
						playerAnswer = Console.ReadLine();
					}
				}
				if (playerAnswer == words[i])
				{
					Console.WriteLine("Верно!");
				}
				else
				{
					Console.Write("\n");
					Console.WriteLine("Вы ошиблись!");
					Console.WriteLine("Правильный ответ: " + words[i]);
					Console.WriteLine("Количество ваших жизней = " + --playerLives);

					if (playerLives == 0)
					{
						Console.WriteLine("К сожалению вы проиграли! У вас обязательно получится в следующий раз.");
						break;
					}
				}
			}
			if (playerLives > 0)
			{
				Console.WriteLine("\nВы победили! Поздравляем!");
			}
		}

		public static string generateQuestion(string word) //TODO: как передавать константные параметры в C#?
		{
			string playerQuestion = word;
			while (playerQuestion == word)
			{
				// Перемешивание символов слова
				var rnd = new Random();// Создание ранодмизатора
				playerQuestion = string.Join("", playerQuestion.OrderBy(x => rnd.Next()));
			}
			return playerQuestion;
		}

		public static string generateHint(string word) //TODO: как передавать константные параметры в C#?
		{
			string hint = word;
			// Показать половину слова как подсказку
			int hint_lenght = word.Length / 2; // Половина слова будет подсказкой

			hint = hint.Substring(0, hint_lenght);

			return hint;
		}

		public static void useHint(short playerHints, string playerQuestion, string hint)
		{
			Console.WriteLine("Теперь количество ваших подсказок = " + --playerHints + "\n");
			Console.WriteLine("Загаданное слово: " + playerQuestion);
			Console.WriteLine("Подсказка: " + hint);
			Console.Write("Это слово: ");
		}
	}
}
