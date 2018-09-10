﻿using System;

namespace lunes.Domain.Accounts
{
	public class Revenue : IOperation
	{
		public string Name { get; }
		public DateTime Date { get; }
		public double Amount { get; }

		public Revenue(string name, double amount)
		{
			Name = name;
			Date = DateTime.Now;
			Amount = amount;
		}
	}
}
