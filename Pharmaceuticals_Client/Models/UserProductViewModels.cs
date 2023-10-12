using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Pharmaceuticals_Client.Models
{
    public class UserProductViewModels
    {
        public Product product { get; set; }

        public IPagedList<Product> productList { get; set; }

        public Category category { get; set; }

        public IPagedList<Category> categoryList { get; set; }

        public Feedback feedback { get; set; }

        public IPagedList<Feedback> feedbackList { get; set; }

        public Manager manager { get; set; }

        public IPagedList<Manager> manaList { get; set; }

        // dùng cho detail, edit, create, delete các thứ
        public Manager managerInfo { get; set; }

        public Attribute attribute { get; set; }

        public IPagedList<Attribute> attributeList { get; set; }
    }
}
