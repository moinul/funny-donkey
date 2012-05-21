using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using IM.Framework;

/// <summary>
/// Summary description for RdoListBoxHelper
/// </summary>
public class RdoListBoxHelper
{
    public static void Bind(RadioButtonList rdolst, ListItemCollection list)
    {
        foreach (ListItem item in list)
        {
            rdolst.Items.Add(item);
        }
    }

    public static void Bind(RadioButtonList rdolst, ListItemCollection list, EnumHelper.ListItemType listType)
    {
        foreach (ListItem item in list)
        {
            //if (listType == EnumHelper.ListItemType.CommissionType)
            //{
            //    if (Convert.ToInt32(item.Value) == Convert.ToInt32(EnumHelper.CommissionType.Dollar))
            //    {
            //        item.Text = "$";
            //    }
            //    if (Convert.ToInt32(item.Value) == Convert.ToInt32(EnumHelper.CommissionType.Percentage))
            //    {
            //        item.Text = "%";
            //    }
            //}
            rdolst.Items.Add(item);
        }
    }
}
