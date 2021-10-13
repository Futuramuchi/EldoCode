using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class CategoryModel
    {
        public CategoryModel(Category category = null)
        {
            if (category != null)
            {
                Id = category.Id;
                Name = category.Name;

            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}