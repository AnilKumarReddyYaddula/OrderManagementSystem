using Product.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;
using System.Net.Mail;
using System.Net;

namespace Product.Controllers
{
    public class OrderService
    {
        //public string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
        public OrderManagementSystemEntities objdemoentity = new OrderManagementSystemEntities();
        //public string GetAllOrderByAdministrator()
        //{

        //    return "";

        //}

        public List<SP_OrderByAdministrator_Result> GetAllOrderByAdministrator()
        {

            System.Data.Entity.Core.Objects.ObjectResult<SP_OrderByAdministrator_Result> result = objdemoentity.SP_OrderByAdministrator();
            //List<OrderByAdmin> selectedCollection = li.T

            return result.ToList();
            //}



        }
        public List<SP_OrderByBuyer_Result> GetAllOrderByBuyer(int userId)
        {


            System.Data.Entity.Core.Objects.ObjectResult<SP_OrderByBuyer_Result> result = objdemoentity.SP_OrderByBuyer(userId);

            return result.ToList();
        }

        public List<SP_OrderByAdministratorInDetail_Result> GetAllOrderByAdministratorIndetail()
        {

            System.Data.Entity.Core.Objects.ObjectResult<SP_OrderByAdministratorInDetail_Result> result = objdemoentity.SP_OrderByAdministratorInDetail();
            //List<OrderByAdmin> selectedCollection = li.T

            return result.ToList();
            //}



        }

        public List<SP_OrderByBuyerInDetail_Result> GetAllOrderByBuyerInDetail(int userId)
        {


            System.Data.Entity.Core.Objects.ObjectResult<SP_OrderByBuyerInDetail_Result> result = objdemoentity.SP_OrderByBuyerInDetail(userId);

            return result.ToList();
        }

        public bool CreateOrder(OrderRequest orderReq)
        {
            bool flag = false;

            int count = objdemoentity.SP_CreateOrder(orderReq.Status, orderReq.UserId, orderReq.ShippingAddress, orderReq.ProductId, orderReq.Quantity, orderReq.OrderId);

            if (count > 0)
            {
                
                GetEmailNotification(orderReq);
                flag = true;
            }


            return flag;
        }

        public bool UpdateOrder(UpdateOrderRequest updateOrderReq)
        {
            bool flag = false;

            int count = objdemoentity.SP_UpdateOrder(updateOrderReq.OrderId, updateOrderReq.UserId, updateOrderReq.Status, updateOrderReq.ShippingAddress, updateOrderReq.Quantity, updateOrderReq.ItemId, updateOrderReq.ProductId);

            if (count > 0)
            {
                flag = true;
                 


            }



            return flag;
        }

        public bool DeleteOrder(int orderId)
        {
            bool flag = false;

            int count = objdemoentity.SP_DeleteOrder(orderId);

            if (count > 0)
                flag = true;


            return flag;
        }

       

        public bool GetEmailNotification(OrderRequest orderReq)
        {

            bool flag = false;
            MailAddress to = new MailAddress("anilvineel507@gmail.com");
            System.Data.Entity.Core.Objects.ObjectResult<SP_GetEmailIdOfuser_Result> result = objdemoentity.SP_GetEmailIdOfuser(orderReq.UserId);

            List<SP_GetEmailIdOfuser_Result> lis= result.ToList();
            

            
            MailAddress from = new MailAddress(lis[0].MailId);

            MailMessage message = new MailMessage(from, to);
            message.Subject = "Order Placed Notification";
            message.Body = "Hi , your order of shipping addres"+orderReq.ShippingAddress+" got placed";

            //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //SmtpServer.Credentials = new System.Net.NetworkCredential("anilvineel507@gmail.com", "Kulfi@507");
            //SmtpServer.EnableSsl = true;
            //SmtpClient client = new SmtpClient("smtp.gmail.com", 2525)
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("anilvineel507@gmail.com", "Kulfi@507"),
                EnableSsl = true,
                UseDefaultCredentials = false
        };
            

            try
            {
                //SmtpServer.Send(message);
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return flag;
        }

    }



}