using AlcoolGasolina.Models.Entities;
using AlcoolGasolina.Views;
using System.Collections.Generic;

namespace AlcoolGasolina.Helpers
{
    public class RootMenu
    {
        public static List<ItemMenu> Itens()
        {
            List<ItemMenu> list = new List<ItemMenu>();
            list = new List<ItemMenu>
            {
                new ItemMenu
                {
                    Image = "icon.png",
                    Nome = "Calcular",
                    PageUrl = "MainPage"
                },
                new ItemMenu
                {
                    Image = "icon.png",
                    Nome = "Postos de combustíveis",
                    PageUrl = "Postos"
                }

            };
            return list;
        }
    }
}
