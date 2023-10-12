using Pharmaceuticals_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Pharmaceuticals_Client.Areas.Admin.Models
{
    public class AdminViewModel
    {
        public Category category { get; set; }

        public IPagedList<Category> catList { get; set; }

        public Product product { get; set; }

        public IPagedList<Product> proList { get; set; }

        public Pharmaceuticals_Client.Models.Attribute attribute { get; set; }

        public IPagedList<Pharmaceuticals_Client.Models.Attribute> attList { get; set; }

        public Manufacturer manufacturer { get; set; }

        public IPagedList<Manufacturer> manuList { get; set; }

        public Manager manager { get; set; }

        public IPagedList<Manager> manaList { get; set; }

        public Manager managerInfo { get; set; }

        public Feedback feedback { get; set; }
        public IPagedList<Feedback> feedbackList { get; set; }

        public Candidate candidate { get; set; }

        public IPagedList<Candidate> canList { get; set; }
    }
}
