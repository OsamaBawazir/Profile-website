using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.ViewModel
{
    public class HomeViewModel
    {
        public Owner owner { get; set; }
        public List<ProfileItem> profileItems  { get; set; }
    }
}
