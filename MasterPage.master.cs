using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading;


public partial class Shop_MasterPage : System.Web.UI.MasterPage
{
    public string UserID = "";
    public string SalesAgentID = "";
    public string userName = "";
    public string flag = "";
    public string terminalID = "";
    public string activeid = "0";
    public string pagename = "";
    public string doprice = "";
    public string dopricestyle = "";
    public string isAccept = "";
    public string pageUrl = "";
    public string keyword = "";
    public string companyname = "";
    public string uLevel = "";
    public string language = "";
    public string reviewdailyorder = "";
    public string reviewweeklyorder = "";
    public string myaccount = "";
    public string logout = "";

    String ConnectionString = ConfigurationManager.ConnectionStrings["CON"].ToString();
    SqlConnection Conn;
    SqlCommand dCmd;
    public string st120report = "";

    protected void Page_Load(object sender, EventArgs e)
     {
        form1.Action = Request.RawUrl;
        st120report = Resources.Resources.ResourceManager.GetString("st120report");
        StringBuilder html = new StringBuilder();
        pagename = Path.GetFileName(Request.Url.AbsolutePath);

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        HttpResponse.RemoveOutputCacheItem("/"+pagename);


        reviewdailyorder = Resources.Resources.ResourceManager.GetString("ReviewDailyOrder");
        reviewweeklyorder = Resources.Resources.ResourceManager.GetString("ReviewWeeklyOrder");
        myaccount = Resources.Resources.ResourceManager.GetString("MyAccount");
        logout = Resources.Resources.ResourceManager.GetString("LogOut");

        if (pagename.Contains("Home"))
        {
            lihome.Attributes.Add("class", "active");
            librand.Attributes.Remove("class");
            lihelp.Attributes.Remove("class");
            liaccount.Attributes.Remove("class");
            lisearch.Attributes.Remove("class");
        }
        if (pagename.Contains("brandlisting") || pagename.Contains("newstock") || pagename.Contains("clearance"))
        {
            librand.Attributes.Add("class", "active");
            lihome.Attributes.Remove("class");
            lihelp.Attributes.Remove("class");
            liaccount.Attributes.Remove("class");
            lisearch.Attributes.Remove("class");
        }
        if (pagename.Contains("Search"))
        {
            lisearch.Attributes.Add("class", "active");
            librand.Attributes.Remove("class");
            lihome.Attributes.Remove("class");
            lihelp.Attributes.Remove("class");
            liaccount.Attributes.Remove("class");
        }
        if (pagename.Contains("faqs") || pagename.Contains("return"))
        {
            lihelp.Attributes.Add("class", "active");
            lihome.Attributes.Remove("class");
            librand.Attributes.Remove("class");
            liaccount.Attributes.Remove("class");
            lisearch.Attributes.Remove("class");
        }
       // librand.Attributes.Add("class","active");
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        HttpResponse.RemoveOutputCacheItem("/" + pagename);

        UserID = Cookies_Read("UserID");
        SalesAgentID = Cookies_Read("SalesAgentID");
        userName = Cookies_Read("Username");
        flag = Cookies_Read("flag");
        terminalID = Cookies_Read("terminalid");
        activeid = Cookies_Read("activeid");
        doprice = Cookies_Read("ops");
        isAccept = Cookies_Read("Accept");
        companyname = Cookies_Read("Company");
        uLevel = Cookies_Read("level");

        //UserID = "56";
        //userName = "Biren";
        //flag = "1";
        //SalesAgentID = "48";
        //terminalID = "csm55jrogubqfk1c0b1spzcs";
        //activeid = "161958";
        //doprice = "";
        //isAccept = "1";

        if (isAccept == "1")
        {
            divweb.Visible = false;
        }

        

        if (UserID == "0")
        {
            Response.Redirect("index");
        }
        else
        {
            // Response.Write(Path.GetFileName(Request.Url.AbsolutePath));
            Conn = new SqlConnection(ConnectionString);
            if (Request.QueryString["k"] != null)
            {
                keyword = Request.QueryString["k"].ToString().Replace("$", "&").Replace("!", "/");

                ScriptManager.RegisterStartupScript(this, typeof(Page), "loadm", "<script type=\"text/javascript\">pageload('"+keyword+"')</" + "script>", false);
            }
            

            bindcartheader();
            string dt = "";

            if (doprice == "1")
            {
                dopricestyle = "display:none !important;";
            }

            if (!IsPostBack)
            {
                //language = Cookies_Read("CultureInfo");

                if (language != null && language != "" && language != "0")
                {
                    ddlanguage.SelectedValue = language;
                    //ddlanguage.SelectedIndex = Convert.ToInt32(Session["ddindex"].ToString());
                }
                else
                {
                    ddlanguage.SelectedValue = Thread.CurrentThread.CurrentUICulture.Name;
                }

                if (hasDailyOrder(UserID))
                {
                    reviewaccount.Style.Add("display", "block");
                }
                if (hasWeeklyOrder(UserID))
                {
                    reviewweeklyaccount.Style.Add("display", "block");
                }
                if (pagename.Contains("Cart") || pagename.Contains("thanks-page"))
                {
                    cntShop.Style.Add("display", "block");
                    divAccount.Visible = false;
                    divCart.Visible = false;
                    divSearch.Style.Add("display", "none");
                }

                html.Append(ltluser.Text.Replace("[cname]", companyname));
                ltluser.Text = html.ToString();
                bindProductGrid(false);
                //  bindcartheader();
                if (flag == "1")
                {
                    pageUrl = "myaccount";
                    st120.Visible = false;
                    //dt = loaddata();
                }
                else if (flag == "2")
                {
                    pageUrl = "manage-account";
                    bindsalesagent();
                }
            }
          
        }
    }

