using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWeb.Models.Interface
{
    public interface IMemberRepository
    {
        void Create(tMember instance);

        tMember Get(string userId);

        tMember Get(string userId, string pwd);

    }
}
