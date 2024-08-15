<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="FileUploadSSRF.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>File Upload</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Upload File</h2>
            <asp:FileUpload ID="FileUploadControl" runat="server" />
            <asp:Button ID="UploadButton" runat="server" Text="Upload" OnClick="UploadButton_Click" />
            <br/><br/>
            <asp:Label ID="StatusLabel" runat="server" Text="Upload status: " />
            <br/><br/>
            <h2>Uploaded Files</h2>
            <asp:Repeater ID="UploadedFileRepeater" runat="server">
                <ItemTemplate>
                    <a href='<%# Eval("FilePath") %>' target="_blank"><%# Eval("FileName") %></a>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
