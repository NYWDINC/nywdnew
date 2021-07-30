using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.IO;
using System.Collections;
using System.Resources;
using System.Reflection;

public partial class brandlisting : System.Web.UI.Page
{

    String ConnectionString = ConfigurationManager.ConnectionStrings["CON"].ToString();

    SqlConnection Conn;
    SqlCommand dCmd;
    DataTable dt = new DataTable();
    public string UserID = "";
    public bool IsMobile = true;
    public string username = "";
    public string Uflag = "";
    int pagesize = 25;
    int pgno = 1;
    public string categoryid = "1,2";
    public string brandid = "0";
    public string categoryname = "";
    string cat1 = "0";
    string cat2 = "0";
    public string minVal = "0";
    public string maxVal = "996";
    public string framematerial = "";
    public string framestyle = "";
    public string framecolor = "";
    public string lenscolor = "";
    public string country = "";
    public string gender = "";
    public string eyesize = "";
    public string searchcriteria = "";

    public string SalesAgentID = "";
    public string isAllEyewear = "";
    public string cat = "";
    public string language = "";
    public string add2cart = "";
    public string added2cart = "";
    public string PleaseWait = "";
    public string Thereisnofile = "";
    public string PopupBlock = "";
    public string incart = "";
    public int screenwidth = 0;
    public string addalltocart = "";
    public string ppage = "";
    public string email = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        UserID = Cookies_Read("UserID");
        username = Cookies_Read("Username");
        Uflag = Cookies_Read("flag");
        SalesAgentID = Cookies_Read("SalesAgentID");
        language = Cookies_Read("CultureInfo");
        screenwidth = Convert.ToInt32(Cookies_Read("Screenwidth"));
        email = Cookies_Read("Email");

        //UserID = "56";
        //username = "Biren";
        //Uflag = "1";
        //SalesAgentID = "48";

       
        if (UserID == "0")
        {
            Response.Redirect("index");
        }
        else
        {
            Conn = new SqlConnection(ConnectionString);
            //  Conn.Open();

            if (hdnpgsize.Value != "")
            {
                pagesize = Convert.ToInt32(hdnpgsize.Value);
                ddlpgoptb.SelectedValue = hdnpgsize.Value;
            }
            else{

            //if (Request.QueryString["item"] != null)
            //{
                pagesize = Convert.ToInt32(Request.QueryString["item"].ToString());
                ddlpgoptb.SelectedValue = Request.QueryString["item"].ToString();
            }
          

            if (Request.QueryString["c"] != null )
            {
                ddlfiltertype.SelectedValue = Request.QueryString["c"];
                categoryid = Request.QueryString["c"];
                divCatogary.Visible = false;
           //     divadvfilter.Visible = false;
            }
            else
            {
                if (Request.QueryString["b"] != null)
                {
                    brandid = Request.QueryString["b"].ToString();
                    categoryname = HttpUtility.UrlDecode(Request.QueryString["n"].ToString().Replace("$","&"));
                    divcat.Visible = false;
                    divadvcat.Visible = false;
                }
            }
            

            //if (Request.QueryString["cat"] != null && Request.QueryString["cat"] != "")
            //{
            //    if (Request.QueryString["cat"].ToString() != "0")
            //    {
            //        //ddlfiltertype.SelectedIndex = Convert.ToInt32(Request.QueryString["cat"].ToString());
            //        categoryid = Request.QueryString["cat"].ToString();
            //       // ddlfiltertype.SelectedValue = categoryid;
            //    }
            //    else
            //    {
            //        //ddlfiltertype.SelectedIndex = 0;
            //        //categoryid = Request.QueryString["cat"].ToString();
            //    }
            //}
            //if (Request.QueryString["b"] != null)
            //{
            //    brandid = Request.QueryString["b"].ToString();
            //}
            if (Request.QueryString["p"] != null && Request.QueryString["p"] != "")
            {
                lblstartpg.Value = Request.QueryString["p"].ToString();
            }
            else
            {
                lblstartpg.Value = "1";
            }

            if (Request.QueryString["n"] != null && Request.QueryString["n"] != "")
            {
                if (ddlfiltertype.SelectedValue == "" || ddlfiltertype.SelectedValue == "0")
                {
                    lblbrandname.Text = Request.QueryString["n"].ToString().Replace("$","&");
                    lblbrandname2.Text = Request.QueryString["n"].ToString().Replace("$", "&");
                }
                else if (ddlfiltertype.SelectedValue == "1" && Request.QueryString["c"] != null)
                {
                    string str = "";
                    
                    str = Resources.Resources.ResourceManager.GetString("Sunglasses");

                    //str = language != "es" ? "Sunglasses" : "Gafas de sol";
                    lblbrandname.Text = str;//"Sunglasses";
                    lblbrandname2.Text = str;
                    Div1.Visible = false;
                    ppage = "sun";
                   
                }
                else if (ddlfiltertype.SelectedValue == "2" && Request.QueryString["c"] != null)
                {
                    lblbrandname.Text = Resources.Resources.ResourceManager.GetString("Opticals"); //"Opticals";
                    lblbrandname2.Text = Resources.Resources.ResourceManager.GetString("Opticals");
                    Div1.Visible = false;
                    ppage = "eye";

                }
            }



             if (!IsPostBack)
            {
                if (Request.QueryString["brand"] != null)
                {
                    if (Request.QueryString["brand"].ToString() != "0")
                    {
                        hdncategory.Value = Request.QueryString["brand"] != null ? Request.QueryString["brand"].ToString() : brandid;
                        Session["lsesCategory"] = Request.QueryString["brand"].ToString();
                    }
                    else
                    {
                        hdncategory.Value = brandid;
                    }

                }
                    
                if (Request.QueryString["b"] != null)
                {
                    if (Request.QueryString["b"].ToString() == "0" || Request.QueryString["b"].ToString() == "")
                    {
                        try
                        {
                            // ddlCategory.SelectedValue = "0";
                        }
                        catch { }
                    }
                    else if (Request.QueryString["b"].ToString().Contains(",") == false && Request.RawUrl.Contains("/all-"))
                    {
                        try
                        {
                            ddlCategory.SelectedValue = Request.QueryString["b"].ToString();
                        }
                        catch { }
                    }
                }
                //hdncategory.Value = brandid;
                //if (brandid == "0" || brandid == "")
                //{
                //    try
                //    {
                //        // ddlCategory.SelectedValue = "0";
                //    }
                //    catch { }
                //}
                //else if (brandid.Contains(",") == false)
                //{
                //    try
                //    {
                //        ddlCategory.SelectedValue = brandid;
                //    }
                //    catch { }
                //}
                //if (brandid != "0")
                //{
                //    ddlCategory.SelectedValue = brandid;
                //}
                //hdnfilter.Value = categoryid;
                //if (categoryid != "1,2")
                //{
                //    ddlfiltertype.SelectedValue = categoryid;
                //}
                //else
                //{
                //    ddlfiltertype.SelectedValue = "0";
                //}

                if (Request.QueryString["cat"] != null)
                {
                    if (Request.QueryString["cat"].ToString() != "0")
                    {
                        hdnfilter.Value = Request.QueryString["cat"] != null ? Request.QueryString["cat"].ToString() : categoryid;
                    }
                    else
                    {
                        hdnfilter.Value = categoryid;
                    }
                }
                //if (Request.QueryString["brand"] != null)
                //{
                //    if (Request.QueryString["brand"].ToString() == "0")
                //    {
                //        ddlCategory.SelectedValue = "0";
                //    }
                //    else
                //    {
                //        ddlCategory.SelectedValue = Request.QueryString["brand"].ToString();
                //    }
                //}
                //hdnfilter.Value = Request.QueryString["cat"] != null ? Request.QueryString["cat"].ToString() : "";
                if (Request.QueryString["cat"] != null)
                {
                    if (Request.QueryString["cat"].ToString() == "1,2")
                    {
                        try
                        {
                            ddlfiltertype.SelectedValue = "";
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            if (Request.QueryString["cat"].ToString() == "0")
                            {
                                ddlfiltertype.SelectedValue = "";
                            }
                            else
                            {
                                ddlfiltertype.SelectedValue = Request.QueryString["cat"].ToString();
                            }
                        }
                        catch { }
                    }
                }
                hdnfilter.Value = Session["lsesFilter"] != null ? Session["lsesFilter"].ToString() : "";

                hdncategory.Value = Session["lsesCategory"] != null ? Session["lsesCategory"].ToString(): "0";
                hdncategoryname.Value = Session["lsesCategoryname"] != null ? Session["lsesCategoryname"].ToString() : "";
                hdnFrameMaterial.Value = Session["lsesFramematerial"] != null ? Session["lsesFramematerial"].ToString() : "";
                hdnFrameStyle.Value = Session["lsesFramestyle"] != null ? Session["lsesFramestyle"].ToString() : "";
                hdnCountry.Value = Session["lsesCountry"] != null ? Session["lsesCountry"].ToString() : "";
                hdnGender.Value = Session["lsesGender"] != null ? Session["lsesGender"].ToString() : "";
                hdnFrameColor.Value = Session["lsesFramecolor"] != null ? Session["lsesFramecolor"].ToString() : "";
                hdnlenscolor.Value = Session["lseslenscolor"] != null ? Session["lseslenscolor"].ToString() : "";
                hdneyesize.Value = Session["lseseyesize"] != null ? Session["lseseyesize"].ToString() : "";

               hdnMaxValue.Value = Session["lsesmaxvalue"]!=null ? Session["lsesmaxvalue"].ToString():"996";
               hdnMinValue.Value=Session["lsesminvalue"]!=null ? Session["lsesminvalue"].ToString():"0";
               hdnsortby.Value = Session["lsesSort"] != null ? Session["lsesSort"].ToString() : "";
               currentfilter.Value = Session["lcurrentfilter"] != null ? Session["lcurrentfilter"].ToString() : "";
               hdnetop.Value = Session["lsesetop"] != null ? Session["lsesetop"].ToString() : "";
              
                if (brandid == "0" )
                {
                    //bindCategories();
                }
                else
                {
                    //////divcat.Visible = false;
                    
                    //////divadvcat.Visible = false;
                    //divframematerial.Visible = false;
                    //divframecolor.Visible = false;
                    //divframestyle.Visible = false;
                    //divcountry.Visible = false;
                
                }
                // pgsize();
                findclick();
                bindCategories();
                 //  bindFilter();
            }
            else
            {


                //ScriptManager.RegisterStartupScript(this, typeof(Page), "load2", "<script type=\"text/javascript\"> pageLoad('" + hdnfilter.Value + "','" + hdnFrameMaterial.Value + "','" + hdnFrameStyle.Value + "','" + hdnCountry.Value + "','" + hdnGender.Value + "','" + hdncategory.Value + "','" + hdnFrameColor.Value + "','" + hdnlenscolor.Value + "','" + ddlfiltertype.SelectedValue + "'); </" + "script>", false);
                

              //  hdncategory.Value = ddlCategory.SelectedValue;
               // bindAdvSearchCat();
            }
             ScriptManager.RegisterStartupScript(this, typeof(Page), "load2", "<script type=\"text/javascript\"> pageLoad('" + hdnfilter.Value + "','" + hdnFrameMaterial.Value + "','" + hdnFrameStyle.Value + "','" + hdnCountry.Value + "','" + hdnGender.Value + "','" + hdncategory.Value + "','" + hdnFrameColor.Value + "','" + hdnlenscolor.Value + "','" + ddlfiltertype.SelectedValue + "'); </" + "script>", false);
             Session["lsesCategory"] = null;
             Session["lsesFilter"] = null;
             Session["lsesFramematerial"] = null;
             Session["lsesFramestyle"] = null;
             Session["lsesCountry"] = null;
             Session["lsesGender"] = null;
             Session["lsesFramecolor"] = null;
             Session["lseslenscolor"] = null;
             Session["lseseyesize"] = null;
             Session["lsesmaxvalue"] = null;
             Session["lsesminvalue"] = null;
             Session["lsesSort"] = null;
             Session["lsesetop"] = null;
             //Session["startpage"] = null;
        }

