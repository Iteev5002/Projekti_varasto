using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Projekti_varasto
{


	class Item
	{
		public string Model { get; set; }


		public int Amount { get; set; }


		public int ManufactoYear { get; set; }


		public int Price { get; set; }


		public void PrintInfo()
		{
			Console.WriteLine("Model: " + Model);
			Console.WriteLine("Amount: " + Amount);
			Console.WriteLine("MFY: " + ManufactoYear);
			Console.WriteLine("Price: " + Price);
		}
	}

	class Varasto
	{
		private List<Item> _items = new List<Item>();
		private string _filePath = "Tuotteet.json";

		public void AddItem(Item item)
		{
			_items.Add(item);
		}

		public List<Item> GetItems()
		{
			return _items;
		}

		public void SaveItems()
		{
			string json = JsonSerializer.Serialize(_items, new JsonSerializerOptions
			{
				WriteIndented = true
			});
			File.WriteAllText(_filePath, json);
		}

		public void LoadItems()
		{
			if (!File.Exists(_filePath))
			{
				_items = new List<Item>();
				return;
			}

			string json = File.ReadAllText(_filePath);
			_items = JsonSerializer.Deserialize<List<Item>>(json);
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			Varasto varasto = new Varasto();

			varasto.AddItem(new Item
			{
				Model = "Lumilinko",
				Amount = 1,
				ManufactoYear = 1980,
				Price = 800,
			});

			varasto.AddItem(new Item
			{
				Model = "Perälevy",
				Amount = 2,
				ManufactoYear = 1980,
				Price = 460,
			});

			varasto.SaveItems();

			Varasto ladattuVarasto = new Varasto();
			ladattuVarasto.LoadItems();

			Console.WriteLine("Tiedostosta luetut tuotteet: \n");

			foreach (var item in ladattuVarasto.GetItems())
			{
				item.PrintInfo();
				Console.WriteLine();
			}

			Console.ReadKey();
		}
	}
}
