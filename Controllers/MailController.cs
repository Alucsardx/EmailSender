using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using EmailSender.Models;
using EmailSender.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;

namespace EmailSender.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/mail")]
    [ApiController]


    public class MailController : ControllerBase
    {
        private AppEmailService _emailService;
        private IConverter _converter;
        private static string _info = "";


        public MailController(AppEmailService emailService, IConverter converter)
        {
            _emailService = emailService;
            _converter = converter;
        }

        [HttpPost]
        [Route("userInfo")]
        public void UserInformation([FromBody] Info info)
        {
            _info = info.UserInfo;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("sendMail")]
        public void SendMail()
        {
            try
            {
                var file = Request.Form.Files[0];
                _emailService.SendMail(file, _info);
            }
            catch (Exception e)
            {
                
            }
            //var user = Request.Form.Files[1];

            //var globalSettings = new GlobalSettings
            //{
            //    ColorMode = ColorMode.Color,
            //    Orientation = Orientation.Portrait,
            //    PaperSize = PaperKind.A4,
            //    Margins = new MarginSettings { Top = 10 },
            //    DocumentTitle = "PDF Report",
            //    Out = @"D:\PDFCreator\Employee_Report.pdf"
            //};

            //var objectSettings = new ObjectSettings
            //{
            //    PagesCount = true,
            //    //HtmlContent = UserInfoToPDF.GetHTMLString(userInfo),
            //    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
            //    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
            //    FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            //};

            //var pdf = new HtmlToPdfDocument()
            //{
            //    GlobalSettings = globalSettings,
            //    Objects = { objectSettings }
            //};

            //var userPdf= _converter.Convert(pdf);

        }
    }
}