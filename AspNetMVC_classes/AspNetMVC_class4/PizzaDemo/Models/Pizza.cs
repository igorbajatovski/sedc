using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDemo.ViewModels;

namespace PizzaDemo.Models
{
    public class Pizza : IEntity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Prize { get; set; }

        public List<Ingridient> Ingridients { get; set; }

        public Pizza(int ID, string name, string description, List<Ingridient> ingrediants, int prize)
        {
            this.ID = ID;
            this.Name = name;
            this.Description = description;
            this.Ingridients = ingrediants;
            this.Prize = prize;
        }

        public int getPrize(SizeEnum size)
        {
            if (size == SizeEnum.Small)
                return Prize;
            else if (size == SizeEnum.Medium)
                return (int) Math.Ceiling(Prize * 1.2);
            else
                return (int) Math.Ceiling(Prize * 1.4);
        }

        //public PizzaViewModel ToViewModel()
        //{
        //    List<int> selectedIngredients = new List<int>();
        //    foreach (var ingre in this.Ingridients)
        //    {
        //        selectedIngredients.Add(ingre.ID);
        //    }

        //    PizzaViewModel pizzaViewModel = new PizzaViewModel(this.Name, this.Description, this.Prize, selectedIngredients);

        //    return pizzaViewModel;
        //}
    }
}
