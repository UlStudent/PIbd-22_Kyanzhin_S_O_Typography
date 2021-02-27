using TypographyBusinessLogic.BindingModels;
using TypographyBusinessLogic.ViewModels;
using TypographyBusinessLogic.Interfaces;
using TypographyListImplement.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace TypographyListImplement.Implements
{
	public class PrintedStorage : IPrintedStorage
	{
		private readonly DataListSingleton source;
		public PrintedStorage()
		{
			source = DataListSingleton.GetInstance();
		}
		public List<PrintedViewModel> GetFullList()
		{
			List<PrintedViewModel> result = new List<PrintedViewModel>();
			foreach (var component in source.Printeds)
			{
				result.Add(CreateModel(component));
			}
			return result;
		}
		public List<PrintedViewModel> GetFilteredList(PrintedBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			List<PrintedViewModel> result = new List<PrintedViewModel>();
			foreach (var Printed in source.Printeds)
			{
				if (Printed.PrintedName.Contains(model.PrintedName))
				{
					result.Add(CreateModel(Printed));
				}
			}
			return result;
		}
		public PrintedViewModel GetElement(PrintedBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			foreach (var Printed in source.Printeds)
			{
				if (Printed.Id == model.Id || Printed.PrintedName ==
				model.PrintedName)
				{
					return CreateModel(Printed);
				}
			}
			return null;
		}
		public void Insert(PrintedBindingModel model)
		{
			Printed tempPrinted = new Printed
			{
				Id = 1,
				PrintedComponents = new
			Dictionary<int, int>()
			};
			foreach (var Printed in source.Printeds)
			{
				if (Printed.Id >= tempPrinted.Id)
				{
					tempPrinted.Id = Printed.Id + 1;
				}
			}
			source.Printeds.Add(CreateModel(model, tempPrinted));
		}
		public void Update(PrintedBindingModel model)
		{
			Printed tempPrinted = null;
			foreach (var Printed in source.Printeds)
			{
				if (Printed.Id == model.Id)
				{
					tempPrinted = Printed;
				}
			}
			if (tempPrinted == null)
			{
				throw new Exception("Элемент не найден");
			}
			CreateModel(model, tempPrinted);
		}
		public void Delete(PrintedBindingModel model)
		{
			for (int i = 0; i < source.Printeds.Count; ++i)
			{
				if (source.Printeds[i].Id == model.Id)
				{
					source.Printeds.RemoveAt(i);
					return;
				}
			}
			throw new Exception("Элемент не найден");
		}
		private Printed CreateModel(PrintedBindingModel model, Printed Printed)
		{
			Printed.PrintedName = model.PrintedName;
			Printed.Price = model.Price;
			// удаляем убранные
			foreach (var key in Printed.PrintedComponents.Keys.ToList())
			{
				if (!model.PrintedComponents.ContainsKey(key))
				{
					Printed.PrintedComponents.Remove(key);
				}
			}
			// обновляем существуюущие и добавляем новые
			foreach (var component in model.PrintedComponents)
			{
				if (Printed.PrintedComponents.ContainsKey(component.Key))
				{
					Printed.PrintedComponents[component.Key] =
					model.PrintedComponents[component.Key].Item2;
				}
				else
				{
					Printed.PrintedComponents.Add(component.Key,
					model.PrintedComponents[component.Key].Item2);
				}
			}
			return Printed;
		}
		private PrintedViewModel CreateModel(Printed Printed)
		{
			// требуется дополнительно получить список компонентов для изделия с названиями и их количество
			Dictionary<int, (string, int)> PrintedComponents = new
			Dictionary<int, (string, int)>();
			foreach (var pc in Printed.PrintedComponents)
			{
				string componentName = string.Empty;
				foreach (var component in source.Components)
				{
					if (pc.Key == component.Id)
					{
						componentName = component.ComponentName;
						break;
					}
				}
				PrintedComponents.Add(pc.Key, (componentName, pc.Value));
			}
			return new PrintedViewModel
			{
				Id = Printed.Id,
				PrintedName = Printed.PrintedName,
				Price = Printed.Price,
				PrintedComponents = PrintedComponents
			};
		}

	}
}

