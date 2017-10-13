<%@ Page Title="Add Role" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="ExcelExport.AddRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Default box -->
    <div class="box">
        <div class="box-header with-border">
            <h3 class="box-title"><%= this.Title %></h3>
            <div class="box-tools pull-right">
                <button type="button" id="btnErrors" class="btn btn-box-tool btn-default" data-toggle="modal" data-target="#formerrors">
                    <i class="fa fa-exclamation-triangle"></i>Errors
                </button>
                <a class="btn btn-default btn-box-tool" href="<%= ResolveUrl("~") %>Posts.aspx">View All
                </a>
            </div>
        </div>
        <div class="box-body">
            <fieldset>
                <legend>Post Details</legend>
                <div class="form-group">
                    <div class="row">
                        <div class="col col-md-3">
                            <small class="text-danger"><i class="fa fa-asterisk"></i></small>
                            <asp:Label ID="lblPostTitle" runat="server" CssClass="control-label" Text="Post Title"></asp:Label>
                        </div>
                        <div class="col col-md-9">
                            <asp:TextBox ID="txtPostTitle" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfPostTitle" runat="server" ControlToValidate="txtPostTitle" Display="None" ErrorMessage="Post title is required." ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col col-md-3">
                            <small class="text-danger"><i class="fa fa-asterisk"></i></small>
                            <asp:Label ID="lblShortDescription" runat="server" CssClass="control-label" Text="Short Description"></asp:Label>
                        </div>
                        <div class="col col-md-9">
                            <asp:TextBox ID="txtShortDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfShortDescription" runat="server" ControlToValidate="txtShortDescription" Display="None" ErrorMessage="Short description is required." ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col col-md-3">
                            <asp:Label ID="lblStatus" runat="server" CssClass="control-label" Text="Status"></asp:Label>
                        </div>
                        <div class="col col-md-9">
                            <asp:DropDownList ID="ddlStatus" runat="server">
                                <asp:ListItem Text="In-Active" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Deleted" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
        <!-- /.box-body -->
        <div class="box-footer">
            <div class="form-group">
                <div class="row">
                    <div class="col col-md-3">
                    </div>
                    <div class="col col-md-9">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success btn-sm btn-flat" Text="Save Post" OnClick="btnSave_Click" ValidationGroup="Save" OnClientClick="return Chkconfirm('You are about to save the post. Are you sure you want to do this now?');" />
                        <asp:Button ID="btnClearAll" runat="server" CssClass="btn btn-default btn-sm btn-flat" Text="Clear All" OnClick="btnClearAll_Click" OnClientClick="return Chkconfirm('You are about to clear all the values of the post. You may lose all the unsaved changes. Are you sure you want to clear now?');" />
                    </div>
                </div>
            </div>
        </div>
        <!-- /.box-footer-->
    </div>
    <!-- /.box -->

    <div class="modal fade" id="formerrors">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Errors</h4>
                </div>
                <div class="modal-body" id="formerrordisplay">
                    <asp:Label ID="lblNoErrors" runat="server" Text="No validation errors."></asp:Label>
                    <asp:ValidationSummary ID="vsForm" runat="server" ValidationGroup="Save" DisplayMode="BulletList" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentScripts" runat="server">
</asp:Content>
