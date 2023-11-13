using EasyAutomationFramework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraping.Model;

namespace WebScraping.Driver
{
    public class WebScraper : Web
    {
        public DataTable GetData(string url)
        {
            if (driver == null) StartBrowser();

            var items = new List<Item>();

            Navigate(url);

            var elements = GetValue(TypeElement.Xpath, "/html/body/div[1]/div[3]/div/div[2]/div")
                            .element.FindElements(By.ClassName("thumbnail"));

            foreach (var element in elements)
            {
                var item = new Item();
                item.Title = element.FindElement(By.ClassName("title")).GetAttribute("title");
                item.Description = element.FindElement(By.ClassName("description")).Text;
                item.Price = element.FindElement(By.ClassName("price")).Text;

                items.Add(item);
            }

            return Base.ConvertTo(items);
        }
    }
}
