using System;

namespace Projekti_varasto
{
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

			varasto.AddItem(new Auto
			{
				Model = "Toyota Corolla",
				Amount = 1,
				ManufactoYear = 2005,
				Price = 3500,
				Kilometrit = 220000
			});

			varasto.SaveItems();

			Varasto ladattuVarasto = new Varasto();
			ladattuVarasto.LoadItems();

			Console.WriteLine("Tiedostosta luetut tuotteet: \n");

			foreach (IPrintable item in ladattuVarasto.GetItems())
			{
				item.PrintInfo();
				Console.WriteLine();
			}

			Console.ReadKey();
		}
	}
}
