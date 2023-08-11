using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Demo_App.Interface
{
    interface IPersonData
    {
        string Name { get; set; }

        string Country { get; set; }

        string Address { get; set; }

        string PostalZip { get; set; }

        string Email { get; set; }

        string Phone { get; set; }
    }
}
