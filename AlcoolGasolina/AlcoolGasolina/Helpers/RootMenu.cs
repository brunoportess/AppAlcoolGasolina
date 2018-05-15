using AlcoolGasolina.Models.Entities;
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
                    PageUrl = "CalcularPage"
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
