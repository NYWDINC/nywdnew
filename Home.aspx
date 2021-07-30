<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Shop_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function openLightbox() {
            //  document.getElementById('Lightbox').style.display = 'block';
            //             document.location.href = "https://www.nywdinc.com/Clearance-sale-0-1-25";
            document.location.href = "https://www.nywdinc.com/brand-Roberto%20Cavalli-19-1-0-19-25";
        }
        function closeLightbox() {
            document.getElementById('Lightbox').style.display = 'none';
        }
        window.onkeyup = function (event) {
            if (event.keyCode == 27) {
                document.getElementById('Lightbox').style.display = 'none';
            }
        }
    </script>
    <style type="text/css">
        /* Lightbox */
        .dn {
            display: none !important;
        }

        @media only screen and (max-width: 359px) {
            #b359 {
                display: block !important;
            }

            #b539 {
                display: none !important;
            }

            #b1024 {
                display: none !important;
            }

            #bmax {
                display: none !important;
            }
        }

        @media only screen and (min-width: 360px) and (max-width: 539px) {
            #b359 {
                display: none !important;
            }

            #b539 {
                display: block !important;
            }

            #b1024 {
                display: none !important;
            }

            #bmax {
                display: none !important;
            }
        }

        @media only screen and (min-width: 540px) and (max-width: 1024px) {
            #b359 {
                display: none !important;
            }

            #b539 {
                display: none !important;
            }

            #b1024 {
                display: block !important;
            }

            #bmax {
                display: none !important;
            }
        }

        @media only screen and (min-width: 1025px) {
            #b359 {
                display: none !important;
            }

            #b539 {
                display: none !important;
            }

            #b1024 {
                display: none !important;
            }

            #bmax {
                display: block !important;
            }
        }



        .sp-lightbox {
            position: fixed;
            top: 0;
            left: 0;
            height: 100%;
            width: 100%;
            background: rgb(0, 0, 0);
            background: rgba(0, 0, 0, .9);
            z-index: 500;
            display: none;
            cursor: pointer;
            z-index: 99999;
        }

            .sp-lightbox img {
                position: absolute;
                margin: auto;
                top: 0;
                bottom: 0;
                left: 0;
                right: 0;
                max-width: 90%;
                max-height: 90%;
                border: none !important;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="wrapper">
        <div class="sp-lightbox" style="display: none" id="Lightbox" onclick="closeLightbox()">

            <img src="img/<%=POP_pup %>.png" />
        </div>

        <div class="row main-shop-home">

            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-7 ">
                <!-- Swiper -->
                <div class="swiper-container">
                    <div class="swiper-wrapper">

                        <div runat="server" id="divbanner4" class="swiper-slide">
                            <figure>
                                <img id="b359" src="img/<%=BANNER_280_359 %>.jpeg?j=3" alt="Banner-slider-4" class="dn" onclick="openLightbox();" style="cursor: pointer; width: 100%;" />
                                <img id="b539" src="img/<%=BANNER_360_539 %>.jpeg?j=3" alt="Banner-slider-4" class="dn" onclick="openLightbox();" style="cursor: pointer; width: 100%;" />
                                <img id="b1024" src="img/<%=BANNER_540_1024 %>.jpeg?j=3" alt="Banner-slider-4" class="dn" onclick="openLightbox();" style="cursor: pointer; width: 100%;" />
                                <img id="bmax" src="img/<%=bannerpromo %>.jpg?j=3" alt="Banner-slider-4" class="dn" onclick="openLightbox();" style="cursor: pointer; width: 100%;" />
                            </figure>
                            <div class="text-slider">
                                <%-- <h3><asp:Label ID="Label10" runat="server" Text="<% $Resources:Resources, FreeShipping %>"></asp:Label> </h3>
								      <p><asp:Label ID="Label11" runat="server" Text="<% $Resources:Resources, btext1 %>"></asp:Label></p>--%>
                            </div>


                        </div>

                        <div class="swiper-slide" runat="server" id="divbanner2">
                            
                            <figure>
                                <a href="#modal-opened" id="modal-closed">
                                    <img src="img/Crypto_banner.jpg" border="0" alt="Banner-slider-1" style="cursor: pointer;">
                                </a>
                            </figure>
                            <a href="#modal-opened" id="modal-closed2">
                            <div class="text-slider">
                                
                                    <h3>
                                        <asp:Label ID="lblbannerc1" runat="server" Text="<% $Resources:Resources, cryptobannertxt1 %>"></asp:Label>
                                          </h3>
                                    <p><asp:Label ID="Label9" runat="server" Text="<% $Resources:Resources, cryptobannertxt2 %>"></asp:Label> </p>
                                
                                <div class="link-1 btn empty white-btn" ><asp:Label ID="Label10" runat="server" Text="<% $Resources:Resources, Discovermore %>"></asp:Label></div>
                            </div></a>
                            
                        </div>
                        <div class="swiper-slide" runat="server" id="divbanner5">
                            <figure>
                                <a href="referral">
                                    <img src="img/banner-referral-home.jpg" border="0" alt="Banner-slider-1" style="cursor: pointer;">
                                </a>
                            </figure>
                            <div class="text-slider text-black">
                                <a href="referral" style="color: white; text-decoration: none">
                                    <h3>
                                        <asp:Label ID="Label3" runat="server" Text="<% $Resources:Resources, btext2 %>"></asp:Label>
                                    </h3>
                                    <p>
                                        <asp:Label ID="Label4" runat="server" Text="<% $Resources:Resources, btext3 %>"></asp:Label>
                                    </p>
                                </a>
                            </div>

                        </div>
                        <div class="swiper-slide" runat="server" style="display: none" id="divbanner3">

                            <figure>
                                <a href="referral">
                                    <img src="img/Banner_Referral-2.jpg" border="0" alt="Banner-slider-1" style="cursor: pointer;">
                                </a>
                            </figure>
                            <div class="text-slider">
                                <a href="referral" style="color: white; text-decoration: none">
                                    <h3 >
                                        <asp:Label ID="Label5" runat="server" Text="<% $Resources:Resources, btext4 %>"></asp:Label>
                                    </h3>
                                    <p>
                                        <asp:Label ID="Label6" runat="server" Text="<% $Resources:Resources, btext5 %>"></asp:Label>
                                    </p>
                                </a>
                            </div>

                        </div>

                        <div runat="server" id="divbanner1" class="swiper-slide">
                            <figure>
                                <img src="img/Banner-slider-1.jpg" alt="Banner-slider-1" style="cursor: pointer">
                            </figure>
                            <div class="text-slider">
                                <h3>
                                    <asp:Label ID="Label1" runat="server" Text="<% $Resources:Resources, FreeShipping %>"></asp:Label>
                                </h3>
                                <p>
                                    <asp:Label ID="Label2" runat="server" Text="<% $Resources:Resources, btext1 %>"></asp:Label>
                                </p>
                                <p style="font-size: 9px">* Valid for Domestic Ground shipping only</p>
                            </div>

                        </div>


                        <div class="swiper-slide " style="display: none">
                            <figure>
                                <img src="img/Banner_promotional_Final-IMG.jpg" alt="Banner-slider-4" style="cursor: pointer;">
                            </figure>
                            <div class="text-slider slider-expo">
                                <h3>VISION EXPO LIMITED TIME OFFER
                                    <br />
                                </h3>
                                <p>1 free frame for every 12 you buy*</p>
                                <a href="#0" class="btn empty">shop now</a>
                                <p class="note">*within the same brand</p>
                            </div>
                        </div>

                    </div>
                    <!-- Add Pagination -->
                    <div class="swiper-pagination"></div>
                </div>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-5 first-md">
                <a href="0-New%20Stock-1-25-Arrival">
                <div class="banner-shop new-arrival text-dark">
                    <%--  <a href="NewStock.aspx?b=0&n=New Stock">--%>
                    
                        <div class="block-text-banner text-dark">
                            <h4></h4>
                            <h3>
                                <asp:Label ID="Label89" runat="server" Text="<% $Resources:Resources, NewArrivals %>"></asp:Label>
                            </h3>
                        </div>
                    
                </div></a>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-12 col-lg-12">
                <a href="0-Bestsellers-1-25-Bestsellers">
                <div class="banner-shop best-seller-banner">

                    <div class="block-text-banner text-dark">
                        <!--<h4>Discover all</h4>-->
                        <h3>
                            <asp:Label ID="Label11" runat="server" Text="<% $Resources:Resources, BestSeller %>"></asp:Label>
                        </h3>
                        <a href="0-Bestsellers-1-25-Bestsellers" class="btn empty"><asp:Label ID="Label12" runat="server" Text="<% $Resources:Resources, Discoverbut %>"></asp:Label></a>
                    </div>

                </div></a>
            </div>
            <%--<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
					<header class="header-shop heder-section heder-need">

				<h1 class="title-section">Easy, Seamless Ordering</h1>
				<!--<a href="#0" class="back-need">Back</a>-->
			</header>
			<div class="main-section main-section-need" style="min-height:5px !important;">
				<div class="wrapper-policy" style="Padding: 5px 0px !important;">
				<p style="text-align:justify">
				The NYWD online portal is designed to offer you the most convenient and timely ordering process in the industry. Rather than operating on a pre-order system, our custom-built platform offers a wide range of inventory that is available at-once, with most orders shipping within a 24 to 48-hour window. Our high-resolution product images are taken in-house so that you can confidently and accurately shop our online inventory. Complete with advanced back-end features such as API and EDI integration that ensure quick order processing, our robust, scalable platform is equipped to handle unique catalog integration, logistics, invoicing and more. Additionally, we offer mass-customization services such as poly bagging, special ticketing and other logistical requirements. Get in touch with our team to learn more about custom options!</p>
				</div>
				
				</div>
					</div>	--%>

            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                <a href="all-Sunglasses-0-1-1-1-0-25">
                <div class="banner-shop all-sun">

                    
                        <div class="block-text-banner text-dark text-banner-center">
                            <!--<h4>Discover all</h4>-->
                            <h3>
                                <asp:Label ID="Span2" runat="server" Text="<% $Resources:Resources, ViewAllSun %>"></asp:Label>
                            </h3>

                        </div>
                    
                </div></a>
            </div>

            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                <a href="all-Optical-0-2-1-2-0-25"><div class="banner-shop all-optical">

                    
                        <div class="block-text-banner text-dark text-banner-center">
                            <!--<h4>Discover all</h4>-->
                            <h3>
                                <asp:Label ID="Span3" runat="server" Text="<% $Resources:Resources, ViewAllOptical %>"></asp:Label>
                            </h3>

                        </div>
                   
                </div> </a>
            </div>

            <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                <a href="Clearance-sale-0-1-25">
                <div class="banner-shop clearance-sale">

                    
                        <div class="block-text-banner text-dark text-banner-center">
                            <!--<h4>Discover all</h4>-->
                            <h3>
                                <asp:Label ID="Span4" runat="server" Text="Sale"></asp:Label>
                            </h3>

                        </div>
                    
                </div></a>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                <a href="0-Bestselling-1-25-Men" ><div class="banner-shop men-banner">

                    <div class="block-text-banner text-dark text-right">
                        <!--<h4>Discover all</h4>-->
                        <h3>
                            <asp:Label ID="Label13" runat="server" Text="<% $Resources:Resources, men %>"></asp:Label>
                        </h3>
                        <a href="0-Bestselling-1-25-Men" class="btn empty"><asp:Label ID="Label16" runat="server" Text="<% $Resources:Resources, Discoverbut %>"></asp:Label></a>
                    </div>

                </div></a>
            </div>

            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                <a href="0-Bestselling-1-25-Women"><div class="banner-shop women-banner">

                    <div class="block-text-banner text-dark text-left">
                        <!--<h4>Discover all</h4>-->    
                        <h3>
                            <asp:Label ID="Label14" runat="server" Text="<% $Resources:Resources, women %>"></asp:Label>
                        </h3>
                        <a href="0-Bestselling-1-25-Women" class="btn empty"><asp:Label ID="Label17" runat="server" Text="<% $Resources:Resources, Discoverbut %>"></asp:Label></a>
                    </div>

                </div></a>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <div class="banner-shop dicover-banner">

                    <div class="block-text-banner text-dark">
                        <!--<h4>Discover all</h4>-->
                        <h3>
                            <asp:Label ID="Label15" runat="server" Text="<% $Resources:Resources, less20dollar %>"></asp:Label>
                        </h3>
                        <asp:LinkButton ID="lnklessthan" class="btn empty" Text="<% $Resources:Resources, Discoverbut %>" runat="server" OnClick="lnklessthan_Click" ></asp:LinkButton>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Modal" runat="Server">
    <!-- MODAL-->
	<div class="modal-container" id="modal-opened">
		  <div class="modal">
		  	<figure class="modal-img">
				  <img src="img/crypto-pop.jpg" alt="crypto value"/>
			  </figure>
			<div class="modal__details">
			  <h1 class="modal__title"><asp:Label runat="server" ID="lblchd" Text="<% $Resources:Resources, cryptoheader %>"></asp:Label></h1>
			  <p class="modal__description"><asp:Label runat="server" ID="Label7" Text="<% $Resources:Resources, cryptobody1 %>"></asp:Label><br/><br /><asp:Label runat="server" ID="Label8" Text="<% $Resources:Resources, cryptobody2 %>"></asp:Label></p>
			  <%--<a href="0-New Stock-1-25-Arrival" class="modal__btn btn empty">SHOP NOW</a>--%>
			</div>
		
			
		
			<a href="#modal-closed" class="link-2"></a>
		
		  </div>
	</div>
</asp:Content>

