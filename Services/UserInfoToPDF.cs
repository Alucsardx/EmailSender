using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSender.Models;

namespace EmailSender.Services
{
    public class UserInfoToPDF
    {
        public static string GetHTMLString(UserInfoAsPDF userInfo)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"
                        <html>
                            <div>
                                {0}
                            </div> 
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>User Count</th>
                                        <th>Name/LastName</th>
                                        <th>Age</th>
                                        <th>Mail</th>
                                        <th>Mobile Number</th>
                                        <th>Facebook</th>
                                    </tr>", userInfo.Information);

            
            sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                  </tr>", userInfo.MemberCount, userInfo.NameSurname, userInfo.Age, userInfo.EMail, userInfo.MobileNumber, userInfo.Facebook);

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}
