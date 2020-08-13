using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace NorthwindApp
{
    public partial class CustomerExport : System.Web.UI.Page
    {

        private const int PageSize = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            plcPaging.Controls.Clear();
            CreatePagingControl();
            if (!Page.IsPostBack)
            {
                FetchData(1);
            }
        }

        private void CreatePagingControl()
        {
            int rowCount = CustomerService.GetCustomerCount();
            rowCount = (rowCount / PageSize) + 1;

            for (int i = 0; i < rowCount; i++)
            {
                LinkButton lnk = new LinkButton();
                lnk.Click += new EventHandler(lbl_Click);
                lnk.ID = "lnkPage" + (i + 1).ToString();
                lnk.Text = (i + 1).ToString();
                plcPaging.Controls.Add(lnk);
                Label spacer = new Label();
                spacer.Text = "&nbsp;";
                plcPaging.Controls.Add(spacer);
            }
        }


        void lbl_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int currentPage = int.Parse(lnk.Text);

            FetchData(currentPage);
        }

        private void FetchData(int pageIndex)
        {
            repCustomers.DataSource = CustomerService.GetAllCustomers(pageIndex - 1, PageSize);
            repCustomers.DataBind();
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Customers.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            
            //this.Page.RenderControl(hw);            
            this.repCustomers.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString().Replace("\r", "").Replace("\n", "").Replace("  ", ""));
            Document pdfDoc = new Document(iTextSharp.text.PageSize .A4, 10f, 10f, 10f, 0.0f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }       

        protected void btnExportAllCustomer_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Customers.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            Repeater repAllCustomers = this.repCustomers;
            repAllCustomers.DataSource = CustomerService.GetAllCustomers(0, CustomerService.GetCustomerCount());
            repAllCustomers.DataBind();
            repAllCustomers.RenderControl(hw); 
            
            StringReader sr = new StringReader(sw.ToString().Replace("\r", "").Replace("\n", "").Replace("  ", ""));
            Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0.0f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void btnExportPage_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Customers.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            this.Page.RenderControl(hw);            
            
            StringReader sr = new StringReader(sw.ToString().Replace("\r", "").Replace("\n", "").Replace("  ", ""));
            Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0.0f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
    }
}