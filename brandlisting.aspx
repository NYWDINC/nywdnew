<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" Buffer="true" CodeFile="brandlisting.aspx.cs" Inherits="brandlisting" %>

<asp:Content ID="Content5" ContentPlaceHolderID="mainHead" runat="Server">
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        $(document).keypress(
             function (event) {
                 if (event.which == '13') {
                     event.preventDefault();
                 }
             });
        
        //$(window).bind("pageshow", function() {
        //    var form = $('form'); 
        //    // let the browser natively reset defaults
        //    form[0].reset();
        //});

        $(document).ready(function(){
           

            $(window).click(function() {
                $(".baloon").hide();
            });

            $('.close-modalCustom1').click(function (e) {
                e.preventDefault();
                $('#modal-custom-container1').addClass('out');
                $('body').removeClass('modal-active');
            });

            $('.modalCustom1').click(function (e) {
                e.preventDefault();
                $('#modal-custom-container1').addClass('out');
                $('body').removeClass('modal-active');
            });
        });

        function pageLoad(cat, fm, fs, country,gender, brand1, fc, lc, ddcat) {
            //  alert(brand);
            //alert(fm);
            //if ((cat != ddcat) && (ddcat != 0 && ddcat != "") && cat != "1,2") {
            //alert(cat);
            //    cat = ddcat;
            //}


            //if (cat == "1" || cat == "2") {
            //    $("#<= ddlfiltertype.ClientID %>").val(cat);
            //}

            var id = $(".cat");
            var cat = "," + cat + ","; // ,1,
            id.each(function () {
                
                //if (cat.includes("," + this.id + ",") == true) {
                //    $("#" + this.id).prop("checked", true);
                //}

                if(cat.includes(",1,") == true)
                {
                    $("#sunglass").prop("checked", true);
                }
                if(cat.includes(",2,") == true)
                {
                    $("#eyeglass").prop("checked", true);
                }

                //alert($(this).attr(id));
            })
            // alert(brand);
            var lensid = $(".lens");
            var lc = "," + lc + ",";
            lensid.each(function () {

                if (lc.includes("," + this.id + ",") == true) {
                    //$("#" + this.id).prop("checked", true);
                    $("input[id='" + this.id + "']").prop("checked", true);
                }

            })
            // alert(brand);
            var frameid = $(".frame");
            var fm = "," + fm + ",";
            frameid.each(function () {

                if (fm.includes("," + this.id + ",") == true) {
                    //$("#" + this.id).prop("checked", true);
                    $("input[id='" + this.id + "']").prop("checked", true);
                }

            })

            // alert(brand);
            var framestyleid = $(".fstyle");
            var fs = "," + fs + ",";
            framestyleid.each(function () {

                if (fs.includes("," + this.id + ",") == true) {
                    //$("#" + this.id).prop("checked", true);
                    $("input[id='" + this.id + "']").prop("checked", true);
                }

            })
            // alert(brand);
            var countryid = $(".country");
            var country = "," + country + ",";
            countryid.each(function () {

                if (country.includes("," + this.id + ",") == true) {
                    //$("#" + this.id).prop("checked", true);
                    $("input[id='" + this.id + "']").prop("checked", true);
                }

            })
            // alert(brand);
            var genderid = $(".gender");
            var gender = "," + gender + ",";
            genderid.each(function () {

                if (gender.includes("," + this.id + ",") == true) {
                    //$("#" + this.id).prop("checked", true);
                    $("input[id='" + this.id + "']").prop("checked", true);
                }

            })
            // alert(brand);
            var framecid = $(".framec");
            var fc = "," + fc + ",";

            framecid.each(function () {
                //alert("fc: " + fc);
                //alert("id:" + this.id);
                if (fc.includes("," + this.id + ",") == true) {
                    //alert("true");
                    //alert($("#" + this.id).val());
                    //$("#" + this.id).prop("checked", true);
                    $("input[id='" + this.id + "']").prop("checked", true);
                }

            })

            if($("#<%=hdneyesize.ClientID%>").val() != "" && $("#<%=hdneyesize.ClientID%>").val() != "0" && $("#<%=hdneyesize.ClientID%>").val() != "00")
            {
                $("#<%=ddleyesize.ClientID%>").val($("#<%=hdneyesize.ClientID%>").val());
            }

            //  alert(brand);
            var brandid = $(".brand");
            var brand2 = "," + brand1 + ",";
            var tmp = "";
           
            if(brand1 != "")
            {
                brandid.each(function () {
                    if (brand2.includes("," + this.id + ",") == true) {
                        $("#" + this.id).prop("checked", true);
                        if($("#" + this.id).prop("checked") == true)
                        {
                            tmp = "1";
                        }
                    }
                })
            }
            //alert("tmp:"+ tmp);
            //alert(brand1);
            if(tmp != "" && brand1 == "")
            {
                document.getElementById("ctl00_ContentPlaceHolder1_btnApply").click();
            }
        }

        function setddlcategory(productid) {
            $("#<%=hdncategory.ClientID %>").val(productid);
            document.getElementById("<%=lnksetcat.ClientID %>").click();  
        }

        function setCountry(id) {
            $("#<%=hdnCountry.ClientID %>").val(id);
            document.getElementById("<%=lnksetCountry.ClientID %>").click();
        }

        function setFrameStyle(id) {
            $("#<%=hdnFrameStyle.ClientID %>").val(id);
            document.getElementById("<%=lnksetFrameStyle.ClientID %>").click();
        }

        function setFrameMaterial(id) {
            
            $("#<%=hdnFrameMaterial.ClientID %>").val(id);
            document.getElementById("<%=lnksetFrameMaterial.ClientID %>").click();
        }
        
        function setFrameColor(id) {
            $("#<%=hdnFrameColor.ClientID %>").val(id);
            document.getElementById("<%=lnksetFrameColor.ClientID %>").click();
        }

        function setddlfiltertype(id) {
            // alert(id);
            $("#<%=hdnfilter.ClientID %>").val(id);
            document.getElementById("<%=lnksetfilter.ClientID %>").click();
           
            
            
            // $('#filter' + id).addClass('active');
        }
        
        function gotoproductpage(productid){
            //alert(productid);
            var ac = $(".add-to-cart");
            var itempending = "";
            $("#cyes").attr("onclick","confirmProduct("+productid+")");
            ac.each(function (i) {
                if($("#"+this.id).hasClass("added") == false && $("#"+this.id).attr("style") != "display:none;" && $("#"+this.id).attr("style") != "display:none" )
                {
                    itempending = "1";
                }
            })

            if(itempending == "1")
            {
                $('#modal-custom-container31').addClass('open-modal');
                $('#modal-custom-container31').removeClass("out");
                $('body').addClass('modal-active');
            }
            else{
                document.location.href = productid+"-cfm";
            }
        }

        function confirmProduct(productid)
        {
            // alert(mode);
            //$("#overlay").show();

            $('#modal-custom-container31').removeClass("out");
            $('#modal-custom-container31').removeClass("open-modal");
            $('body').addClass('modal-active');
            document.location.href = productid+"-cfm";
        }

        function gotosort() {
            $("#overlay").show();
            //var pgno = document.getElementById("pg").value;
            $("#<%=hdnsortby.ClientID %>").val($("#<%=ddlpgsort.ClientID %>").val());
           
            document.getElementById("<%=lnksort.ClientID %>").click();
        }

        function gotopg() {
            $("#overlay").show();
            //var pgno = document.getElementById("pg").value;
            var pgno = document.getElementById("<%=ddlpgoptb.ClientID %>").value;
            $("#<%=hdnsortby.ClientID %>").val($("#<%=ddlpgsort.ClientID %>").val());
            $("#<%=hdnpgsize.ClientID %>").val(pgno);
            document.getElementById("<%=lnkpgsize.ClientID %>").click();
        }

        function explode() {
            $('.success').show(1000);
            $('.modal-feed .btn').show(1000);
            $("#exceltxt").html(" ");

        }

        function downloadxls1() {
            if (document.getElementById("hdnfname").value != "") {
                //var newWin = window.open("https://www.nywdinc.com/Interop/" + document.getElementById("hdnfname").value);
                var newWin = window.open("Interop/" + document.getElementById("hdnfname").value);

                //if (!newWin || newWin.closed || typeof newWin.closed == 'undefined') {
                //    //POPUP BLOCKED
                //    alert("Cannot download due to browser POPUP is BLOCKED. Try enabling it and then download feed");
                //}
            }
            else {
                alert("<%=Thereisnofile%>");
            }
        }

        function uploadFeed()
        {
            $('#modal-container3').removeAttr('class').addClass('open-modal');

            
            $.post('Ajax_temp.aspx', { ch: 30, userid: "<%=UserID %>", searchcriteria :"<%=searchcriteria%>", flag:"<%=Uflag%>"}, function (data) {
                if(data.includes("saved"))
                {
                    $("#doprogress").removeClass("progress-value2").addClass("progress-value");
                }
                else
                {
                    $("#exceltxt").html("Something is wrong, try after sometime.");
                }
            })
        }

        function downloadxls() {

            var rcnt = 0;
            rcnt = $("#<%=lblitemcount1.ClientID %>").html().replace("(","").replace(")","").replace("<i>","").replace("</i>","");

            if(rcnt > 200)
            {
                $("#<%=exceltxt.ClientID %>").html('<%=Resources.Resources.ResourceManager.GetString("thankyoudownload") + " <b>" + email + "</b>."%>') ;
                uploadFeed();
            }
            else
            {
                $("#<%=exceltxt.ClientID %>").html('<%=Resources.Resources.ResourceManager.GetString("Generatingexcel")%>') ;
                var txtSearch = "";
                var brandid = $("#<%=hdncategory.ClientID %>").val();

                if (brandid == "") {
                    var mode = 1;
                    brandid = "0";
                }
                else {
                    var mode = "0";
                }

                var catidsun = 1;
                var catideye = 2;

                if ($("#<%=hdnfilter.ClientID %>").val() == "1") {
                    catidsun = 1;
                    catideye = 0;
                }
                else if ($("#<%=hdnfilter.ClientID %>").val() == "2") {
                    catidsun = 0;
                    catideye = 2;
                }
                else {
                    catidsun = 1;
                    catideye = 2;
                }

                var isAll = "<% Response.Write(isAllEyewear); %>";

                //            var url = "showfeedfileEyewear.aspx?brandid=" + brandid + "&catidsun=" + catidsun + "&catideye=" + catideye + "&userid=<% Response.Write(UserID); %>&all=" + mode + "&txtSearch=" + txtSearch + "&isAll=<% Response.Write(isAllEyewear); %>";

                var url = "showfeedfileEyewear_filter.aspx?brandid=" + $("#<%=hdncategory.ClientID %>").val() + "&catidsun=" + catidsun + "&catideye=" + catideye + "&userid=<% Response.Write(UserID); %>&all=" + mode + "&txtSearch=" + txtSearch + "&isAll=<% Response.Write(isAllEyewear); %>&framematerial="+$("#<%=hdnFrameMaterial.ClientID %>").val()+"&framestyle="+$("#<%=hdnFrameStyle.ClientID %>").val()+"&framecolor="+$("#<%=hdnFrameColor.ClientID %>").val()+"&lenscolor="+$("#<%=hdnlenscolor.ClientID %>").val()+"&country="+$("#<%=hdnCountry.ClientID %>").val()+"&gender="+$("#<%=hdnGender.ClientID %>").val()+"&eyesize="+$("#<%=hdneyesize.ClientID %>").val()+"&MaxValue="+$("#<%=hdnMaxValue.ClientID %>").val()+"&MinValue="+$("#<%=hdnMinValue.ClientID %>").val()+"&flag=<%=Uflag%>";

                //   openWindow(url, 'newtab', 'width=800, height=600, scrollbars=yes');
                $('#modal-container3').removeAttr('class').addClass('open-modal');
                if (document.getElementById("hdnfname").value == "") {
                    //http://e-sunglass.com/showfeedfileEyewear.aspx?brandid=0&catidsun=1&catideye=2&userid=56&all=1&txtSearch=newstock&isAll=
                    //http://e-sunglass.com/showfeedfileEyewear.aspx?brandid=0&catidsun=1&catideye=2&userid=56&all=1&txtSearch=eclearance&isAll=
                    //B2B_Data_Feed_eclearance056 (3)
                    // B2B_Data_Feed_newstock056 (1)
                    var fname = "";
                    if (txtSearch == "newstock") {
                        fname = "B2B_Data_Feed_newstock" + brandid.replace(/\,/g,'') + "<% Response.Write(UserID); %>.xlsx";
                    }
                    else if (txtSearch == "eclearance") {
                        fname = "B2B_Data_Feed_eclearance" + brandid.replace(/\,/g,'') + "<% Response.Write(UserID); %>.xlsx";
                    }
                    else if (isAll == "") {
                        fname = "B2B_Data_Feed_" + brandid.replace(/\,/g,'') + "<% Response.Write(UserID); %>.xlsx";
                    }

                    var iframe = document.createElement('iframe');
                    iframe.style = "display:none";
                    iframe.onload = function () {
                        $("#doprogress").removeClass("progress-value2").addClass("progress-value"); document.getElementById("hdnfname").value = fname;
                        setTimeout(explode, 1000);
                    };

                    //var oldWindowOpen = window.open;
                    //window.open = function (url, name, features, replace) {
                    // handle window.open yourself
                    iframe.src = url;
                    // if you want to use functionality of original window.open call the oldWindowOpen function
                    //      oldWindowOpen(url, 'myName', 'myFeatures');
                    //}
                    document.body.appendChild(iframe);
                }
            }
}

