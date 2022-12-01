using Server.Enums;
using System;

namespace Server.HelperClasses
{
    public static class EnumHelper
    {
        public static string ProcessEnumValue(StateEnum state)
        {
            switch (state)
            {
                case StateEnum.Undefined:
                    return "Не определено";
                case StateEnum.OK:
                    return "Замечания отсутствуют";
                case StateEnum.UseViolation:
                    return "Нарушение пользования";
                case StateEnum.Lost:
                    return "Товар утрачен";
                case StateEnum.PutAway:
                    return "Товар временно убран";
                default:
                    return "??";
            }
        }
    }
}

