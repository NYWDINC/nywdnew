using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop_Home : System.Web.UI.Page
{
    public string uLevel = "";
    public string BANNER_280_359 = "";
    public string BANNER_360_539 = "";
    public string BANNER_540_1024 = "";
    public string bannerpromo = "";
    public string POP_pup = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        uLevel = Cookies_Read("level");
        BANNER_280_359 = Resources.Resources.ResourceManager.GetString("BANNER_280_359");
        BANNER_360_539 = Resources.Resources.ResourceManager.GetString("BANNER_360_539");
        BANNER_540_1024 = Resources.Resources.ResourceManager.GetString("BANNER_540_1024");
        bannerpromo = Resources.Resources.ResourceManager.GetString("bannerpromo");
        POP_pup = Resources.Resources.ResourceManager.GetString("POP_pup");

        if (uLevel == "3")
        {
            divbanner1.Visible = true;
            divbanner2.Visible = true;
            divbanner3.Visible = true;
            divbanner4.Visible = false;
        }
        else if ( uLevel == "4"  )
        {
            divbanner1.Visible = true;
            divbanner2.Visible = false;
            divbanner3.Visible = false;
            divbanner4.Visible = false;
        }
        else
        {
            divbanner1.Visible = false;
            divbanner2.Visible = true;
            divbanner3.Visible = true;
            divbanner4.Visible = false;
        }
    }

    protected void lnklessthan_Click(object sender, EventArgs e)
    {
        Session["qsesMinValue"] = "0";
        Session["qsesMaxValue"] = "20";
        Session["qkeyword"] = "20$ or Less";
        Response.Redirect("keyword-20$ or Less-1-25");
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
}