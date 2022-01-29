using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using TaskNote.Entity;

namespace TaskNote.JQruery.EnumSelectedList
{
    public class SexSelectedList
    {
        public IEnumerable<SelectListItem> Values { get; } = EnumExtentions.ToSelectListItem<Sex>();
    }

    public static class EnumExtentions
    {
        public static IList<SelectListItem> ToSelectListItem<TEnum>() where TEnum : struct
        {
            var rets = new List<SelectListItem>();
            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {
                rets.Add(new SelectListItem(value.ToString(), Convert.ToInt32(value).ToString()));
            }
            return rets;
        }
    }
}
