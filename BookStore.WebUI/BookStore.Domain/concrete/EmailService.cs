using BookStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.concrete
{
      public class EmailService
     {
        public string MailToAddress = "userinfo@xbookstore.com,admin@xbookstore.com";//example of email that for user ,we will send for him.
        public string MailFromAddress = "fouadm822@gmail.com";//the name of campany that send mail or us to customer
        public bool UserSsl = true;
        public string UserName = "fouadm822@gmail.com";//that I shoould have the username and password of the e-mail i send from it to the customer and not important to have the useer password of customer
        public string Password = "MyPassword";
        public string ServerName ="smtp.gmail.com";//that if it run in gmail
        // i search of the smtp or any type of server in the internet and see the port of it.
        public int ServerPort = 587;
        public bool WriteAsFile = false;// if there are not internet then it will save the data in file at the server.
        public string FileLocation =@"C:\Orders_BookStore_eMails";//that the place where i put the file when i send data and there are internet so it will saved at this file location.
      }
    public class EmailOprderprocessor:IOrderProcessor
    {
        private EmailService server;
        public EmailOprderprocessor(EmailService v)
        {
            server = v;
        }
        //كود ثابت للرسالة استخدمة في كل الحالات
        //بغير بس في الحاجات اللي فوق زي الاميل من مين وفين وهكذا واللي تحت دا كلة ثابت
        public void processorder(Entities.Cart cart, Entities.ShoppingDetails shoppingdetails)
        {
            //that i send the data of emailserver to the existing one that to work of this data not the default.
            using(var SmtpClient =new SmtpClient())
            {
                SmtpClient.EnableSsl = server.UserSsl;
                SmtpClient.Host = server.ServerName;
                SmtpClient.Port = server.ServerPort;
                SmtpClient.UseDefaultCredentials = false;//that if true so it will work in the default but Iwant it to take the username and password from me.
                SmtpClient.Credentials = new NetworkCredential(server.UserName,server.Password);//take the username and password from me.
                if(server.WriteAsFile)//by default equal true and that when there are internet and the emails will store in the File 
                {
                    SmtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;//that to identify specific directory for the created file
                    SmtpClient.PickupDirectoryLocation = server.FileLocation;
                    SmtpClient.EnableSsl = false;//that because you will work in the file and the enablessl that for make specific authorization.only in the caser of the file i make the enablessl false.
                }
                StringBuilder body = new StringBuilder()
                .AppendLine("a new order has been submitted ")
                .AppendLine("............")
                .AppendLine("A books");
                foreach(var line in cart.lines)
                {
                    //the cart that I take it from parameter
                    var subtotal = line.Quantity * line.Book.Price;
                    body.AppendFormat("{0} x {1} (subtotal : {2:c})",line.Quantity,line.Book.title,subtotal);//that for each product in the lines that it calculate the cost of each of them .
                }
                body.AppendFormat("the total order value {0:c}",cart.computeitem())
                    .AppendLine(".............")
                    .AppendLine("Ship To :")
                    .AppendLine(shoppingdetails.Name)
                    .AppendLine(shoppingdetails.Line1)
                    .AppendLine(shoppingdetails.Line2)
                    .AppendLine(shoppingdetails.State)
                    .AppendLine(shoppingdetails.City)
                    .AppendLine(shoppingdetails.Country)
                    .AppendLine(".............")
                    .AppendFormat("Gift wrap:{0}",shoppingdetails.Giftwrap?"Yes":"No");
                //that if there are operation use appendformat if you want to write only value then use append or appendline if you want to make the phrase in line.
                // all this data I store it in the body.
                MailMessage mailmessage = new MailMessage
                    (
                    //that take the data you want to send it to the user that take the details :
                    server.MailFromAddress,//from ?
                    server.MailToAddress,//to ?
                    "the information",// the title of the message 
                    body.ToString() //the message and make tostring to enable reading it .
                    );
                if(server.WriteAsFile)
                {
                    mailmessage.BodyEncoding = Encoding.ASCII;//always I make it for asci encreption.
                }
                SmtpClient.Send(mailmessage);// that to send message to the user 
            }
        }
    }
}
