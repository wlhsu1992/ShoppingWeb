﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWeb.Models.Interface
{
    public interface IProductRepository
    {

        void Update(tProduct instance);

        List<tProduct> GetAll();
    }
}
