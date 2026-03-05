using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Projekti_varasto
{
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
			List<object> exportList = new List<object>(_items);

			string json = JsonSerializer.Serialize(exportList, new JsonSerializerOptions
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
			using JsonDocument doc = JsonDocument.Parse(json);

			_items = new List<Item>();

			foreach (var element in doc.RootElement.EnumerateArray())
			{
				string type = element.GetProperty("Type").GetString();

				Item item;

				if (type == "Auto")
				{
					var auto = new Auto();
					auto.Kilometrit = element.GetProperty("Kilometrit").GetInt32();
					item = auto;
				}
				else
				{
					item = new Item();
				}

				item.Model = element.GetProperty("Model").GetString();
				item.Amount = element.GetProperty("Amount").GetInt32();
				item.ManufactoYear = element.GetProperty("ManufactoYear").GetInt32();
				item.Price = element.GetProperty("Price").GetInt32();

				_items.Add(item);
			}
		}
	}
}