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
using System.Collections.Generic;
using IM.Framework;
using System.Linq.Dynamic;

/// <summary>
/// Summary description for DDLHelper
/// </summary>
public static class DDLHelper
{
    public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty)
    {
        //DropDownList ddl = new DropDownList();
        //Edited by Imtiaz
        //items = items.AsQueryable().OrderBy(nameProperty + " " + "asc").ToList<T>();
        //end
        ddl.DataSource = items;
        ddl.DataTextField = nameProperty;
        ddl.DataValueField = valueProperty;
        ddl.DataBind();
        //return ddl;
    }

    public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, bool sorted)
    {
        //DropDownList ddl = new DropDownList();
        //Edited by Imtiaz
        if (sorted)
            items = items.AsQueryable().OrderBy(nameProperty + " " + "asc").ToList<T>();
        //end
        ddl.DataSource = items;
        ddl.DataTextField = nameProperty;
        ddl.DataValueField = valueProperty;
        ddl.DataBind();
        //return ddl;
    }
    public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, ListItemCollection extraItems, int hasSelectedValue)
    {
        if (hasSelectedValue == 1)
        {
            foreach (ListItem item in extraItems)
            {
                ddl.Items.Insert(0, item);
            }
            Bind<T>(ddl, items, nameProperty, valueProperty);
        }
        else
        {
            Bind<T>(ddl, items, nameProperty, valueProperty);
            foreach (ListItem item in extraItems)
            {
                ddl.Items.Insert(0, item);
            }
        }
    }
    public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, ListItemCollection extraItems)
    {

        Bind<T>(ddl, items, nameProperty, valueProperty);
        foreach (ListItem item in extraItems)
        {
            ddl.Items.Insert(0, item);
        }
    }
    public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, ListItemCollection extraItems, bool sorted)
    {
        Bind<T>(ddl, items, nameProperty, valueProperty, sorted);
        foreach (ListItem item in extraItems)
        {
            ddl.Items.Insert(0, item);
        }
    }
    public static void Bind(DropDownList ddl, ListItemCollection list)
    {
        foreach (ListItem item in list)
        {
            ddl.Items.Add(item);
        }
    }
    public static void Bind(DropDownList ddl, ListItemCollection list, EnumHelper.ListItemType ddlType)
    {
        Bind(ddl, list);
        foreach (ListItem item in GetExtraItems(ddlType))
        {
            ddl.Items.Insert(0, item);
        }
    }

    private static ListItemCollection GetExtraItems(EnumHelper.ListItemType ddltype)
    {
        ListItemCollection extraItems = new ListItemCollection();
        switch (ddltype)
        {
            case EnumHelper.ListItemType.Select:
                extraItems.Add(new ListItem("Select Type", "-1"));
                break;
            //case EnumHelper.ListItemType.State: //for State
            //    extraItems.Add(new ListItem("N/A", "-2"));
            //    extraItems.Add(new ListItem("Select State", "-1"));
            //    //Bind<T>(ddl, items, nameProperty, valueProperty, extraItems);
            //    break;
            //case EnumHelper.ListItemType.Country: //for Country                    
            //    extraItems.Add(new ListItem("Select Country", "-1"));
            //    break;
            //case EnumHelper.ListItemType.ProductType: //for ProductType
            //    extraItems.Add(new ListItem("Select Type", "-1"));
            //    break;
            //case EnumHelper.ListItemType.ProductName: //for ProductType
            //    extraItems.Add(new ListItem("Select Product", "-1"));
            //    break;
            //case EnumHelper.ListItemType.Tax: //for Tax
            //    extraItems.Add(new ListItem("Select Tax", "-1"));
            //    break;
            //case EnumHelper.ListItemType.CurrencyName: //for Tax
            //    extraItems.Add(new ListItem("Select Currency", "-1"));
            //    break;
            //case EnumHelper.ListItemType.PriceType: //for ProductType
            //    extraItems.Add(new ListItem("Select Type", "-1"));
            //    break;
            //case EnumHelper.ListItemType.Vendor: //for ProductType
            //    //extraItems.Add(new ListItem("Select Vendor", "-1"));
            //    extraItems.Add(new ListItem("Select Supplier", "-1"));
            //    break;
            //case EnumHelper.ListItemType.PriceDetailTypeRow: //for ProductType
            //    extraItems.Add(new ListItem("Select Type", "-1"));
            //    break;
            //case EnumHelper.ListItemType.PriceDetailTypeCol: //for ProductType
            //    extraItems.Add(new ListItem("Select Room Type", "-1"));
            //    extraItems.Add(new ListItem("No Type", "12"));
            //    break;
            //case EnumHelper.ListItemType.PackageStatus: //for PackageStatus
            //    extraItems.Add(new ListItem("Select Package Status", "-1"));
            //    break;
            ////case EnumHelper.ListItemType.Insurance: //for Insurance
            ////    extraItems.Add(new ListItem("Select Insurance", "-1"));
            ////    break;
            //case EnumHelper.ListItemType.CompsType: //for Insurance
            //    extraItems.Add(new ListItem("Select CompsType", "-1"));
            //    break;
            //case EnumHelper.ListItemType.ApplyCostAndPrice: //for Insurance
            //    extraItems.Add(new ListItem("Don't Apply", "-1"));
            //    break;
            //case EnumHelper.ListItemType.ExtraField: //for Insurance
            //    extraItems.Add(new ListItem("Select Item", "-1"));
            //    break;
            //case EnumHelper.ListItemType.ExtraFees: //for Insurance
            //    extraItems.Add(new ListItem("Select Feed", "-1"));
            //    break;
            //case EnumHelper.ListItemType.Agent: //for Insurance
            //    extraItems.Add(new ListItem("Select Agent", "-1"));
            //    break;
            //case EnumHelper.ListItemType.PackagePriceApprovalStatus: //for Insurance
            //    extraItems.Add(new ListItem("Select Approval Status", "-1"));
            //    break;
            //case EnumHelper.ListItemType.DocumentType: //for Insurance
            //    extraItems.Add(new ListItem("Select Type", "-1"));
            //    break;
            //case EnumHelper.ListItemType.PaymentStatusType:
            //    extraItems.Add(new ListItem("Select Payment Type", "-1"));
            //    break;
            //case EnumHelper.ListItemType.TourType:
            //    extraItems.Add(new ListItem("Select Tour Type", "-1"));
            //    break;
            //case EnumHelper.ListItemType.Client: //for Cleint
            //    extraItems.Add(new ListItem("Select Client", "-1"));
            //    break;
            //case EnumHelper.ListItemType.ClientType: //for ClientType
            //    extraItems.Add(new ListItem("Select ClientType", "-1"));
            //    break;
            //case EnumHelper.ListItemType.Category: //for ClientType
            //    extraItems.Add(new ListItem("N/A", "-1"));
            //    break;
            //case EnumHelper.ListItemType.Location: //for ClientType
            //    extraItems.Add(new ListItem("Select Location", "-1"));
            //    break;
            //case EnumHelper.ListItemType.Group: //for Group
            //    extraItems.Add(new ListItem("Select Group", "-1"));
            //    break;
            //case EnumHelper.ListItemType.User: //for Group
            //    extraItems.Add(new ListItem("Select User", "-1"));
            //    break;
            //case EnumHelper.ListItemType.ShortName: //for Group
            //    extraItems.Add(new ListItem("Select Short Name", "-1"));
            //    break;
            //case EnumHelper.ListItemType.VendorRating: //for Group
            //    extraItems.Add(new ListItem("N/A", "-1"));
            //    break;
            //case EnumHelper.ListItemType.Hour: //for Group
            //    extraItems.Add(new ListItem("Hour", "-1"));
            //    break;
            //case EnumHelper.ListItemType.Munite: //for Group
            //    extraItems.Add(new ListItem("Min", "-1"));
            //    break;
        }
        return extraItems;
    }
    public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, EnumHelper.ListItemType ddltype)
    {


        Bind<T>(ddl, items, nameProperty, valueProperty, GetExtraItems(ddltype));

    }

    public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, EnumHelper.ListItemType ddltype, bool sorted)
    {


        Bind<T>(ddl, items, nameProperty, valueProperty, GetExtraItems(ddltype), sorted);

    }


}