using System;

namespace Projekti_varasto
{
	class Item : IPrintable
	{
		public string Type { get; set; } = "Item";
		public string Model { get; set; }
		public int Amount { get; set; }
		public int ManufactoYear { get; set; }
		public int Price { get; set; }

		public virtual void PrintInfo()
		{
			Console.WriteLine("Model: " + Model);
			Console.WriteLine("Amount: " + Amount);
			Console.WriteLine("MFY: " + ManufactoYear);
			Console.WriteLine("Price: " + Price);
		}
	}
}