<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Main.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="Leren1.Pages.LandingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header class ="header">
        <h1>
            Leren
        </h1>
        <h3>
            Learn With Leren
        </h3>
    </header>

    <main>

         <section class="hero">
             <div class ="hero-text">
                <img src="gambar1.jpeg">
                <div>
                    <h2>Nothing last forever,
                        We can change the future!
                    </h2>
                    <p>
                        We’re a nonprofit with the mission to provide a free, world-class education for anyone, anywhere. 
                        Feel free to join us
                    </p>    
                </div>
           </div>
        </section>

         <section class="hero">
             <div class ="hero-text">
                <div>
                    <h2>
                        Why Leren?
                    </h2>
                    <p>
                        With Leren, educators gain access to a collaborative platform where they can customize content to suit their teaching style. Its cost-effectiveness make it an ideal choice for students to learn and educators to deliver quality education without hefty licensing fees.
                    </p>    
                </div>
                  <img src="gambar1.jpeg">
           </div>
        </section>

    </main>
</asp:Content>


