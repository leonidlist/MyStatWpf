using MyStatAPI.Full;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStatWpf
{
    public class MainViewModel
    {
        public Api Api { get; private set; }
        public MainViewModel(Api api)
        {
            Api = api;
        }
    }
}
