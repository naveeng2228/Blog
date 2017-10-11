<%@ Page Title="Manage Posts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Posts.aspx.cs" Inherits="ExcelExport.Posts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Default box -->
    <div class="box">
        <div class="box-header with-border">
            <h3 class="box-title"><%= this.Title %></h3>
            <div class="box-tools pull-right">
                <asp:Button ID="btnExportExcel" runat="server" Text="Export Excel" CssClass="btn btn-box-tool btn-default" OnClick="btnExportExcel_Click" />
                <button type="button" class="btn btn-box-tool btn-default" data-widget="collapse" data-toggle="tooltip"
                    title="Collapse">
                    <i class="fa fa-gear"></i>
                </button>
                <a class="btn btn-box-tool btn-default" href="<%= ResolveUrl("~") %>AddPost.aspx">
                    <i class="fa fa-plus"></i>
                </a>
            </div>
        </div>
        <div class="box-body">
            <table id="posts" class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Post ID</th>
                        <th>Title</th>
                        <th>Short Description</th>
                        <th>Full Description</th>
                        <th>Status</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody id="tbposts" runat="server">
                </tbody>
            </table>
        </div>
        <!-- /.box-body -->
        <div class="box-footer">
        </div>
        <!-- /.box-footer-->
    </div>
    <!-- /.box -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentScripts" runat="server">
    <script>
        $(function () {
            $('#posts').DataTable();
        })
</script>
</asp:Content>
