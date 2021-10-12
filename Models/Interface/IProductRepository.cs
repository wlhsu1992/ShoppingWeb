using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWeb.Models.Interface
{
    public interface IProductRepository
    {
        void Create(tProduct instance);

        void Update(tProduct instance);

        void Delete(tProduct instance);

        tProduct Get(int categoryID);

        List<tProduct> GetAll();
    }
}
