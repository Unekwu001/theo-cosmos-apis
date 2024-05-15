using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum MultipleChoiceEnum
    {
        [Description("Creative")]
        Creative = 0,
        [Description("Outgoing")]
        Outgoing = 1,
        [Description("CollegeNeedAtt")]
        CollegeNeedAtt = 2
    }
}
