using ShoppingWeb.DAL;
using ShoppingWeb.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingWeb.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void Create(tProduct instance)
        {
            throw new NotImplementedException();
        }

        public void Delete(tProduct instance)
        {
            throw new NotImplementedException();
        }

        public tProduct Get(int productID)
        {
            throw new NotImplementedException();
        }

        public List<tProduct> GetAll()
        {
            MSSQLProvider mp = new MSSQLProvider();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_get_products";
            return mp.ToList<tProduct>(mp.SQLQuery(cmd));
        }

        public void Update(tProduct instance)
        {
            throw new NotImplementedException();
        }
    }
}