function gotopage(mode) {
           
    if (mode == "p") {
        if ($("#<%=lblstartpg.ClientID %>").html() != "" && $("#<%=lblstartpg.ClientID %>").html() != "1") {
            $("#<%=hdnpagemode.ClientID %>").val(mode);
            document.getElementById("<%=lnkgotopg.ClientID %>").click();
        }
    }
    else if (mode == "n") {
        // alert("n");

        ////if ($("#<%=lblstartpg.ClientID %>").html() == $("#<=lblpgcount.ClientID %>").html()) {
                 // alert("blank");
             }
             else {
                 //   alert("notblank");

                 $("#<%=hdnpagemode.ClientID %>").val(mode);
                 document.getElementById("<%=lnkgotopg.ClientID %>").click();
             }
     }
    

     function gotopage_new(mode) {
         //alert(mode);
         var ac = $(".add-to-cart");
         var itempending = "";
         $("#cyes").attr("onclick","confirmyes("+mode+")");
         ac.each(function (i) {
             if($("#"+this.id).hasClass("added") == false && $("#"+this.id).attr("style") != "display:none;" && $("#"+this.id).attr("style") != "display:none" )
             {
                 itempending = "1";
             }
         })

         if(itempending == "1")
         {
             $('#modal-custom-container31').addClass('open-modal');
             $('#modal-custom-container31').removeClass("out");
             $('body').addClass('modal-active');
         }
         else
         {
             $("#overlay").show();
             $("#<%=hdnpagemode_new.ClientID %>").val(mode);
             $("#<%=hdnsortby.ClientID %>").val($("#<%=ddlpgsort.ClientID %>").val());
             document.getElementById("<%=lnkgotopg_new.ClientID %>").click();
         }

     }
     function confirmyes(mode)
     {
         // alert(mode);
         $("#overlay").show();
         $('#modal-custom-container31').removeClass("out");
         $('#modal-custom-container31').removeClass("open-modal");
         $('body').addClass('modal-active');
         $("#<%=hdnpagemode_new.ClientID %>").val(mode);
            document.getElementById("<%=lnkgotopg_new.ClientID %>").click();
        }
        function openWindow(url, name, properties) {
            var openWindow = window.open(url, name, properties);
            // var newWin = window.open(url);
            try { openWindow.focus(); } catch (e)
            { alert("<%=PopupBlock%>"); }
        }

        function decrease(productid) {
            //  alert("cool");
            var counter = $('#quantity_1_0_0_11' + productid).val();
            if (counter == "") {
                counter = "0";
            }

            var quantity = $('#quantity_1_0_0_11_hidden' + productid).val();
            var btnaddtocart = $('#btnaddcart' + productid).html();
            var cartquantity = $('#qtyincart' + productid).val();
            // alert(btnaddtocart);
            quantity = parseInt(quantity.replace('+', '')) - parseInt(cartquantity)

            if (btnaddtocart != "<%=added2cart%>") {

            //if (counter < parseInt(quantity.replace('+', '')) - parseInt(cartquantity))
            if (counter > 0)
            {
                counter--;
                $('#quantity_1_0_0_11' + productid).val(counter);
                if (counter > 0) {
                    if (counter <= quantity) {
                        $("#btnaddcart" + productid).removeAttr("style");
                        $("#btnaddcart" + productid).html("<%=add2cart%>");//("Add to Cart");
                        $("#btnaddcart" + productid).removeAttr("class", "btn add-to-cart added");
                        //if("<%=added2cart%>" == "Added to Cart")
                        //{
                        $("#btnaddcart" + productid).attr("class", "btn add-to-cart");
                        //}
                        //else
                        //{
                        //    $("#btnaddcart" + productid).attr("class", "btn add-to-cart-es");
                        //}
                        //$("#btnaddcart" + productid).attr("class", "btn add-to-cart");
                        $("#btnaddcart" + productid).attr("style", "cursor: pointer");
                        $("#btnaddcart" + productid).attr("onclick", "add2cart(" + productid + ")");
                        $("#btnaddcart" + productid).removeAttr("disabled");
                        $("#divbaloon"  + productid).attr("style", "display:none");
                        $('#chk_' + productid).prop('checked', true);
                    }
                    else
                    {
                        $("#divbaloon"+ productid).attr("style", "display:none");
                    }
                }
                else {
                    $("#divbaloon"+ productid).attr("style", "display:none");
                    if ($("#lbcq" + productid).html() == "") {
                        $("#btnaddcart" + productid).attr("style", "display:none");
                        $('#chk_' + productid).prop('checked', false);
                        $("#btnaddcart" + productid).attr("disabled", "true");
                    }
                    else {
                        $("#btnaddcart" + productid).html("<%=added2cart%>");
                        $("#btnaddcart" + productid).removeAttr("onclick");
                        //if("<%=added2cart%>" == "Added to Cart")
                        //{
                        $("#btnaddcart" + productid).attr("class", "btn add-to-cart added");
                        //}
                        //else
                        //{
                        //    $("#btnaddcart" + productid).attr("class", "btn add-to-cart-es added");
                        //}
                        //$("#btnaddcart" + productid).attr("class", "btn add-to-cart added");
                        //$("#btnaddcart" + productid).attr("style", "cursor: auto;");
                        $("#btnaddcart" + productid).attr("style", "cursor: auto;background-color: white;color: black;");
                        $('#chk_' + productid).prop('checked', false);
                        $("#btnaddcart" + productid).attr("disabled", "true");
                    }
                }
            }
            else {
                $("#btnaddcart" + productid).attr("style", "display:none");
                $('#chk_' + productid).prop('checked', false);
            }
        }

    }

    function increase(productid) {
        var counter = $('#quantity_1_0_0_11' + productid).val();
        if (counter == "") {
            counter = "0";
        }

        var quantity = $('#quantity_1_0_0_11_hidden' + productid).val();
        //alert(quantity);
        var cartquantity = $('#qtyincart' + productid).val();

        var btnaddtocart = $('#btnaddcart' + productid).val();

        if (btnaddtocart != "<%=added2cart%>" || (btnaddtocart == "<%=added2cart%>" && $('#btnaddcart' + productid).attr("style") === "cursor: auto;")) {
            if (counter < parseInt(quantity.replace('+', '')) - parseInt(cartquantity)) {
                counter++;
                $('#quantity_1_0_0_11' + productid).val(parseInt(counter));
                if (counter > 0) {
                    $("#btnaddcart" + productid).removeAttr("class", "btn add-to-cart added");
                    $("#btnaddcart" + productid).attr("class", "btn add-to-cart");
                    $("#btnaddcart" + productid).attr("style", "cursor: pointer;");
                    $("#btnaddcart" + productid).html("<%=add2cart%>");
                        $("#btnaddcart" + productid).attr("onclick", "add2cart(" + productid + ")");
                        //$("#btnaddcart" + productid).removeAttr("disabled");
                        $('#chk_' + productid).prop('checked', true);
                        $("#divbaloon"+ productid).attr("style", "display:none");
                    }
                    else {
                        $("#btnaddcart" + productid).attr("style", "display:none");
                        $('#chk_' + productid).prop('checked', false);
                    }
                }
                else
                {
                    $("#divbaloon" + productid).attr("style", "display:block");
                }
            }
        }
        function changevalue(productid) {
            var counter = $('#quantity_1_0_0_11' + productid).val();
            if (counter == "") {
                counter = 0;
            }
            //   alert(counter);
            var quantity = $('#quantity_1_0_0_11_hidden' + productid).val();
            var cartquantity = $('#qtyincart' + productid).val();
            var btnaddtocart = $('#btnaddcart' + productid).val();

            if (btnaddtocart != "<%=added2cart%>" || (btnaddtocart == "<%=added2cart%>")) {
            // if (counter > parseInt(quantity.replace('+', '')) - parseInt(cartquantity)) {
            //     $('#quantity_1_0_0_11' + productid).val(parseInt(counter.replace('+', '')));
            //  }
            if (counter <= parseInt(quantity.replace('+', '')) - parseInt(cartquantity)) {
                if (counter > 0) {
                    //alert("if:"+counter);
                    $("#btnaddcart" + productid).removeAttr("class", "btn add-to-cart added");
                    $("#btnaddcart" + productid).attr("class", "btn add-to-cart");
                    $("#btnaddcart" + productid).attr("style", "cursor: pointer;");
                    $("#btnaddcart" + productid).html("<%=add2cart%>");
                    $("#btnaddcart" + productid).attr("onclick", "add2cart(" + productid + ")");
                    $('#chk_' + productid).prop('checked', true);
                    $("#divbaloon" + productid).attr("style", "display:none");
                }
                else {

                    if ($("#qtyincart" + productid).val() != $("#quantity_1_0_0_11_hidden" + productid).val() && $("#qtyincart" + productid).val() != "0") {
                        $("#btnaddcart" + productid).html("<%=added2cart%>");
                        $("#btnaddcart" + productid).removeAttr("onclick");
                        $("#btnaddcart" + productid).attr("class", "btn add-to-cart added");
                        //$("#btnaddcart" + productid).attr("style", "cursor: auto;");
                        $("#btnaddcart" + productid).attr("style", "cursor: auto;background-color: white;color: black;");
                        $("#quantity_1_0_0_11" + productid).val(0);
                        $('#chk_' + productid).prop('checked', false);
                        //                            alert($("#quantity_1_0_0_11_hidden" + productid).val() + " | " + $("#qtyincart" + productid).val());
                    }
                    else {
                        //alert("else:" + counter);
                        $("#btnaddcart" + productid).val("<%=add2cart%>");
                        $("#btnaddcart" + productid).attr("style", "display:none");
                        //$("#btnaddcart" + productid).attr("disabled", "true");
                        $('#chk_' + productid).prop('checked', false);

                    }
                }
            }
            else {
                if ($("#qtyincart" + productid).val() == $("#quantity_1_0_0_11_hidden" + productid).val() && counter > 0) {
                    $("#btnaddcart" + productid).attr("disabled", "true");
                    $("#btnaddcart" + productid).html("<%=added2cart%>");
                    $("#btnaddcart" + productid).removeAttr("onclick");
                    $("#btnaddcart" + productid).attr("class", "btn add-to-cart added");
                    //$("#btnaddcart" + productid).attr("style", "cursor: auto;");
                    $("#btnaddcart" + productid).attr("style", "cursor: auto;background-color: white;color: black;");
                    $("#quantity_1_0_0_11" + productid).val(0);
                    $('#chk_' + productid).prop('checked', false);
                    $("#divbaloon" + productid).attr("style", "display:block");
                }
                else {
                    $("#quantity_1_0_0_11"+ productid).val(parseInt(quantity) - parseInt(cartquantity));
                    $("#divbaloon" + productid).attr("style", "display:block");
                    $("#btnaddcart" + productid).attr("class", "btn add-to-cart");
                    $("#btnaddcart" + productid).attr("style", "cursor: pointer;");
                    $("#btnaddcart" + productid).html("<%=add2cart%>");
                    //$("#btnaddcart" + productid).attr("style", "display:none");
                    //$("#btnaddcart" + productid).attr("disabled", "true");
                    $('#chk_' + productid).prop('checked', false);
                    //                        alert($("#quantity_1_0_0_11_hidden" + productid).val() + " | " + $("#qtyincart" + productid).val());

                }
            }

        }
        else {
            //  $('#quantity_1_0_0_11' + productid).val(parseInt(quantity.replace('+', '')) - parseInt(cartquantity));
        }
        //  $("#quantity_1_0_0_11" + productid).select();
    }

    function add2cart(productid) {

        $("#btnaddcart" + productid).html("<%=PleaseWait%>");
        var matches = "";
        matches += productid + "|" + $("#quantity_1_0_0_11" + productid).val();


        if (matches != "") {
            $.post('Ajax.aspx', { ch: 12, arr: matches,promotype:"" }, function (data) {
                var cartval = document.getElementById('<%=((Label)Master.FindControl("lblcartcount")).ClientID %>').innerHTML;
                if (cartval == "") {
                    cartval = 0;
                }
                else {
                    cartval = parseInt(cartval);
                }
                // alert(cartval);
                //                    var n2 = parseInt($("#quantity_1_0_0_11" + productid).val());
                var n2 = parseInt($("#itemcount" + productid).val());

                var r = cartval + n2;

                document.getElementById('<%=((Label)Master.FindControl("lblcartcount")).ClientID %>').innerHTML = r;


                //$("#btnaddcart" + productid).attr("disabled", "disabled");
                $("#btnaddcart" + productid).html("<%=added2cart%>");
                $("#btnaddcart" + productid).removeAttr("onclick");

                if ($("#lbcq" + productid).html() == "") {
                    $("#lbcq" + productid).html("<span>|"+"<%=incart%>"+"  <span id=\"incart" + productid + "\" style=\"font-weight:bold;\">" + $("#quantity_1_0_0_11" + productid).val() + "</span></span>");
                    $("#qtyincart" + productid).val($("#quantity_1_0_0_11" + productid).val());

                }
                else {
                    var ci = parseFloat($("#incart" + productid).html()) + parseFloat($("#quantity_1_0_0_11" + productid).val());
                    $("#incart" + productid).html(ci);
                    $("#qtyincart" + productid).val(ci);
                }

                if ($("#qtyincart" + productid).val() == $("#quantity_1_0_0_11_hidden" + productid).val()) {
                    //$("#btnaddcart" + productid).attr("style", "cursor: auto;");
                    $("#btnaddcart" + productid).attr("style", "cursor: auto;background-color: white;color: black;");
                    $('#chk_' + productid).prop('checked', false);
                }
                else {
                    $("#btnaddcart" + productid).attr("style", "cursor: auto;background-color: white;color: black;");
                    //$("#btnaddcart" + productid).attr("style", "cursor: auto;");
                    $("#quantity_1_0_0_11" + productid).val(0);

                    $('#chk_' + productid).prop('checked', false);
                }

            })
        }
        else {
            alert("Please select product");
            $("#btnaddcart" + productid).attr('value', "<%=add2cart%>");
        }

    }

    function add2cart_new() {
        var btn = $('#<%= btnaddcart.ClientID %>');

        
            $('#<%=btnaddcart.ClientID %>').html("<%=PleaseWait%>");
            //$("#btnaddcart").html('Please Wait');
        
       
            var matches = "";

            $(".chkAllProducts:checked").each(function () {
                if ($("#quantity_1_0_0_11" + (this.id).replace('chk_', '')).val() == "" || $("#quantity_1_0_0_11" + (this.id).replace('chk_', '')).val() == "0") {
                    alert("Please enter quantity");
                    $("#quantity_1_0_0_11" + (this.id).replace('chk_', '')).focus();

                    return false;
                }
            });

            $(".chkAllProducts:checked").each(function () {
                matches += this.id + "|" + $("#quantity_1_0_0_11" + (this.id).replace('chk_', '')).val() + "#";
            });
              
            if (matches != "") {
                $.post('Ajax.aspx', { ch: 13, arr: matches,promotype:"" }, function (data) {
                    document.getElementById("<%=lnkViewCart.ClientID%>").click();
                    // $("#btnaddcart").html('Add all to Cart');
                    $('#<%=btnaddcart.ClientID %>').html("<%=addalltocart%>");
                })
            }
            else {
                //alert("Please select product");
                $('#modal-custom-container1').removeAttr('class').addClass('open-modal');
                $('body').addClass('modal-active');

                $('#<%=btnaddcart.ClientID %>').html("<%=addalltocart%>");
            
        }
    }

        
    function checkLensColor() {
        //alert("checkLensColor");
        // document.location.href="#1";
        $("#overlay").show();
        var etop = 0;
        etop = $(window).scrollTop();

        var id = $(".lens")
            .map(function () { return $(this).attr("id"); }).get() + '';

        //alert(id);

        var checked = $(".lens")
       .map(function () { return $(this).prop("checked"); }).get() + '';
              

        var splitchecked = checked.split(',');
        var splitid = id.split(',');

        var checkedid = "";

        for (var i = 0; i < splitchecked.length; i++) {
            if (splitchecked[i] == "true") {
                checkedid = checkedid + splitid[i] + ',';
            }
        }

        document.getElementById("<%=hdnlenscolor.ClientID %>").value = checkedid.slice(0, -1);
            document.getElementById("<%=currentfilter.ClientID %>").value = "lenscolor";
            document.getElementById("<%=hdnetop.ClientID %>").value = etop;

            //alert(document.getElementById("<%=hdnlenscolor.ClientID %>").value);
            //document.getElementById("<%=lnksetLensColor.ClientID %>").click();
            doapplyclick("#6","");
        }

        function checkGender() {
            $("#overlay").show();
            var etop = 0;
            etop = $(window).scrollTop();

            var id = $(".gender")
                .map(function () { return $(this).attr("id"); }).get() + '';

            var checked = $(".gender")
               .map(function () { return $(this).prop("checked"); }).get() + '';

            var splitchecked = checked.split(',');
            var splitid = id.split(',');

            var checkedid = "";

            for (var i = 0; i < splitchecked.length; i++) {
                if (splitchecked[i] == "true") {
                    checkedid = checkedid + splitid[i] + ',';
                }
            }

            document.getElementById("<%=hdnGender.ClientID %>").value = checkedid.slice(0, -1);
             document.getElementById("<%=currentfilter.ClientID %>").value = "gender";
             document.getElementById("<%=hdnetop.ClientID %>").value = etop;

             //alert(document.getElementById("<%=hdnGender.ClientID %>").value);
             doapplyclick("#8","");

         }

         function checkeyesize() {
            
             $("#overlay").show();
             var etop = 0;
             etop = $(window).scrollTop();

             document.getElementById("<%=hdneyesize.ClientID %>").value = $("#<%=ddleyesize.ClientID %>").val();
            document.getElementById("<%=currentfilter.ClientID %>").value = "eyesize";
            document.getElementById("<%=hdnetop.ClientID %>").value = etop;

            doapplyclick("#9","");

        }

        function checkFrameColor() {
            $("#overlay").show();
            var etop = 0;
            etop = $(window).scrollTop();

            //alert("checkFrameColor");
            var id = $(".framec")
                .map(function () { return $(this).attr("id"); }).get() + '';

            var checked = $(".framec")
               .map(function () { return $(this).prop("checked"); }).get() + '';

            var splitchecked = checked.split(',');
            var splitid = id.split(',');

            var checkedid = "";

            for (var i = 0; i < splitchecked.length; i++) {
                if (splitchecked[i] == "true") {
                    checkedid = checkedid + splitid[i] + ',';
                }
            }

            document.getElementById("<%=hdnFrameColor.ClientID %>").value = checkedid.slice(0, -1);
            document.getElementById("<%=currentfilter.ClientID %>").value = "framecolor";
            document.getElementById("<%=hdnetop.ClientID %>").value = etop;

            //alert(document.getElementById("<%=hdnFrameColor.ClientID %>").value);
            // document.getElementById("<%=lnksetFrameColor.ClientID %>").click();
            doapplyclick("#5","");
        }

        function checkCountry() {
            $("#overlay").show();
            var etop = 0;
            etop = $(window).scrollTop();

            var id = $(".country")
                .map(function () { return $(this).attr("id"); }).get() + '';

            var checked = $(".country")
               .map(function () { return $(this).prop("checked"); }).get() + '';

            var splitchecked = checked.split(',');
            var splitid = id.split(',');

            var checkedid = "";

            for (var i = 0; i < splitchecked.length; i++) {
                if (splitchecked[i] == "true") {
                    checkedid = checkedid + splitid[i] + ',';
                }
            }

            document.getElementById("<%=hdnCountry.ClientID %>").value = checkedid.slice(0, -1);
            document.getElementById("<%=currentfilter.ClientID %>").value = "country";
            document.getElementById("<%=hdnetop.ClientID %>").value = etop;

            //alert(document.getElementById("<%=hdnCountry.ClientID %>").value);
            //document.getElementById("<%=lnksetCountry.ClientID %>").click();
            doapplyclick("#7","");
        }

        function checkFramestyle() {
            //alert("ck");
            $("#overlay").show();
            var etop = 0;
            etop = $(window).scrollTop();

            var id = $(".fstyle")
               .map(function () { return $(this).attr("id"); }).get() + '';

            var checked = $(".fstyle")
              .map(function () { return $(this).prop("checked"); }).get() + '';

            var splitchecked = checked.split(',');
            var splitid = id.split(',');

            var checkedid = "";

            for (var i = 0; i < splitchecked.length; i++) {
                if (splitchecked[i] == "true") {
                    checkedid = checkedid + splitid[i] + ',';
                }
            }

            document.getElementById("<%=hdnFrameStyle.ClientID %>").value = checkedid.slice(0, -1);
            document.getElementById("<%=currentfilter.ClientID %>").value = "framestyle";
            document.getElementById("<%=hdnetop.ClientID %>").value = etop;

            //alert(document.getElementById("<%=hdnFrameStyle.ClientID %>").value);
            //document.getElementById("<%=lnksetFrameStyle.ClientID %>").click();
            doapplyclick("#4","");
        }



        function checkFramematerial() {
            
            $("#overlay").show();
            var etop = 0;
            etop = $(window).scrollTop();

            var id = $(".frame")
               .map(function () { return $(this).attr("id"); }).get() + '';

            var checked = $(".frame")
           .map(function () { return $(this).prop("checked"); }).get() + '';

            var splitchecked = checked.split(',');
            var splitid = id.split(',');

            var checkedid = "";

            for (var i = 0; i < splitchecked.length; i++) {
                if (splitchecked[i] == "true") {
                    checkedid = checkedid + splitid[i] + ',';
                }
            }

            document.getElementById("<%=hdnFrameMaterial.ClientID %>").value = checkedid.slice(0, -1);
            document.getElementById("<%=currentfilter.ClientID %>").value = "framematerial";
            document.getElementById("<%=hdnetop.ClientID %>").value = etop;

            //alert(document.getElementById("<%=hdnFrameMaterial.ClientID %>").value);
            //document.getElementById("<%=lnksetFrameMaterial.ClientID %>").click();
            doapplyclick("#3","");
        }

        function checkallclear()
        {
            $("#<%=divclearall.ClientID %>").html("");
            $("input[type=checkbox]").prop('checked', false);
            $("#<%=ddleyesize.ClientID %>").val(0);
            checkFilter();
            checkCategory();
            checkFramematerial();
            checkFramestyle();
            checkCountry();
            checkFrameColor();
            checkeyesize();
            checkGender();
            checkLensColor();

            doapplyclick('#0','');
        }

        function removefilter(id,obj,ex)
        {
            $("#overlay").show();
            if(obj == "checkbox")
            {
                $("input[id='"+id+"']").prop("checked",false);
            }

            if(obj == "dropdown")
            {
                $("#<%=ddleyesize.ClientID %>").val(0);
        }
    }


    function doapplyclick(i,r)
    {
        var isiPhone = navigator.userAgent.toLowerCase().indexOf("iphone");
        var isiPad = navigator.userAgent.toLowerCase().indexOf("ipad");
        var isiPod = navigator.userAgent.toLowerCase().indexOf("ipod");
        checkPrice();
        if(r != "")
        {
            $("#"+r).html("");
        }

        try {
            //alert($("#mobile").html());
            if( /webOS|iPhone|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent) ) {
               // alert("mobile");
            }
            else
            {
               // alert("nomobile");
                if(i == "#10" )
                {
                    $("#overlay").show();
                }
                document.getElementById("<%=hdngoto.ClientID %>").value = i;
                //  alert("before");
                //  var evt = document.createEvent("HTMLEvents");
                //  evt.initEvent("click", true, true); 
                //  document.getElementById("<%=btnApply.ClientID %>").dispatchEvent(evt);
                document.getElementById("<%=btnApply.ClientID %>").click();
                //  alert("after");
            }
        }
        catch(err) {
            if(i == "#10" )
            {
                $("#overlay").show();
            }
            document.getElementById("<%=hdngoto.ClientID %>").value = i;
            document.getElementById("<%=btnApply.ClientID %>").click();
        }
    }

    function checkCategory() {
            
        $("#overlay").show();
        var etop = 0;
        etop = $(window).scrollTop();
        var id = $(".brand")
        .map(function () { return $(this).attr("id"); }).get() + '';

        var idname = $(".brand")
        .map(function () { return $(this).closest("label").children("div span").html(); }).get() + '';
        var checked = $(".brand")
       .map(function () { return $(this).prop("checked"); }).get() + '';

        var splitchecked = checked.split(',');
        var splitid = id.split(',');
        var splitidname = idname.split(',');

        var checkedid = "";
        var checkedidname = "";

        for (var i = 0; i < splitchecked.length; i++) {
            if (splitchecked[i] == "true") {
                checkedid = checkedid + splitid[i] + ',';
                checkedidname = checkedidname + splitidname[i] + ',';
            }
        }

        document.getElementById("<%=hdncategory.ClientID %>").value = checkedid.slice(0, -1);
            document.getElementById("<%=hdncategoryname.ClientID %>").value = checkedidname.slice(0, -1);
            document.getElementById("<%=currentfilter.ClientID %>").value = "category";
            document.getElementById("<%=hdnetop.ClientID %>").value = etop;

            //alert(document.getElementById("<%=hdncategory.ClientID %>").value);
            //document.getElementById("<%=lnksetcat.ClientID %>").click();
            doapplyclick("2","");
        }

        function checkPrice() {
            var p = document.getElementById("<%=hdnMinValue.ClientID %>").value + "-" + document.getElementById("<%=hdnMaxValue.ClientID %>").value;

                    document.getElementById("<%=hdnPrice.ClientID %>").value = p ;
        }

        function checkFilter() {
            //alert("cool");
            $("#overlay").show();
            var etop = 0;
            etop = $(window).scrollTop();

            var id = $(".cat")
            .map(function () { return $(this).attr("id"); }).get() + '';

            var checked = $(".cat")
           .map(function () { return $(this).prop("checked"); }).get() + '';

            var splitchecked = checked.split(',');
            var splitid = id.split(',');

            var checkedid = "";

            for (var i = 0; i < splitchecked.length; i++) {
                if (splitchecked[i] == "true") {
                    //checkedid = checkedid + splitid[i] + ',';
                    if(splitid[i] == "sunglass")
                    {
                        checkedid = checkedid + "1" + ',';
                    }
                    if(splitid[i] == "eyeglass")
                    {
                        checkedid = checkedid + "2" + ',';
                    }
                }
            }

            document.getElementById("<%=hdnfilter.ClientID %>").value = checkedid.slice(0, -1);
            document.getElementById("<%=currentfilter.ClientID %>").value = "filter";
            document.getElementById("<%=hdnetop.ClientID %>").value = etop;

            //  alert(document.getElementById("<%=hdnfilter.ClientID %>").value);
            //document.getElementById("<%=lnksetfilter.ClientID %>").click();
            doapplyclick("#1","");

        }

      


        function readCategory() {
            $("#overlay").show();
            document.getElementById("<%=hdncategory.ClientID %>").value = $("#<%= ddlCategory.ClientID %>").val();
        }

        function readFilter() {
            $("#overlay").show();
            document.getElementById("<%=hdnfilter.ClientID %>").value = $("#<%= ddlfiltertype.ClientID %>").val();
        }
    </script>
    <style>
        .loader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url('https://www.nywdinc.com/img/loader.gif') 50% 50% no-repeat rgba(249,249,249,0.6);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:HiddenField ID="hdnPrice" runat="server" />
    <asp:HiddenField ID="hdnetop" runat="server" />
    <asp:HiddenField ID="currentfilter" runat="server" />
    <asp:HiddenField ID="hdnbrowserwidth" runat="server" />
    <asp:HiddenField ID="hdngoto" runat="server" />
    <asp:HiddenField ID="hdnpgsize" runat="server" />
    <asp:HiddenField ID="hdnpagemode" runat="server" />
    <asp:HiddenField ID="hdnpagemode_new" runat="server" />
    <asp:HiddenField ID="hdncategory" runat="server" />
    <asp:HiddenField ID="hdncategoryname" runat="server" />
    <asp:HiddenField ID="hdnFrameMaterial" runat="server" />
    <asp:HiddenField ID="hdnFrameColor" runat="server" />
    <asp:HiddenField ID="hdnCountry" runat="server" />
    <asp:HiddenField ID="hdnGender" runat="server" />
    <asp:HiddenField ID="hdnFrameStyle" runat="server" />
    <asp:HiddenField ID="hdnlenscolor" runat="server" />
    <asp:HiddenField ID="hdnfilter" runat="server" />
    <asp:HiddenField ID="hdnMinValue" runat="server" />
    <asp:HiddenField ID="hdnMaxValue" runat="server" />
    <asp:HiddenField ID="hdneyesize" runat="server" />
    <asp:HiddenField ID="hdnsortby" runat="server" />
    <asp:HiddenField ID="hdneyeglasscount" runat="server" />
    <asp:HiddenField ID="hdnsunglasscount" runat="server" />


    <input type="hidden" id="hdnfname" value="">
    <asp:LinkButton ID="lnkpgsize" runat="server" OnClick="lnkpgsize_Click"></asp:LinkButton>
    <asp:LinkButton ID="lnksort" runat="server" OnClick="lnksort_Click"></asp:LinkButton>

    <asp:LinkButton ID="lnkgotopg" runat="server" OnClick="lnkgotopg_Click"></asp:LinkButton>
    <asp:LinkButton ID="lnkgotopg_new" runat="server" OnClick="lnkgotopgnew_Click"></asp:LinkButton>
    <asp:LinkButton ID="lnksetcat" runat="server" OnClick="lnksetcat_Click"></asp:LinkButton>
    <asp:LinkButton ID="lnksetfilter" runat="server" OnClick="lnksetfilter_Click"></asp:LinkButton>
    <asp:LinkButton ID="lnksetValues" runat="server" OnClick="lnksetValues_Click"></asp:LinkButton>
    <asp:LinkButton ID="lnksetCountry" runat="server" OnClick="lnksetCountry_Click"></asp:LinkButton>
    <asp:LinkButton ID="lnksetLensColor" runat="server" OnClick="lnksetLensColor_Click"></asp:LinkButton>
    <asp:LinkButton runat="server" ID="lnkViewCart" OnClick="lnkViewCart_Click"></asp:LinkButton>
    <asp:LinkButton runat="server" ID="lnksetFrameMaterial" OnClick="lnksetFrameMaterial_Click"></asp:LinkButton>
    <asp:LinkButton runat="server" ID="lnksetFrameColor" OnClick="lnksetFrameColor_Click"></asp:LinkButton>
    <asp:LinkButton runat="server" ID="lnksetFrameStyle" OnClick="lnksetFrameStyle_Click"></asp:LinkButton>
    <asp:DropDownList runat="server" ID="ddlframematerial" Visible="false"></asp:DropDownList>
    <asp:DropDownList runat="server" ID="ddlframecolor" Visible="false"></asp:DropDownList>
    <asp:DropDownList runat="server" ID="ddllenscolor" Visible="false"></asp:DropDownList>
    <asp:DropDownList runat="server" ID="ddlframestyle" Visible="false"></asp:DropDownList>
    <asp:DropDownList runat="server" ID="ddlCountry" Visible="false"></asp:DropDownList>
    <asp:DropDownList runat="server" ID="ddlGender" Visible="false"></asp:DropDownList>
    <%--<div id="overlay" style="display: none;">
        <img src="https://www.nywdinc.com/img/loader.gif" alt="Loading"><br>
        Loading...
    </div>--%>
    <div class="loader" id="overlay" style="display: none"></div>
    <main>
			<header class="header-shop" id="divheader" runat="server">
						<div class="breadcrumb-cont">
                             <ul class="breadcrumb">
                               <li><a href="home">Home</a></li>
                               <li class="current"><a href="#"><asp:label runat="server" ID="lblbrandname2"  /></a></li>
                             </ul>
                        </div>

						<div class="advanced-trigger">
							<a href="#0" class="fil1">Filters <asp:Label ID="lblitemcount2" runat="server" style="display:none"></asp:Label></a>
                            <a href="#0" class="fil2"><asp:Label ID="Label26" runat="server" Text="<% $Resources:Resources, FILTERS %>"></asp:Label> <asp:Label ID="lblitemcount3" runat="server"></asp:Label> PRODUCTS</a>
						</div>
						<h1>   <asp:label runat="server" ID="lblbrandname"  /></h1>
						
						<div class="selects-filter" style="display:none">
							<div class="select-content select-category"  runat="server" id="divCatogary" style="display:none" >
								<%--<span>Category: </span>--%>
                                <asp:Label ID="Label1" runat="server" Text="<% $Resources:Resources, Category %>"></asp:Label>:
							
                                      <asp:DropDownList ID="ddlfiltertype" onchange="readFilter()" CssClass="dropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlfiltertype_SelectedIndexChanged">
                                       <asp:ListItem Value="0" Text="<% $Resources:Resources, ALL %>"></asp:ListItem>
                                      <asp:ListItem Value="1" Text="<% $Resources:Resources, Sunglasses %>"></asp:ListItem>
                                      <asp:ListItem Value="2" Text="<% $Resources:Resources, Opticals1 %>"></asp:ListItem>
                                </asp:DropDownList>
                              </div>
							
							<div class="select-content select-brands" id="divcat"  runat="server" >
								<%--<span>Brands: </span>--%>
                                <asp:Label ID="Label2" runat="server" Text="<% $Resources:Resources, Brands1 %>"></asp:Label>
							
                                  <asp:DropDownList ID="ddlCategory" CssClass="dropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" onchange="readCategory()">
                                </asp:DropDownList>
                               
                             
							</div>
							
						</div>
						
					</header>
			
				<div class="main-list-shop">
					    
					<div class="list-shop-filter"><a name="0"></a>
					<div id="Div2" class="filter-cont filter-cat">
                     <a class="title-filter question"> <span id="ctl00_ContentPlaceHolder1_Label3">Filters <asp:Label ID="lblitemcount" runat="server" style="display:none"></asp:Label></span></a>
                      <div runat="server" id="divclearall">
                          <asp:Literal ID="ltlfilters" runat="server"></asp:Literal></div>
                        <%--<div class="list-advanced-search">
                          <div class="filters-prod">
                             <a href="#">Sunglasses</a>
                          </div>
                          <div class="filters-prod">
                               <a href="#">Armani</a>
                           </div>
                           <div class="filters-prod">
                               <a href="#">Black</a>
                           </div>
                           <div class="filters-prod">
                               <a href="#">Aviator</a>
                           </div>
                           <div class="filters-prod">
                               <a href="#">Italy</a>
                           </div>
                      </div>--%>
                    </div>
						<div id="Div1" class="filter-cont filter-cat"  runat="server"><%--id="catID"--%>
                            <a name="1"></a>
                            <ul class="accordion">
                                <li>
							       <a class="title-filter question active" ><asp:Label ID="Label4" runat="server" Text="<% $Resources:Resources, Category %>"></asp:Label></a><%--href="#0" style="cursor:pointer"--%>
							            <div class="main-accordion" style="height: 96px;">
                                             <asp:Literal ID="ltlFilter" runat="server"></asp:Literal>
							           </div>
                               </li>
                            </ul>
						</div>


						<div class="filter-cont filter-cat" id="divadvcat" runat="server">
                            <a name="2"></a>
                            <ul class="accordion">
                                <li>
							        <a class="title-filter question" > BRANDS</a>
							            <div class="main-accordion">
                                               <asp:Literal ID="ltlBrands" runat="server"></asp:Literal>
							            </div>
                                </li>
                            </ul>
						</div>

                        <div class="filter-cont filter-cat m" id="divframematerial" runat="server">
                            <a name="3"></a>
                                <ul class="accordion">
                                    <li>
							          <a class="title-filter question" ><asp:Label ID="Label6" runat="server" Text="<% $Resources:Resources, FrameMaterial %>"></asp:Label></a>
							            <div class="main-accordion">
                                            <asp:Literal ID="ltlFramematerial" runat="server"></asp:Literal>
							            </div>
                                        </li>
                                    </ul>
						</div>


                           <div class="filter-cont filter-cat m"  id="divFramestyle" runat="server">
                               <a name="4"></a>
                                <ul class="accordion">
                                    <li>
							         <a class="title-filter question"><asp:Label ID="Label13" runat="server" Text="<% $Resources:Resources, FrameStyle %>"></asp:Label></a>
							            <div class="main-accordion">
                                            <asp:Literal ID="ltlFramestyle" runat="server"></asp:Literal>
							            </div>
                                        </li>
                                    </ul>
						</div>

                            <div class="filter-cont filter-cat m" id="divframecolor" runat="server">
                               <a name="5"></a>
                                 <ul class="accordion">
                                    <li>
							         <a class="title-filter question"><asp:Label ID="Label14" runat="server" Text="<% $Resources:Resources, FrameColor %>"></asp:Label></a>
							            <div class="main-accordion">
                                            <asp:Literal ID="ltlFramecolor" runat="server"></asp:Literal>
							            </div>
                                        </li>
                                    </ul>
						</div>

                         <div class="filter-cont filter-cat m" id="divlenscolor" runat="server">
                             <a name="6"></a>   
                             <ul class="accordion">
                                    <li>
							         <a class="title-filter question"><asp:Label ID="Label15" runat="server" Text="<% $Resources:Resources, LensColor %>"></asp:Label></a>
							            <div class="main-accordion">
                                            <asp:Literal ID="ltllenscolor" runat="server"></asp:Literal>
							            </div>
                                        </li>
                                    </ul>
						</div>

                        <div class="filter-cont filter-cat m" id="divcountry" runat="server">
                            <a name="7"></a>
                                <ul class="accordion">
                                    <li>
							         <a class="title-filter question"><asp:Label ID="Label16" runat="server" Text="<% $Resources:Resources, Country %>"></asp:Label></a>
							            <div class="main-accordion">
                                            <asp:Literal ID="ltlCountry" runat="server"></asp:Literal>
							            </div>
                                        </li>
                                    </ul>
						</div>
                        <div class="filter-cont filter-cat m" id="divGender" runat="server">
                            <a name="8"></a>
                                <ul class="accordion">
                                    <li>
							          <a class="title-filter question"><asp:Label ID="Label7" runat="server" Text="<% $Resources:Resources, Gender %>"></asp:Label></a>
							            <div class="main-accordion">
                                            <asp:Literal ID="ltlGender" runat="server"></asp:Literal>
							            </div>
                                        </li>
                                    </ul>
						</div>

                        <div class="filter-cont filter-cat filter-size-eye m" id="divEyesize" runat="server">
                            <a name="9"></a>
                                <ul class="accordion">
                                    <li>
							          <a class="title-filter question"><%--<asp:Label ID="Label27" runat="server" Text="<% $Resources:Resources, Gender %>"></asp:Label>--%>EYE SIZE</a>
							            <div class="main-accordion main-accordion-size-eye">
                                            <div class="select-size-eye">
                                                <div class="select-content items-number-show select-items">
                                                    <asp:DropDownList ID="ddleyesize" CssClass="dropdown" runat="server" onchange="checkeyesize()"></asp:DropDownList>
                                                    
                                                </div>
                                            </div>
                                            <figure class="size-eye-figure">
                                                <img src="img/glasses-size-icon.svg" />
                                            </figure>
							            </div>
                                        </li>
                                    </ul>
						</div>

                         <div class="filter-cont filter-price cart-price m">
                             <a name="10"></a>
                             <div class="main-filter-price">
						<a class="title-filter" href="#0"><asp:Label ID="Label5" runat="server" Text="<% $Resources:Resources, PriceRange %>"></asp:Label></a>
							    <div class="filter-main filter-main-price">
								
								    <div class="box">

								        <div class="values">
								            <div>$<span id="first"></span></div> <div>$<span id="second"></span></div>
								        </div>
								   
								
								        <div class="slider" data-value-0="#first" data-value-1="#second" data-range="#third"></div>
								
								    </div>
								
							    </div>
							</div>
						</div>
						
                        	
				

                         	<%--<div class="filter-cont filter-cat" id="divframecolor" runat="server">
							<a class="title-filter" href="#0">Frame Color</a>
							<div class="filter-main filter-main-cat">
                                 <asp:Literal ID="ltlFramecolor" runat="server"></asp:Literal>
							</div>
						</div>--%>

                       <%-- <asp:Button  runat="server" id="btnApply"  class="btn apply-btn" onclick="btnApply_Click"  Text="<% $Resources:Resources, Apply %>"></asp:Button>--%>

            <div class="content-apply-filter">
                     <div class="apply-filter">    	
                        <input type="submit" name="btnApply" style="display:none;" value="Cancel Filters" id="btnCancelFilter" class="btn cancel-filter apply-btn" />
                         <asp:Button  runat="server" style="display:none;" id="btnApply"  class="btn apply-btn whichbtn" onclick="btnApply_Click"  Text="Apply Filters"></asp:Button>
                     </div>  
                  </div>
                  <div id="mobile" class="content-apply-filter-mobile">
                     <div class="apply-filter"> 
                           	
                        <input type="submit" name="btnApply" value="Cancel" id="btnCancelFilter1" style="display:none;" class="btn cancel-filter apply-btn" />
                        
                         <asp:Button   style="" runat="server" id="btnApply1"  class="btn apply-btn whichbtn" onclick="btnApply_Click"  Text="Apply"></asp:Button>
                        
                     </div>  
                  </div> 

                       <%-- <asp:LinkButton runat="server" ID="LinkButton1" OnClick="lnksetFrameStyle_Click"></asp:LinkButton>--%>
                         
                      
                     <%--  <a href="#0" class="btn apply-btn">Apply</a>--%>
						
						
					</div>

                      <div class="list-product-content wrapper" Style="text-align: center; clear: both;" id="divmsg" runat="server">
                    <asp:Label runat="server" ID="lblrecordmsg" ></asp:Label>
                    </div>

					<div class="list-product-content wrapper" id="divItems" runat="server" >
						<div class="header-list-product" >
                            <div class="info-number-item"><em><b><asp:Label ID="lblitemcount1" runat="server"></asp:Label></b> Items</em></div>
							<div class="selects-filter" >
								<div class="select-content items-number-show select-items">
								<%--	<span><asp:Label ID="Label9" runat="server" Text="<% $Resources:Resources, Items1 %>"></asp:Label>:<em> <asp:Label ID="recordcount" runat="server" Text=""></asp:Label></em> </span>--%>
									<span><span id="ctl00_ContentPlaceHolder1_Label9">Sort</span>: </span>
                                    <asp:DropDownList CssClass="dropdown" ID="ddlpgsort" runat="server"  onchange="gotosort()">
                                                     <asp:ListItem Text="Featured" Value="Featured"></asp:ListItem>
                                           <asp:ListItem Text="Bestsellers" Value="Bestsellers"></asp:ListItem>
                                           <asp:ListItem Text="Price Low to High" Value="Price Low to High"></asp:ListItem>
                                           <asp:ListItem Text="Price High to Low" Value="Price High to Low"></asp:ListItem>
                                     </asp:DropDownList>
                                     <%--<select name="ddlpgsort" id="ddlpgsort" class="dropdown" onchange="gotopg()">
                                       <option selected="selected" value="25">Featured</option>
                                       <option value="50">Bestsellers</option>
                                       <option value="75">Price Low to High</option>
                                       <option value="100">Price High to Low</option>
                                    </select>--%>
								</div>
							<div class="select-content items-number-show" style="display:none" >
									<span><asp:Label ID="Label9" runat="server" Text="<% $Resources:Resources, Items1 %>"></asp:Label>:<em> <asp:Label ID="recordcount" runat="server" Text=""></asp:Label></em> </span>
									
								</div>
								<div class="select-content select-items">
									<span><asp:Label ID="Label10" runat="server" Text="<% $Resources:Resources, Itemperpage %>"></asp:Label>: </span>
                                     <asp:DropDownList CssClass="dropdown" ID="ddlpgoptb" runat="server"  onchange="gotopg()">
                                               <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                           <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                           <asp:ListItem Text="75" Value="75"></asp:ListItem>
                                           <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                     </asp:DropDownList>
								
								</div>
							</div>
						</div>
						<!-- ITEM PRODUCT -->	
                              <asp:Literal ID="ltlproductdata" runat="server"></asp:Literal>
                            <asp:Literal ID="ltlproductdataog" runat="server" Visible="false" >
                        <div class="item-product">
                           <%-- <span class="sale">SALE</span>--%>
                            [newstockid]
                            <figure class="zoom" >
 									<img src="[imgurl]" alt="product-image">
									<span class="icon-zoom"></span>
								
							</figure>

							<div class="item-product-main">
                                
								<span class="brands">[brand]</span>
                                <a href="javascript:void(0)" id="[pro]" onclick="gotoproductpage([pro]);" style="color:black;"> 
								<h3>[product]</h3></a>
								<ul class="description">
									<li><em>[colorname]</em></li>
									<li>[ColorCode1] :  [colorcode]</li>
									<li>[Size1] : [size]</li>
									<li>UPC : [UPC]</li>

								</ul>
                                 
								<div class="qty-main">
									<span class="qty">[Qty] [instock]</span>
									<span class="in-cart on" id="lbcq[pro]">[cartqty]</span>
                                   
								</div>	
                                
							</div>
							
							<div class="cart-price" style="height:155px">
								<span class="price"><em class="best-price">[mprice]</em> [price]</span>
								 <div class="cont-cart">
                                        <div id="divbaloon[pro]" class="baloon" style="display:none">[maxqtyavail] [actualinstock]</div>         
									<div class="number" data-sku="[pro]" [style] >
                                       
										<span class="minus"><em>-</em></span>
                                        <input size="2" type="text" autocomplete="off"  onkeyup="changevalue([pro])" class="cart_quantity_input" value="[qty]" name="quantity_1_0_0_11" id="quantity_1_0_0_11[pro]" onclick="$(this).select();" onblur="$('#divbaloon[pro]').hide()" />
										<span class="plus" onblur="$('#divbaloon[pro]').hide()"><em>+</em></span>
                                      
                                                    <input type="hidden" value="1" name="quantity_5_30_0_0_hidden">
                                                    <input type="hidden" value=[actualinstock] id="quantity_1_0_0_11_hidden[pro]" name="quantity_1_0_0_11_hidden">
                                                    <input type="hidden" value=[incart] id="qtyincart[pro]" name="qtyincart">  
                                                    <input type="hidden" value=[itemcount] id="itemcount[pro]" name="itemcount">  
                                         <input type='checkbox' value='1' class='chkAllProducts' style="display:none;"  id='chk_[pro]'>                                                
									</div>

                                
									 [cartbutton]<%--<a class="btn" id="btnaddcart[pro]" style="display:none" href="#">Add to cart</a>--%>
								</div>
                                 
                  
							</div>
                                
						</div>
                                 </asp:Literal>
						<!-- ?ITEM PRODUCT -->	
                                 
						<div class="footer-list">
							<div class="row" runat="server" id="divrow">
								<div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
									<a href="javascript:void(0)" class="btn empty" onclick="downloadxls()" id="btndownloadfeed"  visible="false"  runat="server"><asp:Label ID="Label11" runat="server" Text="<% $Resources:Resources, Downloadfeed %>"></asp:Label></a>
    							</div>

                                <asp:HiddenField ID="lblstartpg" Value="1" runat="server" />
    					
                                <div id="pagingDiv" runat="server" class="col-xs-12 col-sm-4 col-md-4 col-lg-4 pagination"></div>
                                	

    							<div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
									<a href="#" class="btn" id="btnaddcart" onclick="add2cart_new()" visible="false"  runat="server"><asp:Label ID="Label12" runat="server" Text="<% $Resources:Resources, Addalltocart %>"></asp:Label></a><br />

                                    <asp:Label runat="server" ID="lblMessage" Style="text-align: center; clear: both;"></asp:Label>
    							</div>
							</div>
                             <!-- others products -->
                  <div class="others-p">
                     <h3><asp:Label ID="Label3" runat="server" Text="<% $Resources:Resources, BestSeller %>"></asp:Label></h3>
                     <!-- Swiper -->
                       <div class="swiper-container-others">
                         <div class="swiper-wrapper">
                            <asp:Literal runat="server" ID="ltlrecommend"></asp:Literal>
                          <%-- <div class="swiper-slide">
                              
                              <div class="other-item">
                                 <figure>
                                    <a href="javascript:void(0)" id="508528" onclick="gotoproductpage(508528);" style="color:black;">
                                       <img src="https://www.nywdinc.com/pictures/508528/sunglasses-shop-carrera-5047s-matteblack(k1browngoldsplens)-1.jpg" alt="product-image" height="183">
                                    </a>
                                 </figure>
                                 <div class="text-others-p">
                                    <span class="brands">CARRERA</span> 
                                    <a href="javascript:void(0)" id="A1" onclick="gotoproductpage(508528);" style="color:black;"><h3>5047/S</h3></a>
                                    <ul class="description">
                                       <li><em>MATTE BLACK (K1) / BROWN GOLD SP</em></li>
                                       <li><span>Color Code :  0003 00</li>
                                       <li>Size : 56X17X135</li>
                                                <li>UPC : 716736032191</li>
                                    </ul>
                                 </div>
                              </div>
                           </div>
                           <div class="swiper-slide">
                              <div class="other-item">
                                 <figure>
                                    <a href="javascript:void(0)" id="493157" onclick="gotoproductpage(493157);" style="color:black;">
                                       <img src="https://www.nywdinc.com/pictures/493157/designer-glasses-frames-carrera-4404v-mattehavanaclear-1.jpg" alt="product-image" height="183">
                                    </a>
                                 </figure>
                                 <div class="text-others-p">
                                    <span class="brands">CARRERA</span> 
                                    <a href="javascript:void(0)" id="A2" onclick="gotoproductpage(493157);" style="color:black;"><h3>4404/V</h3></a>
                                    <ul class="description">
                                       <li><em>MATTE HAVANA / CLEAR LENS</em></li>
                                       <li><span>Color Code : 0N9P 00</li>
                                       <li>Size : 56X16X140</li>
                                       <li>UPC : 716737112533</li>
                                    </ul>
                                 </div>
                              </div>
                           </div>
                           <div class="swiper-slide">
                              <div class="other-item">
                                 <figure>
                                    <a href="javascript:void(0)" id="543959" onclick="gotoproductpage(543959);" style="color:black;">
                                       <img src="https://www.nywdinc.com/pictures/543959/sunglasses-shop-carrera-218s-havanagreengreen-1.jpg" alt="product-image" height="183">
                                    </a>
                                 </figure>
                                 <div class="text-others-p">
                                    <span class="brands">CARRERA</span> 
                                    <a href="javascript:void(0)" id="A3" onclick="gotoproductpage(543959);" style="color:black;"><h3>218/S</h3></a>
                                    <ul class="description">
                                       <li><em>BLACK BLUE / BLUE</em></li>
                                       <li><span>Color Code : 0D51 KU</li>
                                       <li>Size : 58X16X145</li>
                                       <li>UPC : 716736205403</li>
                                    </ul>
                                 </div>
                              </div>
                           </div>
                           <div class="swiper-slide">
                              
                              <div class="other-item">
                                 <figure>
                                    <a href="javascript:void(0)" id="A4" onclick="gotoproductpage(508528);" style="color:black;">
                                       <img src="https://www.nywdinc.com/pictures/508528/sunglasses-shop-carrera-5047s-matteblack(k1browngoldsplens)-1.jpg" alt="product-image" height="183">
                                    </a>
                                 </figure>
                                 <div class="text-others-p">
                                    <span class="brands">CARRERA</span> 
                                    <a href="javascript:void(0)" id="A5" onclick="gotoproductpage(508528);" style="color:black;"><h3>5047/S</h3></a>
                                    <ul class="description">
                                       <li><em>MATTE BLACK (K1) / BROWN GOLD SP</em></li>
                                       <li><span>Color Code :  0003 00</li>
                                       <li>Size : 56X17X135</li>
                                                <li>UPC : 716736032191</li>
                                    </ul>
                                 </div>
                              </div>
                           </div>
                           <div class="swiper-slide">
                              <div class="other-item">
                                 <figure>
                                    <a href="javascript:void(0)" id="A6" onclick="gotoproductpage(493157);" style="color:black;">
                                       <img src="https://www.nywdinc.com/pictures/493157/designer-glasses-frames-carrera-4404v-mattehavanaclear-1.jpg" alt="product-image" height="183">
                                    </a>
                                 </figure>
                                 <div class="text-others-p">
                                    <span class="brands">CARRERA</span> 
                                    <a href="javascript:void(0)" id="A7" onclick="gotoproductpage(493157);" style="color:black;"><h3>4404/V</h3></a>
                                    <ul class="description">
                                       <li><em>MATTE HAVANA / CLEAR LENS</em></li>
                                       <li><span>Color Code : 0N9P 00</li>
                                       <li>Size : 56X16X140</li>
                                       <li>UPC : 716737112533</li>
                                    </ul>
                                 </div>
                              </div>
                           </div>
                           <div class="swiper-slide">
                              <div class="other-item">
                                 <figure>
                                    <a href="javascript:void(0)" id="A8" onclick="gotoproductpage(543959);" style="color:black;">
                                       <img src="https://www.nywdinc.com/pictures/543959/sunglasses-shop-carrera-218s-havanagreengreen-1.jpg" alt="product-image" height="183">
                                    </a>
                                 </figure>
                                 <div class="text-others-p">
                                    <span class="brands">CARRERA</span> 
                                    <a href="javascript:void(0)" id="A9" onclick="gotoproductpage(543959);" style="color:black;"><h3>218/S</h3></a>
                                    <ul class="description">
                                       <li><em>BLACK BLUE / BLUE</em></li>
                                       <li><span>Color Code : 0D51 KU</li>
                                       <li>Size : 58X16X145</li>
                                       <li>UPC : 716736205403</li>
                                    </ul>
                                 </div>
                              </div>
                           </div>--%>

                         </div>
                         <!-- Add Pagination -->
                         <div class="swiper-pagination"></div>
                         <!-- Add Arrows -->
                          <div class="swiper-button-next swiper-button-black "></div>
                          <div class="swiper-button-prev swiper-button-black "></div>
                       </div>
                  </div>	
						
					</div>
                           
						
				</div>

				
			
		</main>

    <!-- MODAL -->
    <div id="modal-custom-container1">
        <div class="modal-background">
            <a href="#0" class="close-modalCustom1" onclick=" $('#modal-custom-container1').addClass('out');  $('body').removeClass('modal-active');">
                <img src="img/close-modal.svg" alt="close-modal"></a>
            <div class="modal modal-delete-card">
                <h3>
                    <asp:Label ID="Label18" runat="server" Text="<% $Resources:Resources, Select %>"></asp:Label></h3>
                <p>
                    <asp:Label ID="Label17" runat="server" Text="<% $Resources:Resources, Pleaseselectatleastoneproduct %>"></asp:Label>
                </p>

                <%--<a href="Cart.aspx" class="btn">--%>
                <a href="" class="btn modalCustom1">OK</a>
            </div>
        </div>
    </div>
    <!-- /MODAL -->

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Modal" runat="Server">
    <!-- MODAL -->
    <div id="modal-container3">
        <div class="modal-background">
            <a href="#0" class="close-modal3">
                <img src="img/close-modal.svg" alt="close-modal"></a>
            <div class="modal modal-delete-card modal-feed">
                <h3>
                    <asp:Label ID="Label19" runat="server" Text="<% $Resources:Resources, Downloadfeed %>"></asp:Label></h3>
                <p id="exceltxt" runat="server">
                    <asp:Label ID="Label20" runat="server" Text="<% $Resources:Resources, Generatingexcel %>"></asp:Label>
                </p>
                <div class="progress">
                    <div id="doprogress" class="progress-value2"></div>
                </div>
                <p style="display: none" class="success">
                    <asp:Label ID="Label21" runat="server" Text="<% $Resources:Resources, Excelfile %>"></asp:Label>
                </p>
                <a href="#0" class="btn" style="display: none" onclick="downloadxls1()">
                    <asp:Label ID="Label22" runat="server" Text="<% $Resources:Resources, Download
 %>"></asp:Label></a>
            </div>
        </div>
    </div>
    <!-- /MODAL -->
    <!-- MODAL -->
    <div id="modal-custom-container31">
        <div class="modal-background">
            <a href="#0" class="close-modalpop" onclick=" $('#modal-custom-container31').addClass('out');  $('body').removeClass('modal-active');">
                <img src="img/close-modal.svg" alt="close-modal"></a>
            <div class="modal modal-delete-card">
                <h3>
                    <asp:Label ID="Label24" runat="server" Text="<% $Resources:Resources, Oops %>"></asp:Label></h3>
                <p>
                    <asp:Label ID="Label23" runat="server" Text="<% $Resources:Resources, areyousure %>"></asp:Label>
                </p>
                <a href="#" class="btn empty" onclick="$('#modal-custom-container31').addClass('out');  $('body').removeClass('modal-active');">No</a>
                <a href="javascript:void(0)" id="cyes" class="btn">
                    <asp:Label ID="Label25" runat="server" Text="<% $Resources:Resources, Yes %>"></asp:Label></a>
            </div>
        </div>
    </div>
    <!-- /MODAL -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="Server">
    <!-- Initialize Swiper -->
    <script>
        var swiper = new Swiper('.swiper-container-others', {
            slidesPerView: 4,
            spaceBetween: 5,
            pagination: {
                el: '.swiper-pagination',
                clickable: true,
            },
            navigation: {
                nextEl: '.swiper-button-next',
                prevEl: '.swiper-button-prev',
            },
            breakpoints: {
                640: {
                    slidesPerView: 1,
                    spaceBetween: 20,
                },
                768: {
                    slidesPerView: 3,
                    spaceBetween: 40,
                },
                1024: {
                    slidesPerView: 4,
                    spaceBetween: 50,
                },
            }
        });
    </script>

    <script>
        $('.slider').each(function(e) {

            var slider = $(this),
                width = slider.width(),
                handle,
                handleObj;

            let svg = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
            svg.setAttribute('viewBox', '0 0 ' + width + ' 83');

            slider.html(svg);
            slider.append($('<div>').addClass('active').html(svg.cloneNode(true)));

            slider.slider({
                range: true,
                values: [<%Response.Write(minVal);%>, <%Response.Write(maxVal);%>],
                min: 1,
                step: 5,
                minRange: 1,
                max: 1000,
                create(event, ui) {

            slider.find('.ui-slider-handle').append($('<div />'));

            $(slider.data('value-0')).html(slider.slider('values', 0).toString().replace(/\B(?=(\d{3})+(?!\d))/g, '&thinsp;'));
            $(slider.data('value-1')).html(slider.slider('values', 1).toString().replace(/\B(?=(\d{3})+(?!\d))/g, '&thinsp;'));
            $(slider.data('range')).html((slider.slider('values', 1) - slider.slider('values', 0)).toString().replace(/\B(?=(\d{3})+(?!\d))/g, '&thinsp;'));

            setCSSVars(slider);

        },
            slide: function (event, ui) {
                let min = slider.slider('option', 'min'),
                    minRange = slider.slider('option', 'minRange'),
                    max = slider.slider('option', 'max');

                if(ui.handleIndex == 0) {
                    if((ui.values[0] + minRange) >= ui.values[1]) {
                        slider.slider('values', 1, ui.values[0] + minRange);
                    }
                    if(ui.values[0] > max - minRange) {
                        return false;
                    }
                } else if(ui.handleIndex == 1) {
                   

                    if((ui.values[1] - minRange) <= ui.values[0]) {
                        slider.slider('values', 0, ui.values[1] - minRange);
                    }
                    if(ui.values[1] < min + minRange) {
                        return false;
                    }
                }
                //alert(ui.values[0]);
                $("#<%=hdnMinValue.ClientID %>").val(ui.values[0]);
                $("#<%=hdnMaxValue.ClientID %>").val(ui.values[1]);

                $(slider.data('value-0')).html(ui.values[0].toString().replace(/\B(?=(\d{3})+(?!\d))/g, '&thinsp;'));
                $(slider.data('value-1')).html(ui.values[1].toString().replace(/\B(?=(\d{3})+(?!\d))/g, '&thinsp;'));
                $(slider.data('range')).html((slider.slider('values', 1) - slider.slider('values', 0)).toString().replace(/\B(?=(\d{3})+(?!\d))/g, '&thinsp;'));

                setCSSVars(slider);

            },

            change: function (event, ui) {
                setCSSVars(slider);
                doapplyclick("#10","");
                //  alert("ok");
            }
            });

            var svgPath = new Proxy({
                x: null,
                y: null,
                b: null,
                a: null
            }, {
                set(target, key, value) {
                    target[key] = value;
                    if(target.x !== null && target.y !== null && target.b !== null && target.a !== null) {
                        slider.find('svg').html(getPath([target.x, target.y], target.b, target.a, width));
                    }
                    return true;
                },
                get(target, key) {
                    return target[key];
                }
                });

            svgPath.x = width / 2;
            svgPath.y = 42;
            svgPath.b = 0;
            svgPath.a = width;

            $(document).on('mousemove touchmove', e => {
                if(handle) {

                    let laziness = 4,
                        max = 24,
                        edge = 52,
                        other = handleObj.eq(handle.data('index') == 0 ? 1 : 0),
                        currentLeft = handle.position().left,
                        otherLeft = other.position().left,
                        handleWidth = handle.outerWidth(),
                        handleHalf = handleWidth / 2,
                        y = e.pageY - handle.offset().top - handle.outerHeight() / 2,
                        moveY = (y - laziness >= 0) ? y - laziness : (y + laziness <= 0) ? y + laziness : 0,
                        modify = 1;

            moveY = (moveY > max) ? max : (moveY < -max) ? -max : moveY;
            modify = handle.data('index') == 0 ? ((currentLeft + handleHalf <= edge ? (currentLeft + handleHalf) / edge : 1) * (otherLeft - currentLeft - handleWidth <= edge ? (otherLeft - currentLeft - handleWidth) / edge : 1)) : ((currentLeft - (otherLeft + handleHalf * 2) <= edge ? (currentLeft - (otherLeft + handleWidth)) / edge : 1) * (slider.outerWidth() - (currentLeft + handleHalf) <= edge ? (slider.outerWidth() - (currentLeft + handleHalf)) / edge : 1));
            modify = modify > 1 ? 1 : modify < 0 ? 0 : modify;

            if(handle.data('index') == 0) {
                svgPath.b = currentLeft / 2  * modify;
                svgPath.a = otherLeft;
            } else {
                svgPath.b = otherLeft + handleHalf;
                svgPath.a = (slider.outerWidth() - currentLeft) / 2 + currentLeft + handleHalf + ((slider.outerWidth() - currentLeft) / 2) * (1 - modify);
            }

            svgPath.x = currentLeft + handleHalf;
            svgPath.y = moveY * modify + 42;

            handle.css('--y', moveY * modify);

            }
            });

            });

            function getPoint(point, i, a, smoothing) {
                let cp = (current, previous, next, reverse) => {
                    let p = previous || current,
                    n = next || current,
                    o = {
                        length: Math.sqrt(Math.pow(n[0] - p[0], 2) + Math.pow(n[1] - p[1], 2)),
                        angle: Math.atan2(n[1] - p[1], n[0] - p[0])
                    },
                    angle = o.angle + (reverse ? Math.PI : 0),
                    length = o.length * smoothing;
                return [current[0] + Math.cos(angle) * length, current[1] + Math.sin(angle) * length];
            },
        cps = cp(a[i - 1], a[i - 2], point, false),
        cpe = cp(point, a[i - 1], a[i + 1], true);
            return `C ${cps[0]},${cps[1]} ${cpe[0]},${cpe[1]} ${point[0]},${point[1]}`;
            }

            function getPath(update, before, after, width) {
                let smoothing = .16,
                    points = [
                        [0, 42],
                        [before <= 0 ? 0 : before, 42],
                        update,
                        [after >= width ? width : after, 42],
                        [width, 42]
                    ],
                    d = points.reduce((acc, point, i, a) => i === 0 ? `M ${point[0]},${point[1]}` : `${acc} ${getPoint(point, i, a, smoothing)}`, '');
            return `<path d="${d}" />`;
            }

            function setCSSVars(slider) {
                let handle = slider.find('.ui-slider-handle');
                slider.css({
                    '--l': handle.eq(0).position().left + handle.eq(0).outerWidth() / 2,
                    '--r': slider.outerWidth() - (handle.eq(1).position().left + handle.eq(1).outerWidth() / 2)
                });
            }
		
	</script>

    <script>

        function doactive(s)
        {
            var sp = s.split('#');
            if(sp.length > 0)
            {
                return sp[1];
            }
            else{
                return 0;
            }
        }

        function chkboxchecked(obj)
        {
            //  obj = "frame";
            var i = "";
            if(obj != "dropdown")
            {
                $('.'+obj).each(function(a) {
                    // alert($(this).prop("checked"));
                    if($(this).prop("checked") == true)
                    {
                        i = "1";
                        return false;
                    }
                });
            }
            else
            {
                //alert($("#<%=ddleyesize.ClientID%>").val());
                if($("#<%=ddleyesize.ClientID%>").val() != "0" && $("#<%=ddleyesize.ClientID%>").val() != "" && $("#<%=ddleyesize.ClientID%>").val() != "Select")
                {
                    i = "1";
                }
            }

            return i;
        }
       
        (function ($) {
            var etop = document.getElementById("<%=hdnetop.ClientID %>").value;
            $("html, body").scrollTop(etop);

            //$('.accordion > li:eq(0) a').addClass('active').next().slideDown();
            //$('.accordion > li:eq(1) a').addClass('active').next().slideDown();
            //$('.accordion > li:eq(2) a').addClass('active').next().slideDown();
            //$('.accordion > li:eq(3) a').addClass('active').next().slideDown();
            //$('.accordion > li:eq(4) a').addClass('active').next().slideDown();
            //$('.accordion > li:eq(5) a').addClass('active').next().slideDown();
            //$('.accordion > li:eq(6) a').addClass('active').next().slideDown();
            //$('.accordion > li:eq(7) a').addClass('active').next().slideDown();
            //$('.accordion > li:eq(8) a').addClass('active').next().slideDown();
            //            alert($(location).attr("href"));
            // $('.accordion > li:eq(0) a').addClass('active').next().slideDown();
            $('.accordion > li:eq(0) a').addClass('active').next().slideDown();
            // alert(chkboxchecked("frame"));
            if(chkboxchecked("frame") == "1")
            {
                $('.accordion > li:eq(1) a').addClass('active').next().slideDown();
            }
            else
            {
                $('.accordion > li:eq(1) a').next().slideUp();
            }

            if(chkboxchecked("fstyle") == "1")
            {
                $('.accordion > li:eq(2) a').addClass('active').next().slideDown();
            }
            else
            {
                $('.accordion > li:eq(2) a').next().slideUp();
            }

            if(chkboxchecked("framec") == "1")
            {
                $('.accordion > li:eq(3) a').addClass('active').next().slideDown();
            }
            else
            {
                $('.accordion > li:eq(3) a').next().slideUp();
            }

            if(chkboxchecked("lens") == "1")
            {
                $('.accordion > li:eq(4) a').addClass('active').next().slideDown();
            }
            else
            {
                $('.accordion > li:eq(4) a').next().slideUp();
            }

            if(chkboxchecked("country") == "1")
            {
                $('.accordion > li:eq(5) a').addClass('active').next().slideDown();
            }
            else
            {
                $('.accordion > li:eq(5) a').next().slideUp();
            }

            if(chkboxchecked("gender") == "1")
            {
                $('.accordion > li:eq(6) a').addClass('active').next().slideDown();
            }
            else
            {
                $('.accordion > li:eq(6) a').next().slideUp();
            }

            if(chkboxchecked("dropdown") == "1")
            {
                $('.accordion > li:eq(7) a').addClass('active').next().slideDown();
            }
            else
            {
                $('.accordion > li:eq(7) a').next().slideUp();
            }

            $('.accordion a').click(function (j) {
                var dropDown = $(this).closest('li').find('.main-accordion');

                $(this).closest('.accordion').find('.main-accordion').not(dropDown).slideUp();

                if ($(this).hasClass('active')) {
                    $(this).removeClass('active');
                } else {
                    $(this).closest('.accordion').find('a.active').removeClass('active');
                    $(this).addClass('active');
                }

                dropDown.stop(false, true).slideToggle();

                j.preventDefault();
            });
        })(jQuery);
    </script>
</asp:Content>
