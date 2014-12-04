﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HR.Master" AutoEventWireup="true" CodeBehind="EditTestSchedule.aspx.cs" Inherits="LAYERS.UI.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <center>
     <style type="text/css">
         .auto-style1 {
            width: 91%;
             margin-left: 39px;
             margin-right: 99px;
         }
        .auto-style2 {
             width: 193px;
         }
        .auto-style3 {
             width: 193px;
             height: 26px;
         }
        
        .auto-style5 {
            width: 193px;
            height: 58px;
        }
         .auto-style6 {
             width: 318px;
         }
         .auto-style7 {
             width: 318px;
             height: 26px;
         }
         .auto-style8 {
             width: 318px;
             height: 58px;
         }

        </style>
    <script type="text/javascript">
        function validateDates() {
            var writtenTest = document.getElementById("<%=TextBox1.ClientID%>").value;
            var technicalDate = document.getElementById("<%=TextBox2.ClientID%>").value;
            var hrTest = document.getElementById("<%=TextBox3.ClientID%>").value;
            if (writtenTest == technicalDate || writtenTest == hrTest || technicalDate == hrTest) {
                alert("No two test can be conducted on same day");
                document.getElementById("<%=TextBox1.ClientID%>").focus;
                return false;
            }
        }
    </script>
        </center>
   
    <style type="text/css">
        .auto-style1 {
            height: 30px;
            width: 828px;
            margin-left: 0px;
        }
        .auto-style2 {
            width: 430px;
        }
        .auto-style3 {
            height: 30px;
            width: 430px;
            margin-left: 0px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form ID="ID" runat="server">
     <center>
       
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Vacancy ID"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label9" runat="server" Text="Required By Date"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="Label10" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Written Test Date" ></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="Label" Visible="False" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label4" runat="server" Text="Technical Interview Date"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="Label" Visible="False" Font-Bold="True"></asp:Label>
                &nbsp;<br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="HR Interview Date"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="Label" Visible="False" Font-Bold="True"></asp:Label>
                &nbsp;<br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style8">
                    <asp:Button ID="Button1" runat="server" Text="Update" OnClientClick="return validateDates()" OnClick="Button1_Click1" style="height: 26px"/>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click"/>
                </td>
            </tr>
            <tr>
            <td>
                <center>
                <asp:Label ID="Label12" runat="server"  Visible="false"></asp:Label>
                </center>
            </td>
                </tr>
        </table>
            </center>
        </form>
</asp:Content>
