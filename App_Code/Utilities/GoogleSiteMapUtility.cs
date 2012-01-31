using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using WebsiteModel;
using System.IO;

/// <summary>
/// Summary description for SiteMapUtility
/// </summary>
public class GoogleSiteMapUtility
{
	public GoogleSiteMapUtility()
	{

	}

    public static void ExportSiteMapXML()
    {


        //StringBuilder str = new StringBuilder();

        //str.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
        //str.AppendLine(@"<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://www.sitemaps.org/schemas/sitemap/0.9"">");
        //str.AppendLine("<url><loc>http://www.studentschoolbooks.com/</loc></url>");
        //str.AppendLine("<url><loc>http://www.studentschoolbooks.com/books</loc></url>");
        //str.AppendLine("<url><loc>http://www.studentschoolbooks.com/tutors</loc></url>");
        //str.AppendLine("<url><loc>http://www.studentschoolbooks.com/howitworks</loc></url>");
        //str.AppendLine("<url><loc>http://www.studentschoolbooks.com/account</loc></url>");
        //str.AppendLine("<url><loc>http://www.studentschoolbooks.com/signin.aspx</loc></url>");
        //str.AppendLine("<url><loc>http://www.studentschoolbooks.com/contactUs.aspx</loc></url>");
        //str.AppendLine("<url><loc>http://www.studentschoolbooks.com/advertising.aspx</loc></url>");


        //DateTime maxPostDate = DateTime.Now.AddDays(-90);
        //List<Book> bookList = Global.Repository.Books_Active().Where(b => b.Added >= maxPostDate).ToList();

        //foreach (Book b in bookList)
        //{
        //    str.AppendFormat("<url><loc>{0}</loc></url>", b.DetailPageAbsoluteUrl);
        //}


        //List<Tutor> tutorList = Global.Repository.Tutors_Active().Where(b => b.Added >= maxPostDate).ToList();

        //foreach (Tutor t in tutorList)
        //{
        //    str.AppendFormat("<url><loc>{0}</loc></url>", t.DetailPageAbsoluteUrl);
        //}

        //str.AppendLine("</urlset>");

        //TextWriter tw = new StreamWriter(HttpContext.Current.Server.MapPath("/sitemap.xml"));
        //tw.WriteLine(str);
        //tw.Close();



    }
}