        if (Request.QueryString["b"] == "0")
        {
           // if (Uflag == "1")
           // {
                btndownloadfeed.Visible = true;
           // }
           // else
           // {
            //    btndownloadfeed.Visible = false;
           // }
        }
         addalltocart = Resources.Resources.ResourceManager.GetString("Addalltocart");
        add2cart = Resources.Resources.ResourceManager.GetString("AddtoCart");
        added2cart = Resources.Resources.ResourceManager.GetString("AddedtoCart");
        incart = Resources.Resources.ResourceManager.GetString("incart");
        PleaseWait = Resources.Resources.ResourceManager.GetString("PleaseWait");
        Thereisnofile = Resources.Resources.ResourceManager.GetString("Thereisnofile");
        PopupBlock = Resources.Resources.ResourceManager.GetString("PopupBlock");
        exceltxt.InnerHtml = Resources.Resources.ResourceManager.GetString("thankyoudownload") + " <b>" + email + "</b>.";

    }



    public void bindAdvFilter()
    {
        StringBuilder htmlFilter = new StringBuilder();
        StringBuilder htmlFramematerial = new StringBuilder();
        StringBuilder htmlFramecolor = new StringBuilder();
        StringBuilder htmlFramestyle = new StringBuilder();
        StringBuilder htmlCountry = new StringBuilder();


        #region Bind Filter in Advance Search

        int filterCount = ddlfiltertype.Items.Count;

        htmlFilter.Append("<ul>");
        for (int i = 0; i < filterCount; i++)
        {
            //if (ddlfiltertype.Items[i].Text == "All" && (hdnfilter.Value == "" || hdnfilter.Value == "0"))
            //{
            //    htmlFilter.Append("<li><a href='#0' onclick='setddlfiltertype(" + i + ")' class='active'>" + ddlfiltertype.Items[i].Text + "</a></li>");
            //}
            //else
            //{
            //    if (ddlfiltertype.Items[i].Value == hdnfilter.Value)
            //    {
            //        htmlFilter.Append("<li><a href='#0' onclick='setddlfiltertype(" + i + ")' class='active'>" + ddlfiltertype.Items[i].Text + "</a></li>");
            //    }
            //    else
            //    {
            //        htmlFilter.Append("<li><a href='#0' onclick='setddlfiltertype(" + i + ")' >" + ddlfiltertype.Items[i].Text + "</a></li>");
            //    }
            //}

            if (ddlfiltertype.Items[i].Value == hdnfilter.Value)
                {
                    htmlFilter.Append("<label for=\"1\" class=\"label-cbx\">");
                    htmlFilter.Append("<input id=\"1\" type=\"checkbox\" class=\"cat invisible\" onclick=\"checkFilter()\">");
                    htmlFilter.Append("<div class=\"checkbox\">");
                    htmlFilter.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
                    htmlFilter.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
                    htmlFilter.Append("</div><span>" + ddlfiltertype.Items[i].Text + "</span></label>");
                }
                else
                {
                    htmlFilter.Append("<label for=\"2\" class=\"label-cbx\">");
                    htmlFilter.Append("<input id=\"2\" type=\"checkbox\" class=\"cat invisible\" onclick=\"checkFilter()\">");
                    htmlFilter.Append("<div class=\"checkbox\">");
                    htmlFilter.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
                    htmlFilter.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
                    htmlFilter.Append("</div><span>" + ddlfiltertype.Items[i].Text + "</span></label>");
                }
            
        }
        htmlFilter.Append("</ul>");
        ltlFilter.Text = htmlFilter.ToString();

        #endregion

        #region Bind Frame Material in Advance Search

        if (ddlframematerial.Items.Count > 0)
        {
            int itemCount = ddlframematerial.Items.Count;

            //if (hdnFrameMaterial.Value == "0" || hdnFrameMaterial.Value == "")
            //{
            //    htmlFramematerial.Append("<ul><li><a href='#0' class='active' onclick='setFrameMaterial(0)'>All</a></li>");
            //}
            //else
            //{
            //    htmlFramematerial.Append("<ul><li><a href='#0'  onclick='setFrameMaterial(0)'>All</a></li>");
            //}
            
            
            for (int i = 0; i < itemCount; i++)
            {

                htmlFramematerial.Append("<label for=\"" + ddlframematerial.Items[i].Text + "\" class=\"label-cbx\">");
                htmlFramematerial.Append("<input id=\"" + ddlframematerial.Items[i].Text + "\" type=\"checkbox\"  class=\"cat invisible\" onclick=\"checkFramematerial()\">");
                htmlFramematerial.Append("<div class=\"checkbox\">");
                htmlFramematerial.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
                htmlFramematerial.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
                htmlFramematerial.Append("</div><span>" + ddlframematerial.Items[i].Text + "</span></label>");

                //if (ddlframematerial.Items[i].Value != "" && ddlframematerial.Items[i].Value != null  && ddlframematerial.Items[i].Value !="SELECT")
                //{
                //    if (ddlframematerial.Items[i].Value == hdnFrameMaterial.Value)
                //    {
                //        htmlFramematerial.Append("<li><a href='#0' class='active' onclick='setFrameMaterial(\"" + ddlframematerial.Items[i].Value + "\")'>" + ddlframematerial.Items[i].Value + "</a></li>");
                //    }
                //    else
                //    {
                //        htmlFramematerial.Append("<li><a href='#0' onclick='setFrameMaterial(\"" + ddlframematerial.Items[i].Value + "\")'>" + ddlframematerial.Items[i].Value + "</a></li>");
                //    }
                //}

            }
            htmlFramematerial.Append("</ul>");
            ltlFramematerial.Text = htmlFramematerial.ToString();
        }
        else
        {
            divframematerial.Visible = false;
        }


        #endregion

        #region Bind Frame Color in Advance Search

        if (ddlframecolor.Items.Count > 0)
        {

            //divframecolor.Visible = false;

            int itemCount = ddlframecolor.Items.Count;

            if (hdnFrameColor.Value == "0" || hdnFrameColor.Value=="")
            {
                htmlFramecolor.Append("<ul><li><a href='#0' class='active' onclick='setFrameColor(0)'>All</a></li>");
            }
            else
            {
                htmlFramecolor.Append("<ul><li><a href='#0'  onclick='setFrameColor(0)'>All</a></li>");
            }


            //for (int i = 0; i < itemCount; i++)
            //{
            //    if (ddlframecolor.Items[i].Value != "" && ddlframecolor.Items[i].Value != null)
            //    {
            //        if (ddlframecolor.Items[i].Value == hdnFrameColor.Value)
            //        {
            //            htmlFramecolor.Append("<li><a href='#0' class='active' onclick='setFrameColor(\"" + ddlframecolor.Items[i].Value + "\")'>" + ddlframecolor.Items[i].Value + "</a></li>");
            //        }
            //        else
            //        {
            //            htmlFramecolor.Append("<li><a href='#0' onclick='setFrameColor(\"" + ddlframecolor.Items[i].Value + "\")'>" + ddlframecolor.Items[i].Value + "</a></li>");
            //        }
            //    }
            //}
            htmlFramecolor.Append("</ul>");
           // ltlFramecolor.Text = htmlFramecolor.ToString();
        }
        else
        {
          //  divframecolor.Visible = false;
        }


        #endregion

        #region Bind Frame Style in Advance Search

        if (ddlframestyle.Items.Count > 0)
        {
            int itemCount = ddlframestyle.Items.Count;

            if (hdnFrameStyle.Value == "0" || hdnFrameStyle.Value == "")
            {
                htmlFramestyle.Append("<ul><li><a href='#0' class='active' onclick='setFrameStyle(0)'>All</a></li>");
            }
            else
            {
                htmlFramestyle.Append("<ul><li><a href='#0'  onclick='setFrameStyle(0)'>All</a></li>");
            }


            for (int i = 0; i < itemCount; i++)
            {
                if (ddlframestyle.Items[i].Value != "" && ddlframestyle.Items[i].Value != null)
                {
                    if (ddlframestyle.Items[i].Value == hdnFrameStyle.Value)
                    {
                        htmlFramestyle.Append("<li><a href='#0' class='active' onclick='setFrameStyle(\"" + ddlframestyle.Items[i].Value + "\")'>" + ddlframestyle.Items[i].Value + "</a></li>");
                    }
                    else
                    {
                        htmlFramestyle.Append("<li><a href='#0' onclick='setFrameStyle(\"" + ddlframestyle.Items[i].Value + "\")'>" + ddlframestyle.Items[i].Value + "</a></li>");
                    }
                }
            }
            htmlFramestyle.Append("</ul>");
            //ltlFramestyle.Text = htmlFramestyle.ToString();
        }
        else
        {
           // divframestyle.Visible = false;
        }


        #endregion

        #region Bind Country in Advance Search

        if (ddlCountry.Items.Count > 0)
        {
            int itemCount = ddlCountry.Items.Count;

            if (hdnCountry.Value == "0" || hdnCountry.Value == "")
            {
                htmlCountry.Append("<ul><li><a href='#0' class='active' onclick='setCountry(0)'>All</a></li>");
            }
            else
            {
                htmlCountry.Append("<ul><li><a href='#0'  onclick='setCountry(0)'>All</a></li>");
            }


            for (int i = 0; i < itemCount; i++)
            {
                if (ddlCountry.Items[i].Value != "" && ddlCountry.Items[i].Value != null)
                {
                    if (ddlCountry.Items[i].Value == hdnCountry.Value)
                    {
                        htmlCountry.Append("<li><a href='#0' class='active' onclick='setCountry(\"" + ddlCountry.Items[i].Value + "\")'>" + ddlCountry.Items[i].Value + "</a></li>");
                    }
                    else
                    {
                        htmlCountry.Append("<li><a href='#0' onclick='setCountry(\"" + ddlCountry.Items[i].Value + "\")'>" + ddlCountry.Items[i].Value + "</a></li>");
                    }
                }
            }
            htmlCountry.Append("</ul>");
           // ltlCountry.Text = htmlCountry.ToString();
        }
        else
        {
           // divcountry.Visible = false;
        }


        #endregion
    }

    public void bindAdvSearchCat()
    {
        StringBuilder htmlBrands = new StringBuilder();
        

        //htmlBrands.Append("<ul>");
        int iCount = ddlCategory.Items.Count;
       
        for (int i = 0; i < iCount; i++)
        {
            //if (ddlCategory.Items[i].Value == hdncategory.Value && (hdncategory.Value != "" && hdncategory.Value != "0"))
            //{
            //    htmlBrands.Append("<li><a href='#0' class='active' onclick='setddlcategory(" + ddlCategory.Items[i].Value + ")'>" + ddlCategory.Items[i].Text + "</a></li>");
            //}
            //else if ((hdncategory.Value == "" || hdncategory.Value == "0") && ddlCategory.Items[i].Value == "")
            //{
            //    htmlBrands.Append("<li><a href='#0' class='active' onclick='setddlcategory(0)'>All</a></li>");
            //}
            //else if (ddlCategory.Items[i].Value == "")
            //{
            //    htmlBrands.Append("<li><a href='#0' onclick='setddlcategory(0)'>All</a></li>");
            //}
            //else
            //{
            //    htmlBrands.Append("<li><a href='#0' onclick='setddlcategory(" + ddlCategory.Items[i].Value + ")'>" + ddlCategory.Items[i].Text + "</a></li>");
            //}
            htmlBrands.Append("<label for=\"" + ddlCategory.Items[i].Value + "\" class=\"label-cbx\">");
            htmlBrands.Append(" <input id=\"" + ddlCategory.Items[i].Value + "\" type=\"checkbox\" class=\"cat invisible\" onclick=\"checkCategory()\">");
            htmlBrands.Append("<div class=\"checkbox\">");
            htmlBrands.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\"><path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
            htmlBrands.Append("</div><span>" + ddlCategory.Items[i].Text + "</span></label>");
                      

        }
       // htmlBrands.Append("</ul>");
        ltlBrands.Text = htmlBrands.ToString();
    }

    public void bindFilter()
    {
        StringBuilder htmlFilter = new StringBuilder();
        StringBuilder htmlFramematerial = new StringBuilder();

        #region Bind category in Advance Search
        //htmlFilter.Append("<ul><li><a href='#0' onclick='setddlfiltertype(0)' class='active'>All</a></li><li><a href='#0' onclick='setddlfiltertype(1)'>Sunglasses</a></li><li><a href='#0' onclick='setddlfiltertype(2)'>Eyeglasses</a></li></ul>");

        //htmlFilter.Append("<label for=\"All\" class=\"label-cbx\">");
        //htmlFilter.Append("<input id=\"All\" type=\"checkbox\" class=\"invisible\">");
        //htmlFilter.Append("<div class=\"checkbox\" onclick=\"setddlfiltertype('All')\">");
        //htmlFilter.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
        //htmlFilter.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
        //htmlFilter.Append("</div><span>All</span></label>");


        htmlFilter.Append("<label for=\"sunglass\" class=\"label-cbx\">");
        htmlFilter.Append("<input id=\"sunglass\" type=\"checkbox\" class=\"cat invisible\" onclick=\"checkFilter()\" >");
        htmlFilter.Append("<div class=\"checkbox\" >");
        htmlFilter.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
        htmlFilter.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
        htmlFilter.Append("</div><span>" + Resources.Resources.ResourceManager.GetString("Sunglasses") + " (" + hdnsunglasscount.Value + ")</span></label>");

        htmlFilter.Append("<label for=\"eyeglass\" class=\"label-cbx\">");
        htmlFilter.Append("<input id=\"eyeglass\" type=\"checkbox\" class=\"cat invisible\" onclick=\"checkFilter()\">");
        htmlFilter.Append("<div class=\"checkbox\">");
        htmlFilter.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
        htmlFilter.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
        htmlFilter.Append("</div><span>" + Resources.Resources.ResourceManager.GetString("Opticals1") + " (" + hdneyeglasscount.Value + ")</span></label>");
        ltlFilter.Text = htmlFilter.ToString();
        #endregion    
    }

    protected void lnkViewCart_Click(object sender, EventArgs e)
    {

        string session = Session["AddCartLabelVal"] as string;
        if (string.IsNullOrEmpty(session))
        {

        }
        else
        {
            string filter = "";
            filter = hdnfilter.Value != "1,2" ? hdnfilter.Value : "0";

            string catfilter = "";
            catfilter = hdncategory.Value != "" ? hdncategory.Value : "0";


            if (hdnfilter.Value == "1,2" || hdnfilter.Value == "2,1")
            {
                ddlfiltertype.SelectedValue = "0";
            }
            else
            {
                if (hdnfilter.Value == "")
                {
                    ddlfiltertype.SelectedValue = "0";
                    filter = "1,2";
                }
                else
                {
                    ddlfiltertype.SelectedValue = hdnfilter.Value;
                }
            }
            lblMessage.Text = Session["AddCartLabelVal"].ToString();
            Session["AddCartLabelVal"] = "";
            //findclick();
            Session["lsesCategory"] = hdncategory.Value;
            Session["lsesFilter"] = hdnfilter.Value;
            Session["lsesFramematerial"] = hdnFrameMaterial.Value;
            Session["lsesFramestyle"] = hdnFrameStyle.Value;
            Session["lsesCountry"] = hdnCountry.Value;
            Session["lsesGender"] = hdnGender.Value;
            Session["lsesFramecolor"] = hdnFrameColor.Value;
            Session["lseslenscolor"] = hdnlenscolor.Value;
            Session["lsesmaxvalue"] = hdnMaxValue.Value;
            Session["lsesminvalue"] = hdnMinValue.Value;
            Session["lsesSort"] = hdnsortby.Value;


            //Response.Redirect(Request.RawUrl.Remove(Request.RawUrl.LastIndexOf('-') + 1) + lblstartpg.Value);
            if (Request.RawUrl.Contains("/all-"))
            {
                Response.Redirect("all-" + lblbrandname.Text + "-0-" + categoryid + "-" + lblstartpg.Value + "-" + categoryid + "-" + catfilter + "-" + pagesize);
            }
            else
            {
                Response.Redirect("brand-" + lblbrandname.Text.Replace("&", "$").Replace("+", "%20") + "-" + brandid + "-" + lblstartpg.Value + "-" + filter + "-" + brandid + "-" + pagesize);
            }
        }
    }

    public void bindCategories()
    {
        string cat = "";
        string cat2 = "";
        StringBuilder htmlBrands = new StringBuilder();
        StringBuilder htmlFramematerial = new StringBuilder();
        StringBuilder htmlFramecolor = new StringBuilder();
        StringBuilder htmlFramestyle = new StringBuilder();
        StringBuilder htmlCountry = new StringBuilder();
        StringBuilder htmlLensColor = new StringBuilder();
        StringBuilder htmlGender = new StringBuilder();
        //       StringBuilder htmlGender = new StringBuilder();

        try
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Open();

            if (ddlfiltertype.SelectedValue == "2")
            {
                cat = "0";
                cat2 = "2";
            }
            else if (ddlfiltertype.SelectedValue == "1")
            {
                cat = "1";
                cat2 = "0";
            }
            else
            {
                cat = "1";
                cat2 = "2";
            }

            if (hdnsortby.Value != "")
            {
                ddlpgsort.SelectedValue = hdnsortby.Value;
            }

            //DataTable dt = FetchCategoryData(UserID, SalesAgentID, Uflag, cat, cat2);
            DataTable dt = (DataTable)ViewState["dtcategories"];
            DataTable dt2 = (DataTable)ViewState["dtcategories2"];

            //DataTable dt = InlineDataTable("SELECT productcategoryid, categoryname FROM         		 (        		 SELECT bi.productid as newstockid, p.productid, (select top 1 isnull(productid,0) from esun_carttb where userid = " + UserID + " and productid = p.productid)       as IsInCart,        	(case when isnull(convert(varchar,bi.productid),'') <> '' then ' ' else '' end) + 	 		 isnull(p.categoryname,'') + ' ' + isnull(p.productname,'') + ' ' + isnull(p.colorcode,'') + ' ' + isnull(p.psizename,'') as productname,    	  p.categoryname, p.colorname,     p.productname as pname, p.psizename, p.colorcode, 		p.wholesale_price, 		p.productcategoryid, 				 (case when isnull(ap.APrice_3,0) in (0,0.00) then 			case when (catid = 1 or p.brandid = 1) and isnull(convert(decimal(10,2),ad.price),0) not in (0,0.00) then isnull(convert(decimal(10,2),ad.price),0)  				else case when (catid = 2 or p.brandid = 2) and isnull(convert(decimal(10,2),ad.price_eye),0) not in (0,0.00) then isnull(convert(decimal(10,2),ad.price_eye),0) 					else  					case when isnull(p.price_paid,0) in (0,0.00) then isnull(p.price_paid_zero,0) else isnull(p.price_paid,0)	end  					end 				end 	  else ap.APrice_3 end)										 as price_paid,  					(round(cast((case when isnull(MSPRPrice,0)in(0,0.00) then (case when ISNULL(wholesale_price,0)in(0,0.00) then (case when ISNULL(p.BrandID,0) = 1 then isnull(p.price,0) * 1.2 else isnull(p.price,0) * 1.5 end) else (case when ISNULL(p.BrandID,0) = 1 then ISNULL(wholesale_price,0) * 2.2 else ISNULL(wholesale_price,0) * 2.5 end) end) else MSPRPrice end) as decimal(10,2)),-0.5)+0.99)  as price,  case when ISNULL(QtyLocation1,0) + isnull((select sum(ISNULL(quantity,0)) from dbo.orderdetails_Temptb inner join dbo.Orders_tempTb on dbo.orders_Temptb.orderid=dbo.orderdetails_Temptb.OrderID where Orderstatusid in ('37') and dbo.OrderDetails_tempTb.productID=p.ProductID and SuppName in ('1','Store 1','Store1') ),0) > 50  then '50+' else convert(varchar,ISNULL(QtyLocation1,0) + isnull((select sum(ISNULL(quantity,0)) from dbo.orderdetails_Temptb inner join dbo.Orders_tempTb on dbo.orders_Temptb.orderid=dbo.orderdetails_Temptb.OrderID where Orderstatusid in ('37') and dbo.OrderDetails_tempTb.productID=p.ProductID and SuppName in ('1','Store 1','Store1') ),0) )  end  as QtyLocation1 ,ROW_NUMBER() OVER (ORDER BY p.productid DESC  ) AS num ,         		 (select top 1 pic.largeimageurl from dbo.picturestb pic with(nolock) where  pic.productid = p.productid) as MidImageURL                		 from dbo.ProductsTb p with(nolock) 		 Inner Join dbo.OchkeeStockTb o with(nolock) on p.ProductID = o.ProductID                   		left join User_APrice_productwise_esun_new ap with(nolock) on ap.productid = p.ProductID and ap.UserID = " + UserID + " 		left join User_APrice_default_esun_new ad with(nolock) on ad.brandid = p.ProductCategoryID and ad.UserID = " + UserID + "  inner join wholesaleuserstb w on w.wholesaleusersid = " + UserID + "	left join salesAgent_brand_showunshow es with(nolock) on p.productcategoryid = es.abrandid and es.aSalesAgentID = " + SalesAgentID + "  left join (select productid from bk_manufacturer_inv where 1=1  and Dated between dateadd(DAY,-7, GETDATE()) and getdate() group by productid ) bi on bi.productid = p.productid 		 where (case when isnull(es.aID,0) <> 0 then case when '" + Uflag + "' = '1' then case when Level1ToShow like '%" + UserID + "%' then 'show' when Level2ToShow  like '%" + UserID + "%' then 'show' when Level3ToShow like '%" + UserID + "%' then 'show' when Level4ToShow like '%" + UserID + "%' then 'show' else	'unshow' end else case when isnull(Unshowtoagent,0) = 0 then 'show' else 'unshow' end end else 'show' end ) = 'show' and (isnull(p.price_paid,0) <> 0 or isnull(p.price_paid_zero,0) <> 0)  		 and (p.brandID = " + cat + " or p.brandid = " + cat2 + ")   and ((ISNULL(o.QtyLocation1,0) + isnull((select sum(ISNULL(quantity,0)) from dbo.orderdetails_Temptb inner join dbo.Orders_tempTb on dbo.orders_Temptb.orderid=dbo.orderdetails_Temptb.OrderID where Orderstatusid in ('37') and dbo.OrderDetails_tempTb.productID=p.ProductID and SuppName in ('1','Store 1','Store1') ),0) ) > 0 ) 		and ((ISNULL(ad.brandid,0) = p.ProductCategoryID and 0 = (case when isnull(ap.brandid,0) = 0 then 0 else isnull(ap.Status,0) end ) and 1 = (case when isnull(ap.brandid,0) = 0 then 1 else isnull(ap.showbrand,0) end ) ) or (ap.brandid = p.ProductCategoryID and ISNULL(showbrand,0) = 1 and isnull(ap.APrice_3,0) not in (0,0.00)  and ISNULL(Status,0) = 0  ) )	and (case 	when ''  = 'productname' then  convert(varchar(100),p.productname)	when ''  = 'productid' then convert(varchar(100),p.productid)	when ''  = 'UPC' then  convert(varchar(100),upc)else	'1'end) = (case 	when ''  <> '' then ''else	'1'end) )         		 AS A group by categoryname, productcategoryid order by categoryname");

            if (dt.Rows.Count > 0)
            {
                StringBuilder htmlFilter = new StringBuilder();
                DataTable dtfilter;
                if (Session["lcurrentfilter"] != null && Session["lcurrentfilter"].ToString() == "filter")
                {
                    dtfilter = dt2.AsEnumerable()
                        //.GroupBy(r => new { Col5 = r["productcategoryid"], Col6 = r["categoryname"] })
            .GroupBy(r => new { Col6 = r["brandname"].ToString().Trim().ToLower() })
            .OrderBy(g => g.Key.Col6)
            .Select(g =>
            {
                var row = dt2.NewRow();
                //row["categoryname"] = g.Key.Col6;
                row["brandname"] = UppercaseFirst(g.Key.Col6.ToString().ToLower());
                row.SetField("SkuCount", g.Count());

                return row;

            })
            .CopyToDataTable();
                }
                else
                {
                    dtfilter = dt.AsEnumerable()
                        //.GroupBy(r => new { Col5 = r["productcategoryid"], Col6 = r["categoryname"] })
            .GroupBy(r => new { Col6 = r["brandname"].ToString().Trim().ToLower() })
            .OrderBy(g => g.Key.Col6)
            .Select(g =>
            {
                var row = dt.NewRow();
                //row["categoryname"] = g.Key.Col6;
                row["brandname"] = UppercaseFirst(g.Key.Col6.ToString().ToLower());
                row.SetField("SkuCount", g.Count());

                return row;

            })
            .CopyToDataTable();
                }

                if (dtfilter.Rows.Count > 0)
                {
                    for (int i = 0; i < dtfilter.Rows.Count; i++)
                    {
                        htmlFilter.Append("<label for=\"" + dtfilter.Rows[i]["brandname"].ToString().Replace("Eyeglasses", "eyeglass").Replace("Sunglasses", "sunglass") + "\" class=\"label-cbx\">");
                        htmlFilter.Append("<input id=\"" + dtfilter.Rows[i]["brandname"].ToString().Replace("Eyeglasses", "eyeglass").Replace("Sunglasses", "sunglass") + "\" type=\"checkbox\" class=\"cat invisible\" onclick=\"checkFilter()\">");
                        htmlFilter.Append("<div class=\"checkbox\">");
                        htmlFilter.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
                        htmlFilter.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
                        htmlFilter.Append("</div><span>" + dtfilter.Rows[i]["brandname"].ToString() + " (" + dtfilter.Rows[i]["SKUCount"] + ")</span></label>");
                    }
                    ltlFilter.Text = htmlFilter.ToString();
                }

                DataTable dtCategory;
                #region Bind Category list
                if (Session["lcurrentfilter"] != null && Session["lcurrentfilter"].ToString() == "category")
                {
                    dtCategory = dt2.AsEnumerable()
                        //.GroupBy(r => new { Col5 = r["productcategoryid"], Col6 = r["categoryname"] })
                            .GroupBy(r => new { Col5 = r["productcategoryid"], Col6 = r["categoryname"].ToString().Trim().ToLower() })
                            .OrderBy(g => g.Key.Col6)
                            .Select(g =>
                            {
                                var row = dt2.NewRow();

                                row["productcategoryid"] = g.Key.Col5;
                                //row["categoryname"] = g.Key.Col6;
                                row["categoryname"] = UppercaseFirst(g.Key.Col6.ToString().ToLower());
                                row.SetField("SkuCount", g.Count());
                                return row;

                            })
                            .CopyToDataTable();
                }
                else
                {
                    dtCategory = dt.AsEnumerable()
                        //.GroupBy(r => new { Col5 = r["productcategoryid"], Col6 = r["categoryname"] })
                            .GroupBy(r => new { Col5 = r["productcategoryid"], Col6 = r["categoryname"].ToString().Trim().ToLower() })
                            .OrderBy(g => g.Key.Col6)
                            .Select(g =>
                            {
                                var row = dt.NewRow();

                                row["productcategoryid"] = g.Key.Col5;
                                //row["categoryname"] = g.Key.Col6;
                                row["categoryname"] = UppercaseFirst(g.Key.Col6.ToString().ToLower());
                                row.SetField("SkuCount", g.Count());
                                return row;

                            })
                            .CopyToDataTable();
                }

                if (dtCategory.Rows.Count > 0)
                {
                    ddlCategory.DataSource = dtCategory;
                    ddlCategory.DataTextField = dtCategory.Columns[1].ToString();
                    ddlCategory.DataValueField = dtCategory.Columns[0].ToString();
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem(Resources.Resources.ResourceManager.GetString("Pleasechoose1"), "0"));
                    //if (hdncategory.Value == "")
                    //    ddlCategory.SelectedValue = "0";
                    //else
                    //    ddlCategory.SelectedValue = hdncategory.Value;


                    if (dtCategory.Rows.Count > 0)
                    {
                        divcat.Visible = true;
                        ltlBrands.Text = "";
                        htmlBrands.Append("<div class=\"campo-search\" style=\"display:none\"><input type=\"search\" placeholder=\"Search\" ></div>");
                        for (int i = 0; i < dtCategory.Rows.Count; i++)
                        {
                            htmlBrands.Append("<label for=\"" + dtCategory.Rows[i][0].ToString() + "\" class=\"label-cbx\">");
                            htmlBrands.Append("<input id=\"" + dtCategory.Rows[i][0].ToString() + "\" type=\"checkbox\" class=\"brand invisible\" onclick=\"checkCategory()\">");
                            htmlBrands.Append("<div class=\"checkbox\">");
                            htmlBrands.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
                            htmlBrands.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
                            htmlBrands.Append("</div><span>" + dtCategory.Rows[i][1].ToString() + " (" + dtCategory.Rows[i]["SKUCount"] + ")</span></label>");

                        }

                        ltlBrands.Text = htmlBrands.ToString();
                    }
                }
                #endregion

                #region Bind frame material

                DataTable dtframematerial = new DataTable();
                if (Session["lcurrentfilter"] != null && Session["lcurrentfilter"].ToString() == "framematerial")
                {
                    if (brandid == "0")
                    {
                        dtframematerial = dt2.AsEnumerable()
                                         .GroupBy(r => new { Col = r["framematerial"].ToString().Trim().ToLower() })
                                         .OrderBy(g => g.Key.Col)
                                         .Select(g =>
                                         {
                                             var row = dt2.NewRow();
                                             row["framematerial"] = g.Key.Col.ToString().ToLower();
                                             row.SetField("SkuCount", g.Count());
                                             return row;
                                         })
                                         .CopyToDataTable();
                    }
                    else
                    {
                        dtframematerial = dt2.AsEnumerable()
                            //.Where(r => r.Field<string>("categoryname") == categoryname)
                                      .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                      .GroupBy(r => new { Col = r["framematerial"].ToString().Trim().ToLower() })
                                      .OrderBy(g => g.Key.Col)
                                      .Select(g =>
                                      {
                                          var row = dt2.NewRow();
                                          row["framematerial"] = g.Key.Col.ToString().ToLower();
                                          row.SetField("SKUCount", g.Count());
                                          return row;
                                      })
                                      .CopyToDataTable();

                    }
                }
                else
                {
                    if (brandid == "0")
                    {
                        dtframematerial = dt.AsEnumerable()
                                         .GroupBy(r => new { Col = r["framematerial"].ToString().Trim().ToLower() })
                                         .OrderBy(g => g.Key.Col)
                                         .Select(g =>
                                         {
                                             var row = dt.NewRow();
                                             row["framematerial"] = g.Key.Col.ToString().ToLower();
                                             row.SetField("SkuCount", g.Count());
                                             return row;
                                         })
                                         .CopyToDataTable();
                    }
                    else
                    {
                        dtframematerial = dt.AsEnumerable()
                            //.Where(r => r.Field<string>("categoryname") == categoryname)
                                      .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                      .GroupBy(r => new { Col = r["framematerial"].ToString().Trim().ToLower() })
                                      .OrderBy(g => g.Key.Col)
                                      .Select(g =>
                                      {
                                          var row = dt.NewRow();
                                          row["framematerial"] = g.Key.Col.ToString().ToLower();
                                          row.SetField("SKUCount", g.Count());
                                          return row;
                                      })
                                      .CopyToDataTable();

                    }
                }
                if (dtframematerial.Rows.Count > 0)
                {
                    ddlframematerial.DataSource = dtframematerial;
                    ddlframematerial.DataTextField = dtframematerial.Columns[3].ToString();
                    ddlframematerial.DataValueField = dtframematerial.Columns[3].ToString();
                    ddlframematerial.DataBind();

                    if (ddlframematerial.Items.Count > 0)
                    {
                        int itemCount = ddlframematerial.Items.Count;

                        //htmlFramematerial.Append("<ul><li><a href='#0' class='active' onclick='setFrameMaterial(0)'>All</a></li>");
                        for (int i = 0; i < itemCount; i++)
                        {
                            if (ddlframematerial.Items[i].Text != "select")
                            {
                                htmlFramematerial.Append("<label for=\"" + ddlframematerial.Items[i].Text + "\" class=\"label-cbx\">");
                                htmlFramematerial.Append("<input id=\"" + ddlframematerial.Items[i].Text + "\" type=\"checkbox\"  class=\"frame invisible\" onclick=\"checkFramematerial()\">");
                                htmlFramematerial.Append("<div class=\"checkbox\">");
                                htmlFramematerial.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
                                htmlFramematerial.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
                                htmlFramematerial.Append("</div><span>" + UppercaseFirst(ddlframematerial.Items[i].Text) + " (" + dtframematerial.Rows[i]["SKUCount"] + ")</span></label>");
                            }

                        }
                        //htmlFramematerial.Append("</ul>");
                        ltlFramematerial.Text = "" + htmlFramematerial.ToString();
                    }
                }
                if (ltlFramematerial.Text == "")
                {
                    divframematerial.Visible = false;
                }
                #endregion

                #region Bind frame color

                DataTable dtframecolor = new DataTable();
                if (Session["lcurrentfilter"] != null && Session["lcurrentfilter"].ToString() == "framecolor")
                {
                    if (brandid == "0")
                    {
                        dtframecolor = dt2.AsEnumerable()
                                    .GroupBy(r => new { Col = r["colorname"].ToString().Trim().ToLower() })
                                    .OrderBy(g => g.Key.Col)
                                    .Select(g =>
                                    {
                                        var row = dt2.NewRow();
                                        row["colorname"] = g.Key.Col.ToString().ToLower();
                                        row.SetField("SKUCount", g.Count());
                                        return row;
                                    })
                                    .CopyToDataTable();
                    }
                    else
                    {
                        dtframecolor = dt2.AsEnumerable()
                            //.Where(r => r.Field<string>("categoryname") == categoryname)
                                    .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                    .GroupBy(r => new { Col = r["colorname"].ToString().Trim().ToLower() })
                                    .OrderBy(g => g.Key.Col)
                                    .Select(g =>
                                    {
                                        var row = dt2.NewRow();
                                        row["colorname"] = g.Key.Col.ToString().ToLower();
                                        row.SetField("SKUCount", g.Count());
                                        return row;
                                    })
                                    .CopyToDataTable();
                    }
                }
                else
                {
                    if (brandid == "0")
                    {
                        dtframecolor = dt.AsEnumerable()
                                    .GroupBy(r => new { Col = r["colorname"].ToString().Trim().ToLower() })
                                    .OrderBy(g => g.Key.Col)
                                    .Select(g =>
                                    {
                                        var row = dt.NewRow();
                                        row["colorname"] = g.Key.Col.ToString().ToLower();
                                        row.SetField("SKUCount", g.Count());
                                        return row;
                                    })
                                    .CopyToDataTable();
                    }
                    else
                    {
                        dtframecolor = dt.AsEnumerable()
                            //.Where(r => r.Field<string>("categoryname") == categoryname)
                                    .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                    .GroupBy(r => new { Col = r["colorname"].ToString().Trim().ToLower() })
                                    .OrderBy(g => g.Key.Col)
                                    .Select(g =>
                                    {
                                        var row = dt.NewRow();
                                        row["colorname"] = g.Key.Col.ToString().ToLower();
                                        row.SetField("SKUCount", g.Count());
                                        return row;
                                    })
                                    .CopyToDataTable();
                    }
                }
                if (dtframecolor.Rows.Count > 0)
                {

                    ddlframecolor.DataSource = dtframecolor;
                    ddlframecolor.DataTextField = dtframecolor.Columns[4].ToString();
                    ddlframecolor.DataValueField = dtframecolor.Columns[4].ToString();
                    ddlframecolor.DataBind();


                    if (ddlframecolor.Items.Count > 0)
                    {
                        int itemCount = ddlframecolor.Items.Count;

                        //htmlFramematerial.Append("<ul><li><a href='#0' class='active' onclick='setFrameMaterial(0)'>All</a></li>");
                        for (int i = 0; i < itemCount; i++)
                        {
                            if (ddlframecolor.Items[i].Text != "select" && ddlframecolor.Items[i].Text != "")
                            {
                                htmlFramecolor.Append("<label for=\"" + ddlframecolor.Items[i].Text + "\" class=\"label-cbx\">");
                                htmlFramecolor.Append("<input id=\"" + ddlframecolor.Items[i].Text + "\" type=\"checkbox\"  class=\"framec invisible\" onclick=\"checkFrameColor()\">");
                                htmlFramecolor.Append("<div class=\"checkbox\">");
                                htmlFramecolor.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
                                htmlFramecolor.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
                                htmlFramecolor.Append("</div><span>" + UppercaseFirst(ddlframecolor.Items[i].Text) + " (" + dtframecolor.Rows[i]["SKUCount"] + ")</span></label>");
                            }

                        }
                        //htmlFramematerial.Append("</ul>");
                        ltlFramecolor.Text = htmlFramecolor.ToString();
                    }

                }
                if (ltlFramecolor.Text == "")
                {
                    divframecolor.Visible = false;
                }
                #endregion

                #region Bind lens color

                DataTable dtlenscolor = new DataTable();
                if (Session["lcurrentfilter"] != null && Session["lcurrentfilter"].ToString() == "lenscolor")
                {
                    if (brandid == "0")
                    {
                        dtlenscolor = dt2.AsEnumerable()
                                    .GroupBy(r => new { Col = r["lenscolor"].ToString().Trim().ToLower() })
                                    .OrderBy(g => g.Key.Col)
                                    .Select(g =>
                                    {
                                        var row = dt2.NewRow();
                                        row["lenscolor"] = g.Key.Col.ToString().ToLower();
                                        row.SetField("SKUCount", g.Count());
                                        return row;
                                    })
                                    .CopyToDataTable();
                    }
                    else
                    {
                        dtlenscolor = dt2.AsEnumerable()
                            //.Where(r => r.Field<string>("categoryname") == categoryname)
                                    .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                    .GroupBy(r => new { Col = r["lenscolor"].ToString().Trim().ToLower() })
                                    .OrderBy(g => g.Key.Col)
                                    .Select(g =>
                                    {
                                        var row = dt2.NewRow();
                                        row["lenscolor"] = g.Key.Col.ToString().ToLower();
                                        row.SetField("SKUCount", g.Count());
                                        return row;
                                    })
                                    .CopyToDataTable();
                    }
                }
                else
                {
                    if (brandid == "0")
                    {
                        dtlenscolor = dt.AsEnumerable()
                                    .GroupBy(r => new { Col = r["lenscolor"].ToString().Trim().ToLower() })
                                    .OrderBy(g => g.Key.Col)
                                    .Select(g =>
                                    {
                                        var row = dt.NewRow();
                                        row["lenscolor"] = g.Key.Col.ToString().ToLower();
                                        row.SetField("SKUCount", g.Count());
                                        return row;
                                    })
                                    .CopyToDataTable();
                    }
                    else
                    {
                        dtlenscolor = dt.AsEnumerable()
                            //.Where(r => r.Field<string>("categoryname") == categoryname)
                                    .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                    .GroupBy(r => new { Col = r["lenscolor"].ToString().Trim().ToLower() })
                                    .OrderBy(g => g.Key.Col)
                                    .Select(g =>
                                    {
                                        var row = dt.NewRow();
                                        row["lenscolor"] = g.Key.Col.ToString().ToLower();
                                        row.SetField("SKUCount", g.Count());
                                        return row;
                                    })
                                    .CopyToDataTable();
                    }
                }
                if (dtlenscolor.Rows.Count > 0)
                {

                    ddllenscolor.DataSource = dtlenscolor;
                    ddllenscolor.DataTextField = dtlenscolor.Columns[2].ToString();
                    ddllenscolor.DataValueField = dtlenscolor.Columns[2].ToString();
                    ddllenscolor.DataBind();


                    if (ddllenscolor.Items.Count > 0)
                    {
                        int itemCount = ddllenscolor.Items.Count;

                        //htmlFramematerial.Append("<ul><li><a href='#0' class='active' onclick='setFrameMaterial(0)'>All</a></li>");
                        for (int i = 0; i < itemCount; i++)
                        {
                            if (ddllenscolor.Items[i].Text != "select" && ddllenscolor.Items[i].Text != "")
                            {
                                htmlLensColor.Append("<label for=\"l_" + ddllenscolor.Items[i].Text + "\" class=\"label-cbx\">");
                                htmlLensColor.Append("<input id=\"l_" + ddllenscolor.Items[i].Text + "\" type=\"checkbox\"  class=\"lens invisible\" onclick=\"checkLensColor()\">");
                                htmlLensColor.Append("<div class=\"checkbox\">");
                                htmlLensColor.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
                                htmlLensColor.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
                                htmlLensColor.Append("</div><span>" + UppercaseFirst(ddllenscolor.Items[i].Text) + " (" + dtlenscolor.Rows[i]["SKUCount"] + ")</span></label>");
                            }

                        }
                        //htmlFramematerial.Append("</ul>");
                        ltllenscolor.Text = htmlLensColor.ToString();
                    }
                    //  divframecolor.Visible = false;

                }
                if (ltllenscolor.Text == "")
                {
                    divlenscolor.Visible = false;
                }
                #endregion

                #region Bind frame Style

                DataTable dtframemstyle = new DataTable();
                if (Session["lcurrentfilter"] != null && Session["lcurrentfilter"].ToString() == "framestyle")
                {
                    if (brandid == "0")
                    {
                        dtframemstyle = dt2.AsEnumerable()
                                    .GroupBy(r => new { Col = r["productstyle"].ToString().Trim().ToLower() })
                                    .OrderBy(g => g.Key.Col)
                                    .Select(g =>
                                    {
                                        var row = dt2.NewRow();
                                        row["productstyle"] = g.Key.Col.ToString();
                                        row.SetField("SKUCount", g.Count());
                                        return row;
                                    })
                                    .CopyToDataTable();
                    }
                    else
                    {
                        dtframemstyle = dt2.AsEnumerable()
                                    .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                     .GroupBy(r => new { Col = r["productstyle"].ToString().Trim().ToLower() })
                                     .OrderBy(g => g.Key.Col)
                                     .Select(g =>
                                     {
                                         var row = dt2.NewRow();
                                         row["productstyle"] = g.Key.Col.ToString();
                                         row.SetField("SKUCount", g.Count());
                                         return row;
                                     })
                                     .CopyToDataTable();
                    }
                }
                else
                {
                    if (brandid == "0")
                    {
                        dtframemstyle = dt.AsEnumerable()
                                    .GroupBy(r => new { Col = r["productstyle"].ToString().Trim().ToLower() })
                                    .OrderBy(g => g.Key.Col)
                                    .Select(g =>
                                    {
                                        var row = dt.NewRow();
                                        row["productstyle"] = g.Key.Col.ToString();
                                        row.SetField("SKUCount", g.Count());
                                        return row;
                                    })
                                    .CopyToDataTable();
                    }
                    else
                    {
                        dtframemstyle = dt.AsEnumerable()
                                    .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                     .GroupBy(r => new { Col = r["productstyle"].ToString().Trim().ToLower() })
                                     .OrderBy(g => g.Key.Col)
                                     .Select(g =>
                                     {
                                         var row = dt.NewRow();
                                         row["productstyle"] = g.Key.Col.ToString();
                                         row.SetField("SKUCount", g.Count());
                                         return row;
                                     })
                                     .CopyToDataTable();
                    }
                }
                if (dtframemstyle.Rows.Count > 0)
                {
                    ddlframestyle.DataSource = dtframemstyle;
                    ddlframestyle.DataTextField = dtframemstyle.Columns[5].ToString();
                    ddlframestyle.DataValueField = dtframemstyle.Columns[5].ToString();
                    ddlframestyle.DataBind();

                    if (ddlframestyle.Items.Count > 0)
                    {
                        int itemCount = ddlframestyle.Items.Count;

                        //htmlFramestyle.Append("<ul><li><a href='#0' class='active' onclick='setFrameStyle(0)'>All</a></li>");
                        for (int i = 0; i < itemCount; i++)
                        {
                            if (ddlframestyle.Items[i].Text != "select")
                            {
                                htmlFramestyle.Append("<label for=\"" + ddlframestyle.Items[i].Text + "\" class=\"label-cbx\">");
                                htmlFramestyle.Append("<input id=\"" + ddlframestyle.Items[i].Text + "\" type=\"checkbox\"  class=\"fstyle invisible\" onclick=\"checkFramestyle()\">");
                                htmlFramestyle.Append("<div class=\"checkbox\">");
                                htmlFramestyle.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
                                htmlFramestyle.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
                                htmlFramestyle.Append("</div><span>" + UppercaseFirst(ddlframestyle.Items[i].Text) + " (" + dtframemstyle.Rows[i]["SKUCount"] + ")</span></label>");
                            }

                        }
                        //htmlFramestyle.Append("</ul>");
                        ltlFramestyle.Text = htmlFramestyle.ToString();
                    }
                }
                if (ltlFramestyle.Text == "")
                {
                    divFramestyle.Visible = false;
                }
                #endregion

                #region Bind Country

                DataTable dtCountry = new DataTable();
                if (Session["lcurrentfilter"] != null && Session["lcurrentfilter"].ToString() == "country")
                {
                    if (brandid == "0")
                    {
                        dtCountry = dt2.AsEnumerable()
                                     .GroupBy(r => new { Col = r["pcountry"].ToString().Trim().ToLower() })
                                     .OrderBy(g => g.Key.Col)
                                     .Select(g =>
                                     {
                                         var row = dt2.NewRow();
                                         row["pcountry"] = g.Key.Col.ToString();
                                         row.SetField("SKUCount", g.Count());
                                         return row;
                                     })
                                     .CopyToDataTable();
                    }
                    else
                    {
                        dtCountry = dt2.AsEnumerable()
                                  .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                   .GroupBy(r => new { Col = r["pcountry"].ToString().Trim().ToLower() })
                                   .OrderBy(g => g.Key.Col)
                                   .Select(g =>
                                   {
                                       var row = dt2.NewRow();
                                       row["pcountry"] = g.Key.Col.ToString();
                                       row.SetField("SKUCount", g.Count());
                                       return row;
                                   })
                                   .CopyToDataTable();
                    }
                }
                else
                {
                    if (brandid == "0")
                    {
                        dtCountry = dt.AsEnumerable()
                                     .GroupBy(r => new { Col = r["pcountry"].ToString().Trim().ToLower() })
                                     .OrderBy(g => g.Key.Col)
                                     .Select(g =>
                                     {
                                         var row = dt.NewRow();
                                         row["pcountry"] = g.Key.Col.ToString();
                                         row.SetField("SKUCount", g.Count());
                                         return row;
                                     })
                                     .CopyToDataTable();
                    }
                    else
                    {
                        dtCountry = dt.AsEnumerable()
                                  .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                   .GroupBy(r => new { Col = r["pcountry"].ToString().Trim().ToLower() })
                                   .OrderBy(g => g.Key.Col)
                                   .Select(g =>
                                   {
                                       var row = dt.NewRow();
                                       row["pcountry"] = g.Key.Col.ToString();
                                       row.SetField("SKUCount", g.Count());
                                       return row;
                                   })
                                   .CopyToDataTable();
                    }
                }

                if (dtCountry.Rows.Count > 0)
                {
                    ddlCountry.DataSource = dtCountry;
                    ddlCountry.DataTextField = dtCountry.Columns[6].ToString();
                    ddlCountry.DataValueField = dtCountry.Columns[6].ToString();
                    ddlCountry.DataBind();

                    if (ddlCountry.Items.Count > 0)
                    {
                        int itemCount = ddlCountry.Items.Count;


                        for (int i = 0; i < itemCount; i++)
                        {
                            if (ddlCountry.Items[i].Text != "select")
                            {
                                htmlCountry.Append("<label for=\"" + ddlCountry.Items[i].Text + "\" class=\"label-cbx\">");
                                htmlCountry.Append("<input id=\"" + ddlCountry.Items[i].Text + "\" type=\"checkbox\"  class=\"country invisible\" onclick=\"checkCountry()\">");
                                htmlCountry.Append("<div class=\"checkbox\">");
                                htmlCountry.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
                                htmlCountry.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
                                htmlCountry.Append("</div><span>" + UppercaseFirst(ddlCountry.Items[i].Text) + " (" + dtCountry.Rows[i]["SKUCount"] + ")</span></label>");
                            }
                        }

                        ltlCountry.Text = htmlCountry.ToString();
                    }
                }
                if (ltlCountry.Text == "")
                {
                    divcountry.Visible = false;
                }
                #endregion

                #region Bind Gender

                DataTable dtGender = new DataTable();
                if (Session["lcurrentfilter"] != null && Session["lcurrentfilter"].ToString() == "gender")
                {
                    if (brandid == "0")
                    {
                        dtGender = dt2.AsEnumerable()
                                     .GroupBy(r => new { Col = r["gender"].ToString().Trim().ToLower() })
                                     .OrderBy(g => g.Key.Col)
                                     .Select(g =>
                                     {
                                         var row = dt2.NewRow();
                                         row["gender"] = g.Key.Col.ToString();
                                         row.SetField("SKUCount", g.Count());
                                         return row;
                                     })
                                     .CopyToDataTable();
                    }
                    else
                    {
                        dtGender = dt2.AsEnumerable()
                                   .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                   .GroupBy(r => new { Col = r["gender"].ToString().Trim().ToLower() })
                                   .OrderBy(g => g.Key.Col)
                                   .Select(g =>
                                   {
                                       var row = dt2.NewRow();
                                       row["gender"] = g.Key.Col.ToString();
                                       row.SetField("SKUCount", g.Count());
                                       return row;
                                   })
                                   .CopyToDataTable();
                    }
                }
                else
                {
                    if (brandid == "0")
                    {
                        dtGender = dt.AsEnumerable()
                                     .GroupBy(r => new { Col = r["gender"].ToString().Trim().ToLower() })
                                     .OrderBy(g => g.Key.Col)
                                     .Select(g =>
                                     {
                                         var row = dt.NewRow();
                                         row["gender"] = g.Key.Col.ToString();
                                         row.SetField("SKUCount", g.Count());
                                         return row;
                                     })
                                     .CopyToDataTable();
                    }
                    else
                    {
                        dtGender = dt.AsEnumerable()
                                   .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                   .GroupBy(r => new { Col = r["gender"].ToString().Trim().ToLower() })
                                   .OrderBy(g => g.Key.Col)
                                   .Select(g =>
                                   {
                                       var row = dt.NewRow();
                                       row["gender"] = g.Key.Col.ToString();
                                       row.SetField("SKUCount", g.Count());
                                       return row;
                                   })
                                   .CopyToDataTable();
                    }
                }

                if (dtGender.Rows.Count > 0)
                {
                    ddlGender.DataSource = dtGender;
                    ddlGender.DataTextField = dtGender.Columns[7].ToString();
                    ddlGender.DataValueField = dtGender.Columns[7].ToString();
                    ddlGender.DataBind();

                    if (ddlGender.Items.Count > 0)
                    {
                        int itemCount = ddlGender.Items.Count;


                        for (int i = 0; i < itemCount; i++)
                        {
                            if (ddlGender.Items[i].Text != "select")
                            {
                                htmlGender.Append("<label for=\"" + ddlGender.Items[i].Text + "\" class=\"label-cbx\">");
                                htmlGender.Append("<input id=\"" + ddlGender.Items[i].Text + "\" type=\"checkbox\"  class=\"gender invisible\" onclick=\"checkGender()\">");
                                htmlGender.Append("<div class=\"checkbox\">");
                                htmlGender.Append("<svg width=\"20px\" height=\"20px\" viewBox=\"0 0 20 20\">");
                                htmlGender.Append("<path d=\"M3,1 L17,1 L17,1 C18.1045695,1 19,1.8954305 19,3 L19,17 L19,17 C19,18.1045695 18.1045695,19 17,19 L3,19 L3,19 C1.8954305,19 1,18.1045695 1,17 L1,3 L1,3 C1,1.8954305 1.8954305,1 3,1 Z\"></path><polyline points=\"4 11 8 15 16 6\"></polyline></svg>");
                                htmlGender.Append("</div><span>" + UppercaseFirst(ddlGender.Items[i].Text) + " (" + dtGender.Rows[i]["SKUCount"] + ")</span></label>");
                            }
                        }

                        ltlGender.Text = htmlGender.ToString();
                    }
                }
                if (ltlGender.Text == "")
                {
                    divGender.Visible = false;
                }

                #endregion

                #region Bind Eyesize

                DataTable dtEyesize = new DataTable();
                if (Session["lcurrentfilter"] != null && Session["lcurrentfilter"].ToString() == "eyesize")
                {
                    if (brandid == "0")
                    {
                        dtEyesize = dt2.AsEnumerable()
                                     .GroupBy(r => new { Col = r["eye"].ToString().Trim().ToLower() })
                                     .OrderBy(g => g.Key.Col)
                                     .Select(g =>
                                     {
                                         var row = dt2.NewRow();
                                         row["eye"] = g.Key.Col.ToString();
                                         row.SetField("SKUCount", g.Count());
                                         return row;
                                     })
                                     .CopyToDataTable();
                    }
                    else
                    {
                        dtEyesize = dt2.AsEnumerable()
                                   .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                   .GroupBy(r => new { Col = r["eye"].ToString().Trim().ToLower() })
                                   .OrderBy(g => g.Key.Col)
                                   .Select(g =>
                                   {
                                       var row = dt2.NewRow();
                                       row["eye"] = g.Key.Col.ToString();
                                       row.SetField("SKUCount", g.Count());
                                       return row;
                                   })
                                   .CopyToDataTable();
                    }
                }
                else
                {
                    if (brandid == "0")
                    {
                        dtEyesize = dt.AsEnumerable()
                                     .GroupBy(r => new { Col = r["eye"].ToString().Trim().ToLower() })
                                     .OrderBy(g => g.Key.Col)
                                     .Select(g =>
                                     {
                                         var row = dt.NewRow();
                                         row["eye"] = g.Key.Col.ToString();
                                         row.SetField("SKUCount", g.Count());
                                         return row;
                                     })
                                     .CopyToDataTable();
                    }
                    else
                    {
                        dtEyesize = dt.AsEnumerable()
                                   .Where(r => r.Field<decimal>("productcategoryid") == Convert.ToDecimal(brandid))
                                   .GroupBy(r => new { Col = r["eye"].ToString().Trim().ToLower() })
                                   .OrderBy(g => g.Key.Col)
                                   .Select(g =>
                                   {
                                       var row = dt.NewRow();
                                       row["eye"] = g.Key.Col.ToString();
                                       row.SetField("SKUCount", g.Count());
                                       return row;
                                   })
                                   .CopyToDataTable();
                    }
                }

                if (dtEyesize.Rows.Count > 0)
                {
                    ddleyesize.DataSource = dtEyesize;
                    ddleyesize.DataTextField = dtEyesize.Columns[8].ToString();
                    ddleyesize.DataValueField = dtEyesize.Columns[8].ToString();
                    ddleyesize.DataBind();
                    ddleyesize.Items.Insert(0, new ListItem("Select", "0"));

                    if (ddleyesize.Items.Count > 0)
                    {
                        // divEyesize.Visible = false;
                    }
                    else
                    {
                        divEyesize.Visible = false;
                    }
                }
                #endregion

                StringBuilder flt = new StringBuilder();
                if ((Session["lsesCategory"] != null && Session["lsesCategory"].ToString() != "") && (Session["lsesCategoryname"] != null && Session["lsesCategoryname"].ToString() != ""))
                { //26,4
                    string[] carr = Session["lsesCategoryname"].ToString().Split(',');
                    string[] carrid = Session["lsesCategory"].ToString().Split(',');

                    string ct = "";
                    for (int ci = 0; ci < carr.Length; ci++)
                    {
                        ct = ct + "<div id=\"c" + ci + "\" class=\"filters-prod\"><a href=\"javascript:void(0)\" onclick=\"removefilter('" + carrid[ci] + "','checkbox',''); checkCategory(); doapplyclick('#0','c" + ci + "');\">" + carr[ci] + "</a></div>";
                    }
                    flt.Append(ct);
                }

                if (Session["lsesFilter"] != null && Session["lsesFilter"].ToString() != "" && ppage != "sun" && ppage != "eye")
                { //26,4
                    string[] carr = Session["lsesFilter"].ToString().Replace("1", "sunglass").Replace("2", "eyeglass").Split(',');
                    string ct = "";
                    for (int ci = 0; ci < carr.Length; ci++)
                    {
                        ct = ct + "<div id=\"f" + ci + "\" class=\"filters-prod\"><a href=\"javascript:void(0)\" onclick=\"removefilter('" + carr[ci] + "','checkbox',''); checkFilter(); doapplyclick('#0','f" + ci + "');\">" + carr[ci] + "es</a></div>";
                    }
                    flt.Append(ct);
                }

                if (Session["lsesFramematerial"] != null && Session["lsesFramematerial"].ToString() != "")
                { //26,4
                    string[] carr = Session["lsesFramematerial"].ToString().Split(',');
                    string ct = "";
                    for (int ci = 0; ci < carr.Length; ci++)
                    {
                        ct = ct + "<div id=\"fm" + ci + "\" class=\"filters-prod\"><a href=\"javascript:void(0)\" onclick=\"removefilter('" + carr[ci] + "','checkbox','');checkFramematerial();doapplyclick('#0','fm" + ci + "');\">" + carr[ci] + "</a></div>";
                    }
                    flt.Append(ct);
                }

                if (Session["lsesFramestyle"] != null && Session["lsesFramestyle"].ToString() != "")
                { //26,4
                    string[] carr = Session["lsesFramestyle"].ToString().Split(',');
                    string ct = "";
                    for (int ci = 0; ci < carr.Length; ci++)
                    {
                        ct = ct + "<div id=\"fs" + ci + "\" class=\"filters-prod\"><a href=\"javascript:void(0)\" onclick=\"removefilter('" + carr[ci] + "','checkbox','');checkFramestyle();doapplyclick('#0','fs" + ci + "')\">" + carr[ci] + "</a></div>";
                    }
                    flt.Append(ct);
                }

                if (Session["lsesCountry"] != null && Session["lsesCountry"].ToString() != "")
                { //26,4
                    string[] carr = Session["lsesCountry"].ToString().Split(',');
                    string ct = "";
                    for (int ci = 0; ci < carr.Length; ci++)
                    {
                        ct = ct + "<div id=\"c" + ci + "\" class=\"filters-prod\"><a href=\"javascript:void(0)\" onclick=\"removefilter('" + carr[ci] + "','checkbox','');checkCountry();doapplyclick('#0','c" + ci + "');\">" + carr[ci] + "</a></div>";
                    }
                    flt.Append(ct);
                }

                if (Session["lsesFramecolor"] != null && Session["lsesFramecolor"].ToString() != "")
                { //26,4
                    string[] carr = Session["lsesFramecolor"].ToString().Split(',');
                    string ct = "";
                    for (int ci = 0; ci < carr.Length; ci++)
                    {
                        ct = ct + "<div id=\"fc" + ci + "\" class=\"filters-prod\"><a href=\"javascript:void(0)\" onclick=\"removefilter('" + carr[ci] + "','checkbox',''); checkFrameColor(); doapplyclick('#0','fc" + ci + "');\">" + carr[ci] + "</a></div>";
                    }
                    flt.Append(ct);
                }

                if (Session["lseslenscolor"] != null && Session["lseslenscolor"].ToString() != "")
                { //26,4
                    string[] carr = Session["lseslenscolor"].ToString().Split(',');
                    string ct = "";
                    for (int ci = 0; ci < carr.Length; ci++)
                    {
                        ct = ct + "<div id=\"lc" + ci + "\" class=\"filters-prod\"><a href=\"javascript:void(0)\" onclick=\"removefilter('" + carr[ci] + "','checkbox','');checkLensColor();doapplyclick('#0','lc" + ci + "');\">" + carr[ci] + "</a></div>";
                    }
                    flt.Append(ct);
                }

                if (Session["lsesGender"] != null && Session["lsesGender"].ToString() != "")
                { //26,4
                    string[] carr = Session["lsesGender"].ToString().Split(',');
                    string ct = "";
                    for (int ci = 0; ci < carr.Length; ci++)
                    {
                        ct = ct + "<div id=\"g" + ci + "\" class=\"filters-prod\"><a href=\"javascript:void(0)\" onclick=\"removefilter('" + carr[ci] + "','checkbox','');checkGender();doapplyclick('#0','g" + ci + "');\">" + carr[ci].Replace("l_", "") + "</a></div>";
                    }
                    flt.Append(ct);
                }

                if (Session["lseseyesize"] != null && Session["lseseyesize"].ToString() != "" && Session["lseseyesize"].ToString() != "0")
                { //26,4
                    string[] carr = Session["lseseyesize"].ToString().Split(',');
                    string ct = "";
                    for (int ci = 0; ci < carr.Length; ci++)
                    {
                        ct = ct + "<div id=\"eye" + ci + "\" class=\"filters-prod\"><a href=\"javascript:void(0)\" onclick=\"removefilter('" + carr[ci] + "','dropdown','');checkeyesize();doapplyclick('#0','eye" + ci + "');\">Eye:" + carr[ci] + "</a></div>";
                    }
                    flt.Append(ct);
                }

                if (((Session["lsesCategory"] != null && Session["lsesCategory"].ToString() != "") && (Session["lsesCategoryname"] != null && Session["lsesCategoryname"].ToString() != "")) || (Session["lsesFilter"] != null && Session["lsesFilter"].ToString() != "" && ppage != "sun" && ppage != "eye") || (Session["lsesFramematerial"] != null && Session["lsesFramematerial"].ToString() != "") || (Session["lsesFramestyle"] != null && Session["lsesFramestyle"].ToString() != "") || (Session["lsesCountry"] != null && Session["lsesCountry"].ToString() != "") || (Session["lsesFramecolor"] != null && Session["lsesFramecolor"].ToString() != "") || (Session["lseslenscolor"] != null && Session["lseslenscolor"].ToString() != "") || (Session["lsesGender"] != null && Session["lsesGender"].ToString() != "") || (Session["lseseyesize"] != null && Session["lseseyesize"].ToString() != "" && Session["lseseyesize"].ToString() != "0"))
                {
                    string ct = "";
                    ct = ct + "<div id=\"all0\" class=\"filters-prod\"><a href=\"javascript:void(0)\" onclick=\"checkallclear();\">Clear all</a></div>";
                    flt.Append(ct);
                }


                ltlfilters.Text = "<div class=\"list-advanced-search\">" + flt.ToString() + "</div>";
            }
        }
        catch (Exception ex)
        {
            //    throw; 
        }

        finally
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
    }


    public string getSearchCriteria(string userid)
    {
        string criteria = "";
        try
        {
            //Conn.Open();
            DataTable dt = InlineDataTable("select top 1 searchcriteria from SearchCriteriaLog where wholesaleuserid= " + UserID + " order by logDate desc");
            if (dt.Rows.Count > 0)
            {
                criteria = dt.Rows[0]["searchcriteria"].ToString();
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
        return criteria;
    }

    public void findclick()
    {
        string brand = "";
        string category = "";
        string search = "";
       

        brand = hdnfilter.Value == "" ? categoryid : hdnfilter.Value;
     
        category = hdncategory.Value == "" ? brandid : hdncategory.Value;
     

        pgsize();

       ////if (ddlpgopt.SelectedValue == "")
       //// {
       ////     ddlpgopt.SelectedValue = "1";
       ////     lblstartpg.Text = "1";

       ////   //  lblstartpg1.Text = "1";
       //// }
       //// else
       //// {
       ////     lblstartpg.Text = ddlpgopt.SelectedValue;
       ////  //   lblstartpgb.Text = ddlpgopt.SelectedValue;
       //// }


   //    lblstartpg1.Text = (PageNumber + 1).ToString();

        int PGC = 0;
        ////if (ddlpgopt.SelectedValue != "")
        ////{
        ////    if (Convert.ToInt32(ddlpgopt.SelectedValue) > 1) { PGC = (Convert.ToInt32(ddlpgopt.SelectedValue) * pagesize - (pagesize)); }
        ////}
        
        //lblstartpg.Value = Session["startpage"]!= null ? Session["startpage"].ToString() : "1";

        PGC = (Convert.ToInt32(lblstartpg.Value) * pagesize - (pagesize));

        //if (PageNumber > 0)
        //{
        //    PGC = (PageNumber * pagesize - (pagesize)); 
        //}

        //if(hdnMinValue.Value=="")
        minVal = hdnMinValue.Value ==""? "0": hdnMinValue.Value ;
        maxVal = hdnMaxValue.Value == "" ? "996" : hdnMaxValue.Value;
        framematerial = hdnFrameMaterial.Value == "0" ? "" : hdnFrameMaterial.Value;
        framestyle = hdnFrameStyle.Value == "0" ? "" : hdnFrameStyle.Value;
        country = hdnCountry.Value == "0" ? "" : hdnCountry.Value;
        gender = hdnGender.Value == "0" ? "" : hdnGender.Value;
        framecolor = hdnFrameColor.Value == "0" ? "" : hdnFrameColor.Value;
        lenscolor = hdnlenscolor.Value == "0" ? "" : hdnlenscolor.Value;
        eyesize = hdneyesize.Value == "0" ? "" : hdneyesize.Value;

        if (lenscolor != "")
        {
            lenscolor = lenscolor.Replace("l_", "");
        }

        DataSet ds = FetchProducts(PGC, brand, category, "", "categoryname,pname,colorname", minVal, maxVal, framematerial, framestyle, country, gender, framecolor, lenscolor, eyesize);

        try
        {
            lblitemcount.Text = "<i>(" + ds.Tables[0].Rows[0]["totalcount"].ToString() + ")</i>";
            lblitemcount1.Text = "" + ds.Tables[0].Rows[0]["totalcount"].ToString() + "";
            lblitemcount2.Text = "<i>(" + ds.Tables[0].Rows[0]["totalcount"].ToString() + ")</i>";

            if (Request.RawUrl.Contains("/all-") == true && (hdnfilter.Value == "0" || hdnfilter.Value == ""))
            {
                searchcriteria = "(" + Request.QueryString["c"] + ")|(" + hdncategory.Value + ")|(" + hdnFrameMaterial.Value + ")|(" + hdnFrameColor.Value + ")|(" + hdnlenscolor.Value + ")|(" + hdnFrameStyle.Value + ")|(" + hdnCountry.Value + ")|(" + hdnGender.Value + ")||(" + hdnPrice.Value + ")";
            }
            else 
            {
                searchcriteria = "(" + hdnfilter.Value + ")|(" + hdncategory.Value + ")|(" + hdnFrameMaterial.Value + ")|(" + hdnFrameColor.Value + ")|(" + hdnlenscolor.Value + ")|(" + hdnFrameStyle.Value + ")|(" + hdnCountry.Value + ")|(" + hdnGender.Value + ")||(" + hdnPrice.Value + ")";
            }

        }
        catch { }
        bindProductGrid(ds.Tables[1], false);
        bindRecommendGrid(ds.Tables[4]);
        ViewState["dtcategories"] = ds.Tables[2];
        ViewState["dtcategories2"] = ds.Tables[3];

        Session["IsViewAll"] = "yes";
    }

    public void bindRecommendGrid(DataTable dt)
    {
        StringBuilder str = new StringBuilder();
        str.Append("");
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str.Append("<div class=\"swiper-slide\">                                                            <div class=\"other-item\">                                 <figure>                                    <a href=\"javascript:void(0)\" id=\"" + dt.Rows[i]["productid"].ToString() + "\" onclick=\"gotoproductpage(" + dt.Rows[i]["productid"].ToString() + ");\" style=\"color:black;\">                                       <img src=\"" + dt.Rows[i]["MidImageURL"].ToString() + "\" alt=\"product-image\" height=\"183\">                                    </a>                                 </figure>                                 <div class=\"text-others-p\">                                    <span class=\"brands\">" + dt.Rows[i]["Categoryname"].ToString() + "</span>                                     <a href=\"javascript:void(0)\" id=\"A1\" onclick=\"gotoproductpage(" + dt.Rows[i]["productid"].ToString() + ");\" style=\"color:black;\"><h3>" + dt.Rows[i]["pname"].ToString() + "</h3></a>                                    <ul class=\"description\">                                       <li><em>" + dt.Rows[i]["colorname"].ToString() + "</em></li>                                       <li><span>Color Code :  " + dt.Rows[i]["colorcode"].ToString() + "</li>                                       <li>Size : " + dt.Rows[i]["psizename"].ToString() + "</li>                                                <li>UPC : " + dt.Rows[i]["UPC"].ToString() + "</li>                                    </ul>                                 </div>                              </div>                           </div>");
            }
            ltlrecommend.Text = str.ToString();
        }
    }


    public DataTable FetchCategoryData(string uId,string salesAgentid,string uFlag, string cat1, string cat2, string brandid)
    {
        try
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Open();

            SqlCommand cmd1 = new SqlCommand("[es_ws_getProductsDetails_nywd_eye]", Conn);

            cmd1.CommandType = CommandType.StoredProcedure;

            cmd1.Parameters.AddWithValue("@UserID", uId);
            cmd1.Parameters.AddWithValue("@SalesAgentID", salesAgentid);
            cmd1.Parameters.AddWithValue("@Uflag", Uflag);
            cmd1.Parameters.AddWithValue("@cat1", cat1);
            cmd1.Parameters.AddWithValue("@cat2", cat2);
            cmd1.Parameters.AddWithValue("@brandid", brandid);          
            
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds, "table");
            return ds.Tables[0];
        }

        catch (Exception ex)
        { throw; }

        finally
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
    }

    public DataSet FetchProducts(int startrow, string brand, string category, string searchText, string SortOrder, string minPrice, string maxPrice, string framematerial, string framestyle, string country, string gender, string framecolor, string lenscolor, string eyesize)
    {
        try
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Open();

            SqlCommand cmd1 = new SqlCommand("[es_ws_getProducts_temp_new_nywd_pref_size]", Conn);

            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandTimeout = 120;
            cmd1.Parameters.AddWithValue("@search", Convert.ToString(searchText));
            //int brand = 0; if (ddlBrand.SelectedValue != "") { brand = Convert.ToInt32(ddlBrand.SelectedValue); }
            //int category = 0; if (ddlCategory.SelectedValue != "") { category = Convert.ToInt32(ddlCategory.SelectedValue); }
            cmd1.Parameters.AddWithValue("@brandid", brand);
            cmd1.Parameters.AddWithValue("@catid", category);
            cmd1.Parameters.AddWithValue("@startrow", startrow);
            cmd1.Parameters.AddWithValue("@UserID", UserID);
            //        cmd1.Parameters.AddWithValue("@UserID", 189);
            cmd1.Parameters.AddWithValue("@SortOrder", SortOrder);
            cmd1.Parameters.AddWithValue("@AddOnPrice", 0);
            cmd1.Parameters.AddWithValue("@keytype", "");
            cmd1.Parameters.AddWithValue("@PageSize", pagesize);
            cmd1.Parameters.AddWithValue("@flag", Uflag);
            cmd1.Parameters.AddWithValue("@minPrice", minPrice);
            cmd1.Parameters.AddWithValue("@maxPrice", maxPrice);
            cmd1.Parameters.AddWithValue("@framematerial", framematerial);
            cmd1.Parameters.AddWithValue("@framestyle", framestyle);
            cmd1.Parameters.AddWithValue("@framecolor", framecolor);
            cmd1.Parameters.AddWithValue("@lenscolor", lenscolor);
            cmd1.Parameters.AddWithValue("@country", country);
            cmd1.Parameters.AddWithValue("@gender", gender);
            cmd1.Parameters.AddWithValue("@eyesize", eyesize);
            cmd1.Parameters.AddWithValue("@sortby", hdnsortby.Value);
            cmd1.Parameters.AddWithValue("@currentfilter", currentfilter.Value);
            cmd1.Parameters.AddWithValue("@page", ppage);

            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds, "table");
            return ds;
        }

        catch (Exception ex)
        { throw; }

        finally
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }
    }



    public void pgsize()
    {
        if (hdnpgsize.Value != "")
        {
            //  Write_Cookie("pgsize", Request.QueryString["pgsize"]);
            pagesize = Convert.ToInt32(hdnpgsize.Value);
            // pagesize = (int)Math.Ceiling((double)itemcount / Convert.ToInt32(hdnpgsize.Value));
        }
        else
        {
            pagesize = Convert.ToInt32(Request.QueryString["item"].ToString());
        }


    }


    protected void pg_rightclick(object sender, EventArgs e)
    {

       
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
       

        //ddlCategory.SelectedValue = "0";
        //ddlfiltertype.SelectedValue = "0";
        string filter = "";
        filter = hdnfilter.Value != "1,2" ? hdnfilter.Value : "0";

        string catfilter = "";
        catfilter = hdncategory.Value != "" ? hdncategory.Value : "0";

        if (hdnfilter.Value == "1,2" || hdnfilter.Value == "2,1")
        {
            ddlfiltertype.SelectedValue = "0";
        }
        else
        {
            if (hdnfilter.Value == "")
            {
                ddlfiltertype.SelectedValue = "0";
                filter = "1,2";
            }
            else
            {
                ddlfiltertype.SelectedValue = hdnfilter.Value;
            }
        }

        if (hdncategory.Value.Contains(","))
        {
            ddlCategory.SelectedValue = "0";
        }
        else
        {
            if (hdncategory.Value == "")
            {
                ddlCategory.SelectedValue = "0";
            }
            else
            {
                try
                {
                    ddlCategory.SelectedValue = hdncategory.Value;
                }
                catch (Exception ex)
                {
                }
            }
        }
        filter = hdnfilter.Value != "" ? hdnfilter.Value : "0";

        lblstartpg.Value = "1";
        //findclick();

        
        Session["lsesCategory"] = hdncategory.Value;
        Session["lsesCategoryname"] = hdncategoryname.Value;
        Session["lsesFilter"] = hdnfilter.Value;
        Session["lsesFramematerial"] = hdnFrameMaterial.Value;
        Session["lsesFramestyle"] = hdnFrameStyle.Value;
        Session["lsesCountry"] = hdnCountry.Value;
        Session["lsesGender"] = hdnGender.Value;
        Session["lsesFramecolor"] = hdnFrameColor.Value;
        Session["lseslenscolor"] = hdnlenscolor.Value;
        Session["lseseyesize"] = hdneyesize.Value;
        Session["lsesmaxvalue"] = hdnMaxValue.Value;
        Session["lsesminvalue"] = hdnMinValue.Value;
        Session["lcurrentfilter"] = currentfilter.Value;
        Session["lsesetop"] = hdnetop.Value;

        //Response.Redirect(Request.RawUrl.Remove(Request.RawUrl.LastIndexOf('-') + 1) + lblstartpg.Value);
        if (Request.RawUrl.Contains("/all-"))
        {
            Response.Redirect("all-" + lblbrandname.Text + "-0-" + categoryid + "-" + lblstartpg.Value + "-" + categoryid + "-" + catfilter + "-" + pagesize);
        }
        else
        {
            Response.Redirect("brand-" + lblbrandname.Text.Replace("&", "$").Replace("+", "%20") + "-" + brandid + "-" + lblstartpg.Value + "-" + filter + "-" + brandid + "-" + pagesize );
        }
    }

    protected void lnkpgsize_Click(object sender, EventArgs e)
    {
        lblstartpg.Value = "1";
        string filter = "";
        filter = hdnfilter.Value != "1,2" ? hdnfilter.Value : "0";

        if (hdnfilter.Value == "1,2" || hdnfilter.Value == "2,1")
        {
            ddlfiltertype.SelectedValue = "0";
        }
        else
        {
            if (hdnfilter.Value == "")
            {
                ddlfiltertype.SelectedValue = "0";
                filter = "1,2";
            }
            else
            {
                ddlfiltertype.SelectedValue = hdnfilter.Value;
            }
        }
        //Session["lsesFilter"] = hdnfilter.Value;
        //Session["lsesCategory"] = hdncategory.Value;
        Session["lsesCategory"] = hdncategory.Value;
        Session["lsesFilter"] = hdnfilter.Value;
        Session["lsesFramematerial"] = hdnFrameMaterial.Value;
        Session["lsesFramestyle"] = hdnFrameStyle.Value;
        Session["lsesCountry"] = hdnCountry.Value;
        Session["lsesGender"] = hdnGender.Value;
        Session["lsesFramecolor"] = hdnFrameColor.Value;
        Session["lseslenscolor"] = hdnlenscolor.Value;
        Session["lsesmaxvalue"] = hdnMaxValue.Value;
        Session["lsesminvalue"] = hdnMinValue.Value;
        Session["lsesSort"] = hdnsortby.Value;
        Session["lsesFilter"] = hdnfilter.Value;

        if (Request.RawUrl.Contains("/all-"))
        {
            Response.Redirect("all-" + lblbrandname.Text + "-0-" + categoryid + "-" + lblstartpg.Value + "-" + categoryid + "-" + brandid + "-" + pagesize);
        }
        else
        {
            Response.Redirect("brand-" + lblbrandname.Text.Replace("&", "$").Replace("+", "%20") + "-" + brandid + "-" + lblstartpg.Value + "-" + filter + "-" + brandid + "-" + pagesize);
        }
        //findclick();
        //  bindViewAllProductMode();
    }

    protected void lnksort_Click(object sender, EventArgs e)
    {
        lblstartpg.Value = "1";
        string filter = "";
        filter = hdnfilter.Value != "1,2" ? hdnfilter.Value : "0";

        string catfilter = "";
        catfilter = hdncategory.Value != "" ? hdncategory.Value : "0";


        if (hdnfilter.Value == "1,2" || hdnfilter.Value == "2,1")
        {
            ddlfiltertype.SelectedValue = "0";
        }
        else
        {
            if (hdnfilter.Value == "")
            {
                ddlfiltertype.SelectedValue = "0";
                filter = "1,2";
            }
            else
            {
                ddlfiltertype.SelectedValue = hdnfilter.Value;
            }
        }
        //Session["lsesFilter"] = hdnfilter.Value;
        if (Request.QueryString["brand"].ToString() != "0")
        {
            Session["lsesCategory"] = Request.QueryString["brand"].ToString();
            hdncategory.Value = Request.QueryString["brand"].ToString();
        }
        else
        {
            Session["lsesCategory"] = hdncategory.Value;
        }

        Session["lsesFramematerial"] = hdnFrameMaterial.Value;
        Session["lsesFramestyle"] = hdnFrameStyle.Value;
        Session["lsesCountry"] = hdnCountry.Value;
        Session["lsesGender"] = hdnGender.Value;
        Session["lsesFramecolor"] = hdnFrameColor.Value;
        Session["lseslenscolor"] = hdnlenscolor.Value;
        Session["lsesmaxvalue"] = hdnMaxValue.Value;
        Session["lsesminvalue"] = hdnMinValue.Value;
        Session["lsesSort"] = hdnsortby.Value;
        Session["lsesFilter"] = hdnfilter.Value;

        if (Request.RawUrl.Contains("/all-"))
        {
            Response.Redirect("all-" + lblbrandname.Text + "-0-" + categoryid + "-" + lblstartpg.Value + "-" + categoryid + "-" + catfilter + "-" + pagesize);
        }
        else
        {
            Response.Redirect("brand-" + lblbrandname.Text.Replace("&", "$").Replace("+", "%20") + "-" + brandid + "-" + lblstartpg.Value + "-" + filter + "-" + brandid + "-" + pagesize);
        }
       // Response.Redirect("0-New%20Stock-" + lblstartpg.Value + "-" + pagesize + "-Arrival");
        //findclick();
        //  bindViewAllProductMode();
    }

    protected void lnkgotopgnew_Click(object sender, EventArgs e)
    {
        string filter = "";
        filter = hdnfilter.Value != "1,2" ? hdnfilter.Value : "0";
        if (filter == "")
        {
            filter = "0";
        }
        //Session["lsesFilter"] = hdnfilter.Value;
        if (Request.QueryString["brand"].ToString() != "0")
        {
            Session["lsesCategory"] = Request.QueryString["brand"].ToString();
            hdncategory.Value = Request.QueryString["brand"].ToString();
        }
        else
        {
            Session["lsesCategory"] = hdncategory.Value;
        }

        Session["lsesFramematerial"] = hdnFrameMaterial.Value;
        Session["lsesFramestyle"] = hdnFrameStyle.Value;
        Session["lsesCountry"] = hdnCountry.Value;
        Session["lsesGender"] = hdnGender.Value;
        Session["lsesFramecolor"] = hdnFrameColor.Value;
        Session["lseslenscolor"] = hdnlenscolor.Value;
        Session["lsesmaxvalue"] = hdnMaxValue.Value;
        Session["lsesminvalue"] = hdnMinValue.Value;
        Session["lsesSort"] = hdnsortby.Value;
        Session["lsesFilter"] = hdnfilter.Value;

        //Session["startpage"] = hdnpagemode_new.Value;
        lblstartpg.Value = hdnpagemode_new.Value;
        //Response.Redirect(Request.RawUrl);
        //Response.Redirect(Request.RawUrl.Remove(Request.RawUrl.LastIndexOf('-') + 1) +  lblstartpg.Value);
        if (Request.RawUrl.Contains("/all-"))
        {
            Response.Redirect("all-" + lblbrandname.Text + "-0-" + categoryid + "-" + lblstartpg.Value + "-" + categoryid + "-" + Request.QueryString["brand"].ToString() + "-" + pagesize);
        }
        else
        {
            Response.Redirect("brand-" + lblbrandname.Text.Replace("&", "$").Replace("+", "%20") + "-" + brandid + "-" + lblstartpg.Value + "-" + filter + "-" + brandid +"-"+ pagesize);
        }

        //findclick();
    }

    protected void lnkgotopg_Click(object sender, EventArgs e)
    {
        ////if (hdnpagemode.Value == "p")
        ////{
        ////    int pg = 1;
        ////    if (lblstartpg.Text != "" && lblstartpg.Text != "1")
        ////    {
        ////        pg = Convert.ToInt32(lblstartpg.Text) - 1;
        ////        lblstartpg.Text = pg.ToString();
        ////        ddlpgopt.SelectedValue = pg.ToString();

        ////        lblstartpg.Text = pg.ToString();
        ////        ddlpgopt.SelectedValue = pg.ToString();

        ////    }
        ////    else
        ////    {
        ////        lblstartpg.Text = "1";
        ////        ddlpgopt.SelectedValue = "1";

        ////        lblstartpg.Text = "1";
        ////        ddlpgopt.SelectedValue = "1";

        ////    }
        ////}
        ////else if (hdnpagemode.Value == "n")
        ////{
        ////    int pg = 1;
        ////    if (lblstartpg.Text == lblpgcount.Text)
        ////    {
        ////    }
        ////    else
        ////    {
        ////        pg = Convert.ToInt32(lblstartpg.Text) + 1;
        ////        lblstartpg.Text = pg.ToString();
        ////        ddlpgopt.SelectedValue = pg.ToString();

        ////        lblstartpg.Text = pg.ToString();
        ////        ddlpgopt.SelectedValue = pg.ToString();
        ////    }
        ////}
        ////else
        ////{
        ////}

        ////findclick();
        //////  bindViewAllProductMode();
    }

    public string TrimBrandName(string bname)
    {
        string brandName = "";

        brandName = bname.Substring(0, 10) + "..";

        return brandName;
    }

    public void bindProductGrid(DataTable dt, bool IsMobile)
    {
        string Header = "";
        string Footer = "";
        string Data = "";
        //  <thead><tr><th colspan='7' style='text-align:left; font-weight:normal'><a href='javascript:void(0)' onclick='viewall()'>View All Products</a>&nbsp; | &nbsp;<a href='javascript:void(0)' onclick='lnkSort()'>Sort by New Stock</a></th></tr>
        if (!IsMobile)
        {


            if (dt.Rows.Count > 0)
            {

                //divrow.Visible = true;
                divmsg.Visible = false;
                divItems.Visible = true;
                divheader.Visible = true;
                lblrecordmsg.Text = "";
                //paginationtop.Visible = true;
                //paginationbottom.Visible = true;
                if (Request.QueryString["b"] == "0")
                {
                    btndownloadfeed.Visible = false;
                }
                else
                {
                    btndownloadfeed.Visible = true;
                }

                //btndownloadfeed2.Visible = true;


                string style = "";

                if (Uflag == "1")
                {
                    style = "";
                    btnaddcart.Visible = true;
                }
                else
                {
                    style = " style='display:none' ";
                    btnaddcart.Visible = false;
                }



                decimal wsprice = 0;
                decimal paidprice = 0;
                decimal retailprice = 0;
                StringBuilder html = new StringBuilder();



                //recordcount.Text = Convert.ToString(dt.Rows[0]["RecordCount"].ToString());
                //recordcountb.Text = Convert.ToString(dt.Rows[0]["RecordCount"].ToString());

                ////lblpgcount.Text = ((Convert.ToInt32(dt.Rows[0]["RecordCount"]) + pagesize - 1) / pagesize).ToString();
                //lblpgcount1.Text = ((Convert.ToInt32(dt.Rows[0]["RecordCount"]) + pagesize - 1) / pagesize).ToString();

                ////lblpgcountb.Text = ((Convert.ToInt32(dt.Rows[0]["RecordCount"]) + pagesize - 1) / pagesize).ToString();

                //lblpgcount.Text = (Convert.ToInt32(recordcount.Text) / pagesize).ToString();

                ////if (lblpgcount.Text == "0")
                ////{
                ////    lblpgcount.Text = "1";
                ////    //lblpgcountb.Text = "1";
                ////}




                ////ddlpgopt.Items.Clear();
                ////ddlpgopt.Items.Add(new ListItem("--", "1"));
                ////for (int o = 0; o < Convert.ToInt32(lblpgcount.Text); o++)
                ////{
                ////    ddlpgopt.Items.Add(new ListItem((o + 1).ToString(), (o + 1).ToString()));
                ////}

                pagingDiv.InnerHtml = Set_Paging(Convert.ToInt32(lblstartpg.Value), pagesize, Convert.ToInt32(dt.Rows[0]["RecordCount"]), "activeLink", "disableLink");


                string qty = "";
                string cartbutton = "";
                string cartqty = "";
                int itemcount = 0;
                string price = "";
                string price_og = "";
                string img = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["MidImageUrl"].ToString() == "")
                    {
                        img = "NOIMAGE/noimage.jpg";
                    }
                    else
                    {
                        img = dt.Rows[i]["MidImageUrl"].ToString();
                    }

                    if (Uflag == "1")
                    {
                        price = "$ " + dt.Rows[i]["price_paid"].ToString();
                    }
                    else
                    {
                        price = "$ " + dt.Rows[i]["price_paid"].ToString();
                    }

                    price_og = "$ " + dt.Rows[i]["price"].ToString();
                    if (dt.Rows[i]["IsInCart"].ToString() == "")
                    {
                        //cartbutton = "<p \"><input type=\"button\" class=\"button\" id=\"btnaddcart[pro]\" value=\"Add to Cart\" style=\"display:none;\" onclick=\"add2cart([pro])\" /></p>";
                        cartbutton = "<a class=\"btn add-to-cart\" id=\"btnaddcart" + dt.Rows[i]["productid"].ToString() + "\" href=\"#\"  style=\"display:none;\"  onclick=\"add2cart(" + dt.Rows[i]["productid"].ToString() + ")\" />Add to Cart</a>";
                        qty = "0";
                        cartqty = "";
                        itemcount = 1;
                    }
                    else if (Convert.ToInt32(dt.Rows[i]["CartQty"]) > 0 && Convert.ToInt32(dt.Rows[i]["qtylocation1"].ToString().Replace("+", "")) > Convert.ToInt32(dt.Rows[i]["CartQty"]))
                    {
                        //if (language == "es")
                        //{

                        //    cartbutton = "<a class= \"btn add-to-cart-es added\" id=\"btnaddcart" + dt.Rows[i]["productid"].ToString() + "\" href=\"#\"  style=\"cursor: auto;\"  />" + Resources.Resources.ResourceManager.GetString("AddedtoCart") + "</a>";
                        //}
                        //else
                        //{

                        cartbutton = "<a class= \"btn add-to-cart added\" id=\"btnaddcart" + dt.Rows[i]["productid"].ToString() + "\" href=\"#\"  style=\"cursor: auto;background-color: white;color: black;\"  />" + Resources.Resources.ResourceManager.GetString("AddedtoCart") + "</a>";
                        //}
                        qty = "0";
                        itemcount = 0;

                        cartqty = "<span>| " + Resources.Resources.ResourceManager.GetString("incart") + " <span id=\"incart" + dt.Rows[i]["productid"].ToString() + "\" style=\"font-weight:bold;\">" + dt.Rows[i]["CartQty"].ToString().ToUpper() + "</span></span>";
                    }
                    else
                    {


                        //if (language == "es")
                        //{

                        //    cartbutton = "<a class= \"btn add-to-cart-es added\" id=\"btnaddcart" + dt.Rows[i]["productid"].ToString() + "\" href=\"#\"  style=\"cursor: auto;\"  />" + Resources.Resources.ResourceManager.GetString("AddedtoCart") + "</a>";
                        //}
                        //else
                        //{

                        cartbutton = "<a class= \"btn add-to-cart added\" id=\"btnaddcart" + dt.Rows[i]["productid"].ToString() + "\" href=\"#\"  style=\"cursor: auto;background-color: white;color: black;\"  />" + Resources.Resources.ResourceManager.GetString("AddedtoCart") + "</a>";
                        //}



                        //qty = dt.Rows[i]["CartQty"].ToString().ToUpper();
                        qty = "0";
                        itemcount = 0;
                        cartqty = "<span>| " + Resources.Resources.ResourceManager.GetString("incart") + " <span id=\"incart" + dt.Rows[i]["productid"].ToString() + "\" style=\"font-weight:bold;\">" + dt.Rows[i]["CartQty"].ToString().ToUpper() + "</span></span>";
                    }

                    string brandname = "";

                    if (screenwidth >= 720 && screenwidth <= 1024)
                    {
                        brandname = dt.Rows[i]["categoryname"].ToString().ToUpper();
                        brandname = brandname.Length > 13 ? TrimBrandName(brandname) : brandname;
                    }
                    else
                    {
                        brandname = dt.Rows[i]["categoryname"].ToString().ToUpper();
                    }

                    if (dt.Rows[i]["newstockid"].ToString() != "" && dt.Rows[i]["newstockid"].ToString() != "1")
                    {
                        html.Append(ltlproductdataog.Text.Replace("[brand]", brandname)
          .Replace("[product]", dt.Rows[i]["pname"].ToString().ToUpper()).Replace("[qty]", qty).Replace("[UPC]", dt.Rows[i]["UPC"].ToString())
.Replace("[colorname]", dt.Rows[i]["colorname"].ToString().ToUpper())
.Replace("[ColorCode1]", Resources.Resources.ResourceManager.GetString("ColorCode"))
.Replace("[Size1]", Resources.Resources.ResourceManager.GetString("Size"))
.Replace("[colorcode]", dt.Rows[i]["colorcode"].ToString().ToUpper()).Replace("[size]", dt.Rows[i]["psizename"].ToString()).Replace("[mprice]", "").Replace("[price]", price).Replace("[instock]", dt.Rows[i]["qtylocation1"].ToString()).Replace("[maxqtyavail]", Resources.Resources.ResourceManager.GetString("max1")).Replace("[actualinstock]", dt.Rows[i]["quantity"].ToString()).Replace("[imgurl]", img).Replace("[Decscription]", dt.Rows[i]["productname"].ToString()).Replace("[cartbutton]", cartbutton).Replace("[pro]", dt.Rows[i]["productid"].ToString()).Replace("[newstockid]", "<span class='sale new'>" + Resources.Resources.ResourceManager.GetString("New") + "</span>").Replace("[cartqty]", cartqty).Replace("[incart]", dt.Rows[i]["CartQty"].ToString().ToUpper()).Replace("[itemcount]", itemcount.ToString()).Replace("[style]", style)).Replace("[Qty]", Resources.Resources.ResourceManager.GetString("Qty"));
                    }
                    else if (dt.Rows[i]["newstockid"].ToString() != "" && dt.Rows[i]["newstockid"].ToString() == "1")
                    {
                        html.Append(ltlproductdataog.Text.Replace("[brand]", brandname)
.Replace("[product]", dt.Rows[i]["pname"].ToString().ToUpper()).Replace("[qty]", qty).Replace("[UPC]", dt.Rows[i]["UPC"].ToString())
.Replace("[ColorCode1]", Resources.Resources.ResourceManager.GetString("ColorCode"))
.Replace("[Size1]", Resources.Resources.ResourceManager.GetString("Size"))
.Replace("[colorname]", dt.Rows[i]["colorname"].ToString().ToUpper())
.Replace("[colorcode]", dt.Rows[i]["colorcode"].ToString().ToUpper()).Replace("[size]", dt.Rows[i]["psizename"].ToString()).Replace("[mprice]", price_og).Replace("[price]", price).Replace("[instock]", dt.Rows[i]["qtylocation1"].ToString()).Replace("[actualinstock]", dt.Rows[i]["quantity"].ToString()).Replace("[imgurl]", img).Replace("[Decscription]", dt.Rows[i]["productname"].ToString()).Replace("[cartbutton]", cartbutton).Replace("[pro]", dt.Rows[i]["productid"].ToString()).Replace("[newstockid]", "<span class='sale'>" + Resources.Resources.ResourceManager.GetString("sale1") + "</span>").Replace("[cartqty]", cartqty).Replace("[incart]", dt.Rows[i]["CartQty"].ToString().ToUpper()).Replace("[itemcount]", itemcount.ToString()).Replace("[style]", style)).Replace("[maxqtyavail]", Resources.Resources.ResourceManager.GetString("max1")).Replace("[Qty]", Resources.Resources.ResourceManager.GetString("Qty"));//"<span class='product-label label-custom label-lg-custom label-rounded-custom label-danger'>Sale</span>"
                    }
                    else
                    {
                        html.Append(ltlproductdataog.Text.Replace("[brand]", brandname).Replace("[qty]", qty).Replace("[UPC]", dt.Rows[i]["UPC"].ToString()).Replace("[ColorCode1]", Resources.Resources.ResourceManager.GetString("ColorCode"))
.Replace("[Size1]", Resources.Resources.ResourceManager.GetString("Size")).Replace("[product]", dt.Rows[i]["pname"].ToString().ToUpper()).Replace("[colorname]", dt.Rows[i]["colorname"].ToString().ToUpper()).Replace("[colorcode]", dt.Rows[i]["colorcode"].ToString().ToUpper()).Replace("[size]", dt.Rows[i]["psizename"].ToString()).Replace("[mprice]", "").Replace("[price]", price).Replace("[instock]", dt.Rows[i]["qtylocation1"].ToString()).Replace("[actualinstock]", dt.Rows[i]["quantity"].ToString()).Replace("[imgurl]", img).Replace("[Decscription]", dt.Rows[i]["productname"].ToString()).Replace("[cartbutton]", cartbutton).Replace("[maxqtyavail]", Resources.Resources.ResourceManager.GetString("max1")).Replace("[pro]", dt.Rows[i]["productid"].ToString()).Replace("[newstockid]", "").Replace("[cartqty]", cartqty).Replace("[incart]", dt.Rows[i]["CartQty"].ToString().ToUpper()).Replace("[itemcount]", itemcount.ToString()).Replace("[style]", style)).Replace("[Qty]", Resources.Resources.ResourceManager.GetString("Qty"));
                    }

                    ltlproductdata.Text = html.ToString();

                }

            }
            else
            {
                //paginationtop.Visible = false;
                //paginationbottom.Visible = false;
                ////btndownloadfeed.Visible = false;
                //btndownloadfeed2.Visible = false;
                ////btnaddcart.Visible = false;
                ////divrow.Visible = false;
                divItems.Visible = false;
                divmsg.Visible = true;
                //divheader.Visible = false;
                lblrecordmsg.Text = "No record found!!";
            }
        }
    }


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

    protected void lnksetcat_Click(object sender, EventArgs e)
    {
        if (hdncategory.Value == "0")
            hdncategory.Value = "";

        //ddlCategory.SelectedValue = hdncategory.Value;

        //bindAdvSearchCat();
        //ddlCategory.SelectedValue = "0";
        //bindAdvFilter();
        findclick();
    }


    protected void lnksetFrameMaterial_Click(object sender, EventArgs e)
    {
        findclick();
        //bindAdvSearchCat();
        //bindAdvFilter();
    }


    protected void lnksetFrameStyle_Click(object sender, EventArgs e)
    {
        findclick();
        //bindAdvSearchCat();
        //bindAdvFilter();
    }

    protected void lnksetCountry_Click(object sender, EventArgs e)
    {
        findclick();
        //bindAdvSearchCat();
        //bindAdvFilter();
    }

    protected void lnksetFrameColor_Click(object sender, EventArgs e)
    {
        findclick();
        //bindAdvSearchCat();
        //bindAdvFilter();
    }

    protected void lnksetLensColor_Click(object sender, EventArgs e)
    {
        findclick();
    }

    protected void lnksetValues_Click(object sender, EventArgs e)
    {
        //minVal = hdnMinValue.Value;
        //maxVal = hdnMaxValue.Value;

        findclick();
    }

    protected void lnksetfilter_Click(object sender, EventArgs e)
    {
        //ddlfiltertype.SelectedValue = hdnfilter.Value;  //Commeneted for checkbox


           //if (ddlfiltertype.SelectedValue == "1")
           //{
           //         lblbrandname.Text ="Sunglasses";
           //}
           //else if (ddlfiltertype.SelectedValue == "2")
           //{
           //    lblbrandname.Text = "Opticals";
           //}
           //else
           //{
           //    lblbrandname.Text = "All";
           //}
        ddlfiltertype.SelectedValue = "0";
        //bindAdvFilter();
        findclick();
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblstartpg.Value = "1";
        ltlproductdata.Text = "";
        hdncategory.Value = ddlCategory.SelectedValue;
        brandid = ddlCategory.SelectedValue;
        hdnfilter.Value = categoryid;

        Session["lsesCategory"] = hdncategory.Value;
        //Session["lsesFilter"] = hdnfilter.Value;
        Session["lsesFramematerial"] = hdnFrameMaterial.Value;
        Session["lsesFramestyle"] = hdnFrameStyle.Value;
        Session["lsesCountry"] = hdnCountry.Value;
        Session["lsesGender"] = hdnGender.Value;
        Session["lsesFramecolor"] = hdnFrameColor.Value;
        Session["lseslenscolor"] = hdnlenscolor.Value;
        Session["lsesmaxvalue"] = hdnMaxValue.Value;
        Session["lsesminvalue"] = hdnMinValue.Value;
        //Response.Redirect("all-" + lblbrandname.Text + "-0-" + categoryid + "-" + lblstartpg.Value + "-" + categoryid + "-" + ddlCategory.SelectedValue + "-" + pagesize);
        Response.Redirect("all-" + lblbrandname.Text + "-0-" + categoryid + "-" + lblstartpg.Value + "-" + categoryid + "-" + ddlCategory.SelectedValue + "-" + pagesize);
        //Response.Redirect("brand-" + ddlCategory.SelectedItem.ToString().Replace("&", "$").Replace("+", "%20") + "-" + ddlCategory.SelectedValue + "-" + lblstartpg.Value + "-" + ddlfiltertype.SelectedValue + "-" + ddlCategory.SelectedValue + "-" + pagesize);

        ////bindAdvSearchCat();

        ////hdnfilter.Value = "";
        //hdnFrameColor.Value = "";
        //hdnFrameMaterial.Value = "";
        //hdnFrameStyle.Value = "";
        //hdnCountry.Value = "";

        //string name = HttpUtility.UrlEncode(ddlCategory.SelectedItem.ToString());

        //Response.Redirect("brandlisting.aspx?b=" + ddlCategory.SelectedValue + "&n=" + name +"");
       // findclick();
    }

    protected void ddlfiltertype_SelectedIndexChanged(object sender, EventArgs e)
    {
        ltlproductdata.Text = "";
        lblstartpg.Value = "1";
        if (ddlfiltertype.SelectedValue != "0")
        {
            hdnfilter.Value = ddlfiltertype.SelectedValue;
        }
        else
        {
            hdnfilter.Value = "1,2";
        }

        //Session["lsesCategory"] = hdncategory.Value;
        //Session["lsesFilter"] = hdnfilter.Value;
        Session["lsesFramematerial"] = hdnFrameMaterial.Value;
        Session["lsesFramestyle"] = hdnFrameStyle.Value;
        Session["lsesCountry"] = hdnCountry.Value;
        Session["lsesGender"] = hdnGender.Value;
        Session["lsesFramecolor"] = hdnFrameColor.Value;
        Session["lseslenscolor"] = hdnlenscolor.Value;
        Session["lsesmaxvalue"] = hdnMaxValue.Value;
        Session["lsesminvalue"] = hdnMinValue.Value;
        //Response.Redirect(Request.RawUrl + "-" + ddlfiltertype.SelectedValue);
        //Response.Redirect(Request.RawUrl);
       
        //Response.Redirect(Request.RawUrl.Remove(Request.RawUrl.LastIndexOf('-') + 1) + lblstartpg.Value);
        if (Request.RawUrl.Contains("/all-"))
        {
            Response.Redirect("");
        }
        else
        {
            Response.Redirect("brand-" + lblbrandname.Text.Replace("&", "$").Replace("+", "%20") + "-" + brandid + "-" + lblstartpg.Value+"-"+ddlfiltertype.SelectedValue + "-" + brandid+"-"+pagesize);
        }
        //bindAdvSearchCat();
        //bindAdvFilter();

        //hdnFrameColor.Value = "";
        //hdnFrameMaterial.Value = "";
        //hdnFrameStyle.Value = "";
        //hdnCountry.Value = "";
        //if (ddlfiltertype.SelectedValue == "1")
        //    Response.Redirect("brandlisting.aspx?b=0&n=Sunglasses&c=1");
        //else
        //    Response.Redirect("brandlisting.aspx?b=0&n=Optical&c=2");
       // findclick();
    }

    protected void ddlpgopt_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblstartpg.Value = "1";
        findclick();
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

    protected void Write_Cookie(string CookieName, string CookieValue)
    {
        HttpCookie MyCookie = new HttpCookie(CookieName);
        MyCookie.Value = CookieValue;
        DateTime dt = DateTime.Now;
        TimeSpan ts = new TimeSpan(1, 0, 0, 0, 0);
        MyCookie.Expires = dt + ts;
        Response.Cookies.Add(MyCookie);
    }
    protected void Delete_Cookie(string CookieName)
    {
        HttpCookie deleteThis = new HttpCookie(CookieName);
        deleteThis.Expires = DateTime.Now.AddDays(-2);
        Response.Cookies.Add(deleteThis);
    }

    static string UppercaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }

    //protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
    //    //BindRepeaterData();
    //    findclick();
    //}

    //public string Set_Paging(Int32 PageNumber, int PageSize, Int64 TotalRecords, string ClassName, string DisableClassName)
    //{
    //    string ReturnValue = "<ul>";
    //    try
    //    {
    //        Int64 TotalPages = Convert.ToInt64(Math.Ceiling((double)TotalRecords / PageSize));
    //        if (PageNumber > 1)
    //        {
    //            if (PageNumber == 2) 
    //                ReturnValue = ReturnValue + "<a href=\"#\" onclick=\"gotopage_new(" + Convert.ToString(PageNumber - 1) + ")\"><li><</li></a>";
    //            else
    //            {
    //                ReturnValue = ReturnValue + "<a href=\"#\"  class='" + ClassName + "' onclick=\"gotopage_new(" + Convert.ToString(PageNumber - 1) + ")\"><li><</li></a>";
    //            }
    //        }
    //        else
    //            ReturnValue = ReturnValue + "<a href=\"#\" class='" + DisableClassName + "'><li><</li></a>";
    //        if ((PageNumber -1 ) > 1)
    //            ReturnValue = ReturnValue + "<a href=\"#\" class='" + ClassName + "' onclick=\"gotopage_new(1)\"><li>1</li></a><a href=\"#\"><li>..</li></a>";
    //        for (int i = PageNumber-1; i <= PageNumber; i++)
    //            if (i >= 1)//i>=1
    //            {
    //                if (PageNumber != i)
    //                {
    //                    ReturnValue = ReturnValue + "<a href=\"#\"  class='" + ClassName + "' onclick=\"gotopage_new(" + i.ToString() + ")\"><li>" + i.ToString() + "</li></a>";
    //                }
    //                else
    //                {
    //                    ReturnValue = ReturnValue + "<a class=\"is-active\" href=\"#\" onclick=\"gotopage_new(" + i.ToString() + ")\"><li>" + i + "</li></a>";
    //                }
    //            }
    //        for (int i = PageNumber+1; i <= PageNumber + 1; i++)
    //            if (i <= TotalPages)
    //            {
    //                if (PageNumber != i)
    //                {
    //                    ReturnValue = ReturnValue + "<a href=\"#\" class='" + ClassName + "' onclick=\"gotopage_new(" + i.ToString() + ")\"><li>" + i.ToString() + "</li></a>";
    //                }
    //                else
    //                {
    //                    ReturnValue = ReturnValue + "<a class=\"is-active\" href=\"#\"  onclick=\"gotopage_new(" + i.ToString() + ")><li>" + i + "</li></a>";
    //                }
    //            }
    //        if ((PageNumber+1) < TotalPages)
    //        {
    //            ReturnValue = ReturnValue + "<a href=\"#\"><li>..</li></a>";
              
    //            ReturnValue = ReturnValue + "<a href=\"#\" class='" + ClassName + "' onclick=\"gotopage_new(" + TotalPages.ToString() + ")\"><li>" + TotalPages.ToString() + "</li></a>";
           
    //        }
    //        if (PageNumber < TotalPages)
    //        {
    //            ReturnValue = ReturnValue + "<a href=\"#\" class='" + ClassName + "' onclick=\"gotopage_new(" + Convert.ToString(PageNumber + 1) + ")\"><li>></li></a>";
    //        }
    //        else
    //            ReturnValue = ReturnValue + "<a href=\"#\"><li>></li></a>";
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //    return (ReturnValue+"</ul>");
    //}

    public string Set_Paging(Int32 PageNumber, int PageSize, Int64 TotalRecords, string ClassName, string DisableClassName)
    {
        string ReturnValue = "<ul>";
        try
        {
            Int64 TotalPages = Convert.ToInt64(Math.Ceiling((double)TotalRecords / PageSize));
            if (PageNumber > 1)
            {
                if (PageNumber == 2)
                    ReturnValue = ReturnValue + "<a href=\"#\" onclick=\"gotopage_new(" + Convert.ToString(PageNumber - 1) + ")\"><li><</li></a>";
                else
                {
                    ReturnValue = ReturnValue + "<a href=\"#\"  class='" + ClassName + "' onclick=\"gotopage_new(" + Convert.ToString(PageNumber - 1) + ")\"><li><</li></a>";
                }
            }
            else
                ReturnValue = ReturnValue + "<a href=\"#\" class='" + DisableClassName + "'><li><</li></a>";
            if ((PageNumber - 1) > 1)
            {
                if ((PageNumber - 1) != 2)
                {
                    ReturnValue = ReturnValue + "<a href=\"#\" class='" + ClassName + "' onclick=\"gotopage_new(1)\"><li>1</li></a><a href=\"#\"><li>..</li></a>";
                }
                else
                {
                    ReturnValue = ReturnValue + "<a href=\"#\" class='" + ClassName + "' onclick=\"gotopage_new(1)\"><li>1</li></a>";
                }
            }



            for (int i = PageNumber - 1; i <= PageNumber; i++)
                if (i >= 1)//i>=1
                {
                    if (PageNumber != i)
                    {
                        ReturnValue = ReturnValue + "<a href=\"#\"  class='" + ClassName + "' onclick=\"gotopage_new(" + i.ToString() + ")\"><li>" + i.ToString() + "</li></a>";
                    }
                    else
                    {
                        ReturnValue = ReturnValue + "<a class=\"is-active\" href=\"#\" onclick=\"gotopage_new(" + i.ToString() + ")\"><li>" + i + "</li></a>";
                    }
                }
            for (int i = PageNumber + 1; i <= PageNumber + 1; i++)
                if (i <= TotalPages)
                {
                    if (i != TotalPages - 1 && i != PageNumber + 1)
                    {
                        if (PageNumber != i)
                        {
                            ReturnValue = ReturnValue + "<a href=\"#\" class='" + ClassName + "' onclick=\"gotopage_new(" + i.ToString() + ")\"><li>" + i.ToString() + "</li></a>";
                        }
                        else
                        {
                            ReturnValue = ReturnValue + "<a class=\"is-active\" href=\"#\"  onclick=\"gotopage_new(" + i.ToString() + ")><li>" + i + "</li></a>";
                        }
                    }
                    else
                    {
                        ReturnValue = ReturnValue + "<a href=\"#\" class='" + ClassName + "' onclick=\"gotopage_new(" + i.ToString() + ")\"><li>" + i.ToString() + "</li></a>";
                    }
                }
            if ((PageNumber + 1) < TotalPages)
            {
                if (TotalPages - 1 != PageNumber + 1)
                {
                    ReturnValue = ReturnValue + "<a href=\"#\"><li>..</li></a>";
                }
                ReturnValue = ReturnValue + "<a href=\"#\" class='" + ClassName + "' onclick=\"gotopage_new(" + TotalPages.ToString() + ")\"><li>" + TotalPages.ToString() + "</li></a>";

            }
            if (PageNumber < TotalPages)
            {
                ReturnValue = ReturnValue + "<a href=\"#\" class='" + ClassName + "' onclick=\"gotopage_new(" + Convert.ToString(PageNumber + 1) + ")\"><li>></li></a>";
            }
            else
                ReturnValue = ReturnValue + "<a href=\"#\"><li>></li></a>";
        }
        catch (Exception ex)
        {
        }
        return (ReturnValue + "</ul>");
    }
}