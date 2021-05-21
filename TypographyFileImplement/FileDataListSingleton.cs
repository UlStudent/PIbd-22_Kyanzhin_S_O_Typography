using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TypographyBusinessLogic.Enums;
using TypographyFileImplement.Models;

namespace TypographyFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string PrintedFileName = "Printed.xml";
        private readonly string StoreFileName = "Store.xml";
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Printed> Printeds { get; set; }
        public List<Store> Stores { get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Printeds = LoadPrinteds();
            Stores = LoadStores();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SavePrinteds();
            SaveStores();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("PrintedName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PrintedId = Convert.ToInt32(elem.Element("PrintedId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                                Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Printed> LoadPrinteds()
        {
            var list = new List<Printed>();
            if (File.Exists(PrintedFileName))
            {
                XDocument xDocument = XDocument.Load(PrintedFileName);
                var xElements = xDocument.Root.Elements("Printed").ToList();
                foreach (var elem in xElements)
                {
                    var prodComp = new Dictionary<int, int>();
                    foreach (var component in
                   elem.Element("PrintedComponents").Elements("PrintedComponent").ToList())
                    {
                        prodComp.Add(Convert.ToInt32(component.Element("Key").Value),
                       Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Printed
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PrintedName = elem.Element("PrintedName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        PrintedComponents = prodComp
                    });
                }
            }
            return list;
        }
        private List<Store> LoadStores()
        {
            var list = new List<Store>();
            if (File.Exists(StoreFileName))
            {
                XDocument xDocument = XDocument.Load(StoreFileName);
                var xElements = xDocument.Root.Elements("Store").ToList();
                foreach (var elem in xElements)
                {
                    var storeComponents = new Dictionary<int, (string, int)>();
                    foreach (var component in elem.Element("StoreComponents").Elements("StoreComponent").ToList())
                    {
                        var componentData = (component.Element("Component").Element("Name").Value, Convert.ToInt32(component.Element("Component").Element("Count").Value));
                        storeComponents.Add(Convert.ToInt32(component.Element("Key").Value), componentData);
                    }
                    list.Add(new Store
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        StoreName = elem.Element("StoreName").Value,
                        ResponsibleName = elem.Element("ResponsibleName").Value,
                        DateCreation = Convert.ToDateTime(elem.Element("DateCreation").Value),
                        StoreComponents = storeComponents
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("PrintedName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("PrintedId", order.PrintedId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SavePrinteds()
        {
            if (Printeds != null)
            {
                var xElement = new XElement("Printeds");
                foreach (var Printed in Printeds)
                {
                    var compElement = new XElement("PrintedComponents");
                    foreach (var component in Printed.PrintedComponents)
                    {
                        compElement.Add(new XElement("PrintedComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Printed",
                     new XAttribute("Id", Printed.Id),
                     new XElement("PrintedName", Printed.PrintedName),
                     new XElement("Price", Printed.Price),
                     compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(PrintedFileName);
            }
        }
        private void SaveStores()
        {
            if (Stores != null)
            {
                var xElement = new XElement("Stores");
                foreach (var store in Stores)
                {
                    var compElement = new XElement("StoreComponents");
                    foreach (var component in store.StoreComponents)
                    {
                        var element = new XElement("Component");
                        element.Add(
                            new XElement("Name", component.Value.Item1), new XElement("Count", component.Value.Item2)
                            );
                        compElement.Add(new XElement("StoreComponent",
                        new XElement("Key", component.Key),
                        element));
                    }
                    xElement.Add(new XElement("Store",
                    new XAttribute("Id", store.Id),
                    new XElement("StoreName", store.StoreName),
                    new XElement("ResponsibleName", store.ResponsibleName),
                    new XElement("DateCreation", store.DateCreation),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(StoreFileName);
            }
        }
    }
}
