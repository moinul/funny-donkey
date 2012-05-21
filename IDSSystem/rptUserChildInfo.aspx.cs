using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.DAL;
using IM.Facade;
using IM.Framework;

public partial class rptUserChildInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session[GeneralConstant.LOGINUSERID] != null)
            {
                string displayId = (Request.QueryString["disId"] != null) ? Request.QueryString["disId"].ToString() : "";
                if (!string.IsNullOrEmpty(displayId))
                {
                    GenerateMLMTree(displayId);
                }
            }

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtUserDispalayID.Text.Trim()))
        {
            GenerateMLMTree(txtUserDispalayID.Text.Trim());
        }
    }

    private void GenerateMLMTree(string displayId)
    {
        SystemUser systemUser = new SystemUser();

        using (TheFacade _facade = new TheFacade())
        {
            #region Parent Node=================================================================================
            systemUser = _facade.TransactionFacade.GetSystemUserByDisplayName(displayId);
            node_parent.Text = systemUser.UserName + "<br/>" + systemUser.UserDesplayID;
            node_parent.NavigateUrl = "#";
            #endregion
            #region Second Level Left Node======================================================================
            SystemUser secondleftChild = systemUser.SystemUser1;
            if (secondleftChild != null)
            {
                node_second_left.Text = secondleftChild.UserName + "<br/>" + secondleftChild.UserDesplayID;
                node_second_left.NavigateUrl = "?disId=" + secondleftChild.UserDesplayID.ToString();

                #region Third Level Left Left===================================================================

                SystemUser su_third_left_left = secondleftChild.SystemUser1;
                if (su_third_left_left != null)
                {
                    node_third_left_left.Text = su_third_left_left.UserName + "<br/>" + su_third_left_left.UserDesplayID;
                    node_third_left_left.NavigateUrl = "?disId=" + su_third_left_left.UserDesplayID.ToString();

                    #region Four Level First Left===============================================================
                    SystemUser su_four_first_left_left = su_third_left_left.SystemUser1;
                    if (su_four_first_left_left != null)
                    {
                        node_four_FirstLeft_left.Text = su_four_first_left_left.UserName + "<br/>" + su_four_first_left_left.UserDesplayID;
                        node_four_FirstLeft_left.NavigateUrl = "?disId=" + su_four_first_left_left.UserDesplayID.ToString();
                    }
                    SystemUser su_four_first_left_right = su_third_left_left.SystemUser2;
                    if (su_four_first_left_right != null)
                    {
                        node_four_FirstLeft_right.Text = su_four_first_left_right.UserName + "<br/>" + su_four_first_left_right.UserDesplayID;
                        node_four_FirstLeft_right.NavigateUrl = "?disId=" + su_four_first_left_right.UserDesplayID.ToString();
                    }
                    #endregion
                }
                #endregion
                #region Third Level Left Right==================================================================
                SystemUser su_third_left_right = secondleftChild.SystemUser2;
                if (su_third_left_right != null)
                {
                    node_third_left_right.Text = su_third_left_right.UserName + "<br/>" + su_third_left_right.UserDesplayID;
                    node_third_left_right.NavigateUrl = "?disId=" + su_third_left_right.UserDesplayID.ToString();

                    #region Four Level First Right===============================================================
                    SystemUser su_four_first_right_left = su_third_left_right.SystemUser1;
                    if (su_four_first_right_left != null)
                    {
                        node_four_FirstRight_left.Text = su_four_first_right_left.UserName + "<br/>" + su_four_first_right_left.UserDesplayID;
                        node_four_FirstRight_left.NavigateUrl = "?disId=" + su_four_first_right_left.UserDesplayID.ToString();
                    }
                    SystemUser su_four_first_right_right = su_third_left_right.SystemUser2;
                    if (su_four_first_right_right != null)
                    {
                        node_four_FirstRight_right.Text = su_four_first_right_right.UserName + "<br/>" + su_four_first_right_right.UserDesplayID;
                        node_four_FirstRight_right.NavigateUrl = "?disId=" + su_four_first_right_right.UserDesplayID.ToString();
                    }
                    #endregion
                }
                #endregion
            }
            #endregion
            #region Second Level Right Node=====================================================================
            SystemUser secondrightChild = systemUser.SystemUser2;
            if (secondrightChild != null)
            {
                node_second_right.Text = secondrightChild.UserName + "<br/>" + secondrightChild.UserDesplayID;
                node_second_right.NavigateUrl = "?disId=" + secondrightChild.UserDesplayID.ToString();

                #region Third Level Right Left==================================================================
                SystemUser su_third_right_left = secondrightChild.SystemUser1;
                if (su_third_right_left != null)
                {
                    node_third_right_left.Text = su_third_right_left.UserName + "<br/>" + su_third_right_left.UserDesplayID;
                    node_third_right_left.NavigateUrl = "?disId=" + su_third_right_left.UserDesplayID.ToString();
                    #region Four Level Second Left==================================================================
                    SystemUser su_four_second_left_left = su_third_right_left.SystemUser1;
                    if (su_four_second_left_left != null)
                    {
                        node_four_SecondLeft_left.Text = su_four_second_left_left.UserName + "<br/>" + su_four_second_left_left.UserDesplayID;
                        node_four_SecondLeft_left.NavigateUrl = "?disId=" + su_four_second_left_left.UserDesplayID.ToString();
                    }
                    SystemUser su_four_second_left_right = su_third_right_left.SystemUser2;
                    if (su_four_second_left_right != null)
                    {
                        node_four_SecondLeft_right.Text = su_four_second_left_right.UserName + "<br/>" + su_four_second_left_right.UserDesplayID;
                        node_four_SecondLeft_right.NavigateUrl = "?disId=" + su_four_second_left_right.UserDesplayID.ToString();
                    }
                    #endregion
                }
                #endregion
                #region Third Level Right Right=================================================================
                SystemUser su_third_right_right = secondrightChild.SystemUser2;

                if (su_third_right_right != null)
                {
                    node_third_right_right.Text = su_third_right_right.UserName + "<br/>" + su_third_right_right.UserDesplayID;
                    node_third_right_right.NavigateUrl = "?disId=" + su_third_right_right.UserDesplayID.ToString();
                    #region Four Level Second Right=================================================================
                    SystemUser su_four_second_right_left = su_third_right_right.SystemUser1;
                    if (su_four_second_right_left != null)
                    {
                        node_four_SecondRight_left.Text = su_four_second_right_left.UserName + "<br/>" + su_four_second_right_left.UserDesplayID;
                        node_four_SecondRight_left.NavigateUrl = "?disId=" + su_four_second_right_left.UserDesplayID.ToString();
                    }
                    SystemUser su_four_second_right_right = su_third_right_right.SystemUser2;
                    if (su_four_second_right_right != null)
                    {
                        node_four_SecondRight_right.Text = su_four_second_right_right.UserName + "<br/>" + su_four_second_right_right.UserDesplayID;
                        node_four_SecondRight_right.NavigateUrl = "?disId=" + su_four_second_right_right.UserDesplayID.ToString();
                    }
                    #endregion
                }
                #endregion
            }

            #endregion
        }
    }

}
