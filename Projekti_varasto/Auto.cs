using System;

namespace Projekti_varasto
{
	class Auto : Item
	{
		public int Kilometrit { get; set; }

		public Auto()
		{
			Type = "Auto";
		}

		public override void PrintInfo()
		{
			base.PrintInfo();
			Console.WriteLine("Kilometrit: " + Kilometrit);
		}
	}
}