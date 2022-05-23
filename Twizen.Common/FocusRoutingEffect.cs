using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Twizen.Common
{
    internal class FocusRoutingEffect : RoutingEffect
    {
        public FocusRoutingEffect() : base($"MyCompany.{nameof(FocusEffect)}")
        {
        }
    }
}
