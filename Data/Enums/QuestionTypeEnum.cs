
using System.ComponentModel;

namespace Data.Enums
{
    public enum QuestionTypeEnum
    {
        [Description("Paragraph")]
        Paragraph = 0,
        [Description("YesNo")]
        YesNo = 1,
        [Description("DropDown")]
        Dropdown = 2,
        [Description("MultipleChoice")]
        MultipleChoice = 3,
        [Description("Date")]
        Date = 4,
        [Description("Number")]
        Number = 5
    }
}
