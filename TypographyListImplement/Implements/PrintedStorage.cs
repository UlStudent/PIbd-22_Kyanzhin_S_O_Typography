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
			foreach (var component in source.Products)
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
			foreach (var product in source.Products)
			{
				if (product.ProductName.Contains(model.ProductName))
				{
					result.Add(CreateModel(product));
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
			foreach (var product in source.Products)
			{
				if (product.Id == model.Id || product.ProductName ==
				model.ProductName)
				{
					return CreateModel(product);
				}
			}
			return null;
		}
		public void Insert(PrintedBindingModel model)
		{
			Printed tempProduct = new Printed
			{
				Id = 1,
				ProductComponents = new
			Dictionary<int, int>()
			};
			foreach (var product in source.Products)
			{
				if (product.Id >= tempProduct.Id)
				{
					tempProduct.Id = product.Id + 1;
				}
			}
			source.Products.Add(CreateModel(model, tempProduct));
		}
		public void Update(PrintedBindingModel model)
		{
			Printed tempProduct = null;
			foreach (var product in source.Products)
			{
				if (product.Id == model.Id)
				{
					tempProduct = product;
				}
			}
			if (tempProduct == null)
			{
				throw new Exception("Элемент не найден");
			}
			CreateModel(model, tempProduct);
		}
		public void Delete(PrintedBindingModel model)
		{
			for (int i = 0; i < source.Products.Count; ++i)
			{
				if (source.Products[i].Id == model.Id)
				{
					source.Products.RemoveAt(i);
					return;
				}
			}
			throw new Exception("Элемент не найден");
		}
		private Printed CreateModel(PrintedBindingModel model, Printed product)
		{
			product.ProductName = model.ProductName;
			product.Price = model.Price;
			// удаляем убранные
			foreach (var key in product.ProductComponents.Keys.ToList())
			{
				if (!model.ProductComponents.ContainsKey(key))
				{
					product.ProductComponents.Remove(key);
				}
			}
			// обновляем существуюущие и добавляем новые
			foreach (var component in model.ProductComponents)
			{
				if (product.ProductComponents.ContainsKey(component.Key))
				{
					product.ProductComponents[component.Key] =
					model.ProductComponents[component.Key].Item2;
				}
				else
				{
					product.ProductComponents.Add(component.Key,
					model.ProductComponents[component.Key].Item2);
				}
			}
			return product;
		}
		private PrintedViewModel CreateModel(Printed product)
		{
			// требуется дополнительно получить список компонентов для изделия с названиями и их количество
			Dictionary<int, (string, int)> productComponents = new
			Dictionary<int, (string, int)>();
			foreach (var pc in product.ProductComponents)
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
				productComponents.Add(pc.Key, (componentName, pc.Value));
			}
			return new PrintedViewModel
			{
				Id = product.Id,
				ProductName = product.ProductName,
				Price = product.Price,
				ProductComponents = productComponents
			};
		}

	}
}