    protected void Write_Cookie(string CookieName, string CookieValue)
    {
        HttpCookie MyCookie = new HttpCookie(CookieName);
        MyCookie.Value = CookieValue;
        DateTime dt = DateTime.Now;
        TimeSpan ts = new TimeSpan(1, 0, 0, 0, 0);
        MyCookie.Expires = dt + ts;
        Response.Cookies.Add(MyCookie);
    }

    protected void ddlanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
      

        Write_Cookie("CultureInfo", ddlanguage.SelectedValue);
        language = ddlanguage.SelectedValue;
        CultureInfo ci = new CultureInfo(ddlanguage.SelectedValue);
        //Thread.CurrentThread.CurrentCulture = ci;
        Thread.CurrentThread.CurrentUICulture = ci;

       
        Server.Transfer(Request.Path);
    }

    public bool hasWeeklyOrder(string userid)
    {
        bool hasorder = false;
        try
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Open();
            DataTable dt = InlineDataTable("SELECT oservicecharge as servicecharge, ot.orderdetailsid as cartid, left(p.ProductName,15) + '..' as productname, p.brandname ,left(p.categoryname,15) + '..' as categoryname, left(isnull(p.colorname,''),27) + '..' as colorname, left(isnull(p.colorcode,''),10) + '..' as colorcode, p.psizename, ot.quantity,isnull(ot.sale_price,0.00) as paidprice,(ot.quantity*isnull(ot.sale_price,0)) as total, 'https://www.nywdinc.com' + isnull(thumbimageurl,'') as imageurl from orderdetails_Temptb ot inner join Orders_tempTb o on ot.orderid=o.orderid and o.Orderstatusid = 44 INNER JOIN ProductsTb p ON ot.ProductID = p.productid inner join picturestb pic on pic.productid = ot.productid and number = 1 where o.wholesaleuserid='" + userid + "' order by categoryname asc");
            if (dt.Rows.Count > 0)
            {
                hasorder = true;
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
        return hasorder;
    }

    public bool hasDailyOrder(string userid)
    {
        bool hasorder = false;
        try
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Open();
            DataTable dt = InlineDataTable("SELECT oservicecharge as servicecharge, ot.orderdetailsid as cartid, left(p.ProductName,15) + '..' as productname, p.brandname ,left(p.categoryname,15) + '..' as categoryname, left(isnull(p.colorname,''),27) + '..' as colorname, left(isnull(p.colorcode,''),10) + '..' as colorcode, p.psizename, ot.quantity,isnull(ot.sale_price,0.00) as paidprice,(ot.quantity*isnull(ot.sale_price,0)) as total, 'https://www.nywdinc.com' + isnull(thumbimageurl,'') as imageurl from orderdetails_Temptb ot inner join Orders_tempTb o on ot.orderid=o.orderid and o.Orderstatusid = 42 INNER JOIN ProductsTb p ON ot.ProductID = p.productid inner join picturestb pic on pic.productid = ot.productid and number = 1 where o.wholesaleuserid='" + userid + "' order by categoryname asc");
            if (dt.Rows.Count > 0)
            {
                hasorder = true;
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
        return hasorder;
    }

    public void bindsalesagent()
    {
        try
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Open();
            string msg = "";
            Create.Style.Add("display", "block");
            //lihelp.Style.Add("display", "none");

            lihelp.Visible = false;

            //  string Name = "";
            DataTable dtc = InlineDataTable("select FirstName,esun_lastlogin from SalesAgentTB Where SalesAgentID = '" + UserID + "' ");
            if (dtc.Rows.Count > 0)
            {
                msg = dtc.Rows[0]["esun_lastlogin"].ToString().Replace("/", "-");
                if (msg != "")
                {
                    
                    if (SalesAgentID == "43")
                    {
                        //lblcompanyname.Text = dtc.Rows[0]["FirstName"].ToString().ToUpper() + "!";
                    }
                    else
                    {
                        //lblcompanyname.Text = dtc.Rows[0]["FirstName"].ToString().ToUpper() + "! &nbsp;&nbsp;<a href='MeetingSchedule/meetingSchedule_part1.aspx' class='modal-link'><img src='images/needhelp.jpg'></b></a>";
                    }
                }
                else
                {
                    if (SalesAgentID == "43")
                    {
                        //lblcompanyname.Text = dtc.Rows[0]["FirstName"].ToString() + "! ";
                    }
                    else
                    {
                       // lblcompanyname.Text = dtc.Rows[0]["FirstName"].ToString() + "! &nbsp;&nbsp;<a href='MeetingSchedule/meetingSchedule_part1.aspx' class='modal-link'><img src='images/needhelp.jpg'></a>";
                    }
                }

                
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
    }

    //public void bindframes()
    //{
    //    try
    //    {
    //        if (Conn.State == ConnectionState.Open)
    //        {
    //            Conn.Close();
    //        }
    //        Conn.Open();
    //        string qstr = "";
    //        if (flag == "1")
    //        {
    //            qstr = "select categoryname, productcategoryid, count(p.productid) as cnt from dbo.ProductsTb p with(nolock)  Inner Join dbo.OchkeeStockTb o with(nolock) on p.ProductID = o.ProductID  left join User_APrice_productwise_esun_new ap with(nolock) on ap.productid = p.ProductID and ap.UserID = " + UserID + " left join User_APrice_default_esun_new ad with(nolock) on ad.brandid = p.ProductCategoryID and ad.UserID = " + UserID + "  inner join wholesaleuserstb w on w.wholesaleusersid = " + UserID + " left join salesAgent_brand_showunshow es with(nolock) on p.productcategoryid = es.abrandid and es.aSalesAgentID = " + SalesAgentID + "  where  (case when (p.productname like '%ASSORTED%' or p.colorcode like '%ASSORTED%') then 'yes' else 'no' end) = 'no' and  (case when isnull(es.aID,0) <> 0 then case when '" + flag + "' = '1' then case when Level1ToShow like '%" + UserID + "%' then 'show' when Level2ToShow  like '%" + UserID + "%' then 'show' when Level3ToShow like '%" + UserID + "%' then 'show' when Level4ToShow like '%" + UserID + "%' then 'show' else	'unshow' end else case when isnull(Unshowtoagent,0) = 0 then 'show' else 'unshow' end end else 'show' end ) = 'show' and isnull(p.price_paid,0) <> 0  and (p.brandID = 1 or p.brandid = 2) and ((ISNULL(o.QtyLocation1,0) + isnull((select sum(ISNULL(quantity,0)) from dbo.orderdetails_Temptb inner join dbo.Orders_tempTb on dbo.orders_Temptb.orderid=dbo.orderdetails_Temptb.OrderID where Orderstatusid in ('37') and dbo.OrderDetails_tempTb.productID=p.ProductID and SuppName in ('1','Store 1','Store1') ),0) ) > 0 ) and ((ISNULL(ad.brandid,0) = p.ProductCategoryID and 0 = (case when isnull(ap.brandid,0) = 0 then 0 else isnull(ap.Status,0) end ) and 1 = (case when isnull(ap.brandid,0) = 0 then 1 else isnull(ap.showbrand,0) end ) ) or (ap.brandid = p.ProductCategoryID and ISNULL(showbrand,0) = 1 and isnull(ap.APrice_3,0) not in (0,0.00)  and ISNULL(Status,0) = 0  ) )	group by categoryname, productcategoryid order by categoryname";
    //        }
    //        else
    //        {
    //            qstr = "SELECT p.categoryname, p.productcategoryid, count(p.productid) as cnt from dbo.ProductsTb p with(nolock) Inner Join dbo.OchkeeStockTb o with(nolock) on p.ProductID = o.ProductID left join salesAgent_brand_showunshow es with(nolock) on p.productcategoryid = es.abrandid and es.aSalesAgentID = " + SalesAgentID + " where p.productcategoryid not in (68) and  (case when isnull(es.aID,0) <> 0 then case when '" + flag + "' = '1' then case when Level1ToShow like '%" + UserID + "%' then 'show' when Level2ToShow  like '%" + UserID + "%' then 'show' when Level3ToShow like '%" + UserID + "%' then 'show' when Level4ToShow like '%" + UserID + "%' then 'show' else	'unshow' end else case when isnull(Unshowtoagent,0) = 0 then 'show' else 'unshow' end end else 'show' end ) = 'show' and (case when (p.productname like '%ASSORTED%' or p.colorcode like '%ASSORTED%') then 'yes' else 'no' end) = 'no' and isnull(p.price_paid,0) <> 0 and (p.brandID = 1 or p.brandid = 2) and ((ISNULL(o.QtyLocation1,0) + isnull((select sum(ISNULL(quantity,0)) from dbo.orderdetails_Temptb inner join dbo.Orders_tempTb on dbo.orders_Temptb.orderid=dbo.orderdetails_Temptb.OrderID where Orderstatusid in ('37') and dbo.OrderDetails_tempTb.productID=p.ProductID and SuppName in ('1','Store 1','Store1') ),0) ) > 0 ) group by p.categoryname, p.productcategoryid order by categoryname";
    //        }
    //        DataTable dt = InlineDataTable(qstr);
    //        if (dt.Rows.Count > 0)
    //        {
    //            string ch = "";
    //            int itemcount = dt.Rows.Count;
    //            for (int j = 0; j < 6; j++)
    //            {
    //                StringBuilder html = new StringBuilder();
    //                int row = 12; // Change this value if you want to increase or decrease rows for frame header
    //                for (int i = (j * row); i < dt.Rows.Count; i++)
    //                {
    //                    if (row == 0)
    //                    {
    //                        break;
    //                    }
    //                    else
    //                    {
    //                        html.Append(ltlframes_og.Text.Replace("[frames]", "<tr><td class=\"f1\"><a href=\"brandlisting.aspx?b=" + dt.Rows[i]["productcategoryid"].ToString() + "&n=" + dt.Rows[i]["categoryname"].ToString() + "\">" + dt.Rows[i]["categoryname"].ToString() + " <span style=\"font-weight:100\"><i>(" + dt.Rows[i]["cnt"].ToString() + ")</i></span></a></td></tr>"));
    //                        row--;
    //                    }
    //                }
    //                ltlframes.Text += "<div class=\"frames\" style=\"float:left; margin-right:10px;\"><table>" + html.ToString() + "</table></div>";
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    { }
    //    finally
    //    {
    //        dCmd.Dispose();
    //        Conn.Close();
    //    }
    //}
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = InlineDataTable("insert into esunLoginSessionLogs ([UserID],[TerminalID],[LoginDateTime],[loginCity],[loginState],[loginCountry],[LogoutDateTime],[LogMessageID],[UserType],[Status],[UserName],logwebsitename) Select '" + UserID + "','" + terminalID + "',NULL,NULL,NULL,NULL,Getdate(),2," + flag + ",NULL,'" + userName + "','NYWDINC' ; update esunLoginSessionLogs set Status = 1 where LogID = " + activeid + "; select 1");

            Delete_Cookie("UserID");
            Delete_Cookie("Username");
            Delete_Cookie("flag");
            Delete_Cookie("activeid");
            Delete_Cookie("Accept");
            Delete_Cookie("SalesAgentID");
            Delete_Cookie("SalesAgentName");
            Delete_Cookie("isOrder");
            Delete_Cookie("ops");
            Delete_Cookie("profileprefix");
            Delete_Cookie("Company");
            Delete_Cookie("Referralid");
            Delete_Cookie("Email");
            if (Cookies_Read("remember") != "1")
            {
                Delete_Cookie("remember");
                Delete_Cookie("p");
                Delete_Cookie("u");
            }
           
            Session.Abandon();
        }
        catch (Exception ex)
        {
            Delete_Cookie("UserID");
            Delete_Cookie("Username");
            Delete_Cookie("flag");
            Delete_Cookie("activeid");
            Delete_Cookie("Accept");
            Delete_Cookie("SalesAgentID");
            Delete_Cookie("SalesAgentName");
            Delete_Cookie("isOrder");
            Delete_Cookie("ops");
            Delete_Cookie("profileprefix");
            Delete_Cookie("Company");
            Delete_Cookie("Referralid");
            Delete_Cookie("Email");
            if (Cookies_Read("remember") != "1")
            {
                Delete_Cookie("remember");
                Delete_Cookie("p");
                Delete_Cookie("u");
            }

            Session.Abandon();
        }
        finally
        {
            if (Conn.State == ConnectionState.Open)
            {
                // dCmd1.Dispose();
                Conn.Close();
            }
        }
        Response.Redirect("index");
    }

    public void bindProductGrid(bool IsMobile)
    {
        try
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Open();
            string qstr = "";
            if (flag == "1")
            {
                qstr = "select categoryname, productcategoryid, count(p.productid) as cnt from dbo.ProductsTb p with(nolock)  Inner Join dbo.OchkeeStockTb o with(nolock) on p.ProductID = o.ProductID  inner join User_APrice_productwise_esun_new ap with(nolock) on ap.productid = p.ProductID and ap.UserID = " + UserID + " inner join wholesaleuserstb w on w.wholesaleusersid = " + UserID + " left join salesAgent_brand_showunshow es with(nolock) on p.productcategoryid = es.abrandid and es.aSalesAgentID = " + SalesAgentID + "  where case when isnull(w.chkprefclient,0) = 1 then 1 when isnull(w.chkprefclient,0) = 0 and isnull(p.chkprefsku,0) = 1 then 0 else 1 end = 1  and (  (case when (p.productname like '%ASSORTED%' or p.colorcode like '%ASSORTED%') then 'yes' else 'no' end) = 'no' and   (case when isnull(es.aID,0) <> 0 then case when '" + flag + "' = '1' then case when ',' + Level"+uLevel+"ToShow + ',' like '%," + UserID + ",%' then 'show'  else	'unshow' end else case when isnull(Unshowtoagent,0) = 0 then 'show' else 'unshow' end end else 'show' end ) = 'show' and isnull(p.price_paid,0) <> 0  and (p.brandID = 1 or p.brandid = 2) and ((ISNULL(o.QtyLocation1,0) + isnull((select sum(ISNULL(quantity,0)) from dbo.orderdetails_Temptb inner join dbo.Orders_tempTb on dbo.orders_Temptb.orderid=dbo.orderdetails_Temptb.OrderID where Orderstatusid in ('37') and dbo.OrderDetails_tempTb.productID=p.ProductID and SuppName in ('1','Store 1','Store1') ),0) ) > 0 ) and ((0 = (case when isnull(ap.brandid,0) = 0 then 0 else isnull(ap.Status,0) end ) and 1 = (case when isnull(ap.brandid,0) = 0 then 1 else isnull(ap.showbrand,0) end ) ) or (ap.brandid = p.ProductCategoryID and ISNULL(showbrand,0) = 1 and isnull(ap.APrice_3,0) not in (0,0.00)  and ISNULL(Status,0) = 0  ) ) )	group by categoryname, productcategoryid order by categoryname";
            }
            else
            {
                qstr = "SELECT p.categoryname, p.productcategoryid, count(p.productid) as cnt from dbo.ProductsTb p with(nolock) Inner Join dbo.OchkeeStockTb o with(nolock) on p.ProductID = o.ProductID left join salesAgent_brand_showunshow es with(nolock) on p.productcategoryid = es.abrandid and es.aSalesAgentID = " + SalesAgentID + " where p.productcategoryid not in (68) and (case when isnull(es.aID,0) <> 0 then case when '" + flag + "' = '2' then case when isnull(Unshowtoagent,0) = 0 then 'show' else 'unshow' end end else 'show' end ) = 'show' and (case when (p.productname like '%ASSORTED%' or p.colorcode like '%ASSORTED%') then 'yes' else 'no' end) = 'no' and isnull(p.price_paid,0) <> 0 and (p.brandID = 1 or p.brandid = 2) and ((ISNULL(o.QtyLocation1,0) + isnull((select sum(ISNULL(quantity,0)) from dbo.orderdetails_Temptb inner join dbo.Orders_tempTb on dbo.orders_Temptb.orderid=dbo.orderdetails_Temptb.OrderID where Orderstatusid in ('37') and dbo.OrderDetails_tempTb.productID=p.ProductID and SuppName in ('1','Store 1','Store1') ),0) ) > 0 ) group by p.categoryname, p.productcategoryid order by categoryname";
            }
            DataTable dt = InlineDataTable(qstr);
            string Header = "";
            string Footer = "";
            string Data = "";
            string bname = "";
            //  <thead><tr><th colspan='7' style='text-align:left; font-weight:normal'><a href='javascript:void(0)' onclick='viewall()'>View All Products</a>&nbsp; | &nbsp;<a href='javascript:void(0)' onclick='lnkSort()'>Sort by New Stock</a></th></tr>
            StringBuilder html = new StringBuilder();
            if (!IsMobile)
            {

                decimal counter = Convert.ToDecimal(dt.Rows.Count) / 5;
                int noOfRows =Convert.ToInt32(Math.Ceiling(counter));
                int temp = 0;
                for (int j = 0; j < 5 ; j++)
                {
                    temp = noOfRows * j;
                    html.Append("<li><ul>");
                    for (int i = 0; i < noOfRows; i++)
                    {
                        //temp = temp+i;
                        if (temp + i < dt.Rows.Count)
                        {
                            if (dt.Rows[temp + i]["categoryname"].ToString() != "")
                            {
                                bname = dt.Rows[temp + i]["categoryname"].ToString() + " (" + dt.Rows[temp + i]["cnt"].ToString() + ")";

                                bname = bname.Length > 25 ? TrimBrandName(dt.Rows[temp + i]["categoryname"].ToString(), dt.Rows[temp + i]["cnt"].ToString()) : bname;

                                //html.Append("<li><a href=\"#0\" onclick=\"document.location.href='brandlisting.aspx?b=" + dt.Rows[temp + i]["ProductCategoryID"].ToString() + "&n=" + HttpUtility.UrlEncode(dt.Rows[temp + i]["categoryname"].ToString()) + "'\">" + bname.ToLowerInvariant() + "</li>");
                                html.Append("<li><a href=\"#0\" onclick=\"document.location.href='brand-" + HttpUtility.UrlEncode(dt.Rows[temp + i]["categoryname"].ToString().Replace("&", "$")).Replace("+", "%20") + "-" + dt.Rows[temp + i]["ProductCategoryID"].ToString() + "-1-0-" + dt.Rows[temp + i]["ProductCategoryID"].ToString() + "-25'\">" + bname.ToLowerInvariant() + "</li>");
                            }
                        }

                        //temp = temp+1;  //}
                    }
                    
                    html.Append("</li></ul>");
                }
            }
            ltlBrandlist.Text = html.ToString();

        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
    }

    public string TrimBrandName(string bname,string count)
    {
        string brandName = "";

        brandName = bname.Substring(0, 17) + ".. ("+count+")";

        return brandName;
    }

    public string Cookies_Read(string CookieName)
    {
        string str = "";
        String strCookieName = CookieName;
        HttpCookie cookie = Request.Cookies[strCookieName];

        if (cookie == null)
        {
            str = "0";
        }
        else
        {
            String strCookieValue = HttpUtility.UrlDecode(cookie.Value.ToString());
            str = strCookieValue;
        }

        return str;
    }

    public void bindcartheader()
    {
        try
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Open();
            StringBuilder html = new StringBuilder();
            DataTable dt = InlineDataTable("update esunLoginSessionLogs set lastPageVisited = '" + pagename + "', LogEntryDate = Getdate(), [Status] = NULL where logID = " + activeid + "; select c.productid, cartID, (select top 1 ThumbImageURL from picturestb where productid = c.productid and number=1) as ThumbImageURL, c.productname as [title], Quantity, PaidPrice, WSPrice, RetailPrice from esun_carttb c where userid = " + UserID + " order by CartDate desc ");


            if (dt.Rows.Count > 0)
            {
                //            string ch = "";




                int itemcount = Convert.ToInt32(dt.Compute("Count(Quantity)", string.Empty));
                //                if( dt.Rows[i]["Quantity"].ToString().Length > 10)
                //                {
                //                    ch =  dt.Rows[i]["title"].ToString().Substring(0, 10);
                //                }
                //                html.Append(ltlcartsummary_og.Text.Replace("[cartid]", dt.Rows[i]["cartID"].ToString()).Replace("[imgurl]", "http://www.e-sunglass.com"+dt.Rows[i]["ThumbImageURL"].ToString()).Replace("[title]", dt.Rows[i]["title"].ToString()).Replace("[cartqty]", dt.Rows[i]["Quantity"].ToString()).Replace("[carttitle]",ch).Replace("[cartprice]", dt.Rows[i]["PaidPrice"].ToString()));

                //            ltlcartsummary.Text = html.ToString();
                lblcartcount.Text = itemcount.ToString();
               // lblcartcount1.Text = itemcount.ToString();
            }
            else
            {
                lblcartcount.Text = "";
               // lblcartcount1.Text = "";
            }
        }
        catch (Exception ex)
        { }
        finally
        {
            dCmd.Dispose();
            Conn.Close();
        }
    }
    //public void hypsearch_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("searchproduct.aspx");
    //}
    protected void Delete_Cookie(string CookieName)
    {
        HttpCookie deleteThis = new HttpCookie(CookieName);
        deleteThis.Expires = DateTime.Now.AddDays(-2);
        Response.Cookies.Add(deleteThis);
    }

   

    //public string loaddata()
    //{
    //    try
    //    {
    //        if (Conn.State == ConnectionState.Open)
    //        {
    //            Conn.Close();
    //        }

    //        Conn.Open();
    //        //            Session["WholesaleUsersID"] = ddlWholesaleUser.SelectedValue;
    //        int WholesaleUsersID = Convert.ToInt32(UserID);
    //        string msg = "";

    //        SqlDataReader dsAllCategory;
    //        SqlParameter[] arrnamePrm = new SqlParameter[1];
    //        SqlCommand cmd1 = new SqlCommand("Sp_Get_AllWholesaleUsers", Conn);
    //        cmd1.CommandType = CommandType.StoredProcedure;

    //        arrnamePrm[0] = new SqlParameter("@WholesaleUsersID", SqlDbType.Int);
    //        arrnamePrm[0].Value = Convert.ToInt32(WholesaleUsersID);

    //        cmd1.Parameters.AddRange(arrnamePrm);

    //        dsAllCategory = cmd1.ExecuteReader();

    //        if (dsAllCategory.HasRows == true)
    //        {
    //            if (dsAllCategory.Read())
    //            {
    //                //     DateTime date = Convert.ToDateTime(dsAllCategory["esun_lastlogin"].ToString());
    //                Create.Style.Add("display", "none");
    //                Create2.Style.Add("display", "none");
    //                manage.Style.Add("display", "none");
    //                manage2.Style.Add("display", "none");
    //                myaccount.Style.Add("display", "block");
    //                msg = dsAllCategory["esun_lastlogin"].ToString().Replace("/", "-");
    //                if (msg != "")
    //                {
    //                    //                        lblcompanyname.Text = Convert.ToString(dsAllCategory["CompanyName"]) + " | <span style='font-size:11px'><i>Last login " + msg + "</i></span>";
    //                    if (SalesAgentID == "43")
    //                    {
    //                        lblcompanyname.Text = dsAllCategory["CompanyName"].ToString() + "! ";
    //                    }
    //                    else
    //                    {
    //                        lblcompanyname.Text = Convert.ToString(dsAllCategory["CompanyName"]) + "! &nbsp;&nbsp;<a href='MeetingSchedule/meetingSchedule_part1.aspx' class='modal-link'><img src='images/needhelp.jpg'></a>";
    //                    }
    //                }
    //                else
    //                {
    //                    if (SalesAgentID == "43")
    //                    {
    //                        lblcompanyname.Text = dsAllCategory["CompanyName"].ToString() + "! ";
    //                    }
    //                    else
    //                    {
    //                        lblcompanyname.Text = Convert.ToString(dsAllCategory["CompanyName"]) + "! &nbsp;&nbsp;<a href='MeetingSchedule/meetingSchedule_part1.aspx' class='modal-link'><img src='images/needhelp.jpg'></a>";
    //                    }
    //                }
    //            }
    //            //Disable "Add User" and "Cancel" button [Disable "DivUpdatePrice" also]
    //        }
    //        else
    //        {

    //        }
    //        dsAllCategory.Close();
    //        return msg;
    //    }
    //    catch (Exception ex)
    //    {
    //        return "";
    //        //            errmsg.InnerHtml = "Some error occured. " + ex.Message;
    //    }
    //    finally
    //    {
    //        if (Conn.State == ConnectionState.Open)
    //        {
    //            // dCmd1.Dispose();
    //            Conn.Close();
    //        }
    //    }
    //}

    public DataTable InlineDataTable(string QueryString)
    {
        if (Conn.State == ConnectionState.Open)
        {
            Conn.Close();
        }
        Conn.Open();


        dCmd = new SqlCommand(QueryString, Conn);
        SqlDataAdapter sda = new SqlDataAdapter(dCmd);
        sda.SelectCommand.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        sda.Fill(ds);
        return ds.Tables[0];
    }
}
