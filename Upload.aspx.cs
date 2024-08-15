using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadSSRF
{
	public partial class Upload : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindUploadedFiles();
			}
		}

		protected void UploadButton_Click(object sender, EventArgs e)
		{
			if (FileUploadControl.HasFile)
			{
				try
				{
					string filename = Path.GetFileName(FileUploadControl.FileName);
					string uploadPath = Server.MapPath("/uploads/" + filename);
					FileUploadControl.SaveAs(uploadPath);
					StatusLabel.Text = "Upload status: File uploaded";
					BindUploadedFiles();
				}
				catch (Exception ex)
				{
					StatusLabel.Text = "Upload status: The file could not be uploaded";
				}
			}
		}

		private void BindUploadedFiles()
		{
			var files = Directory.GetFiles(Server.MapPath("/uploads/"));
			var fileList = new System.Collections.Generic.List<object>();

			foreach (var file in files)
			{
				fileList.Add(new
				{
					FileName = Path.GetFileName(file),
					FilePath = "/uploads/" + Path.GetFileName(file),
				});
			}
			UploadedFileRepeater.DataSource = fileList;
			UploadedFileRepeater.DataBind();
		}

		

	}
}