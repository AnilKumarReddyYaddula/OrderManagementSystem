using Newtonsoft.Json;
using Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Product.Controllers
{
    
    //[Route("api/OrderDetails")]
    public class OrderDetailsController : ApiController
    {
        OrderService orderHomeService;
        
        //private OrderDetailsController(OrderService _orderHomeService)
        //{
        //    orderHomeService = _orderHomeService;
        //}


        [HttpGet]
        [Route("GetAllOrderByAdministrator")]
        public IHttpActionResult GetAllOrderByAdministrator()
        {
            orderHomeService = new OrderService();
       

            List<SP_OrderByAdministrator_Result> result = orderHomeService.GetAllOrderByAdministrator();
         
    
            return Ok(result);
            
        }

        [HttpGet]
        [Route("GetAllOrderByBuyer/UserId/{userId}")]
        public IHttpActionResult GetAllOrderByBuyer(int userId)
        {
            orderHomeService = new OrderService();
      

            List<SP_OrderByBuyer_Result> result = orderHomeService.GetAllOrderByBuyer(userId);
        
            return Ok(result);


     
        }

        [HttpGet]
        [Route("GetAllOrderByAdministratorIndetail")]
        public IHttpActionResult GetAllOrderByAdministratorInDetail()
        {
            orderHomeService = new OrderService();
           

            List<SP_OrderByAdministratorInDetail_Result> result = orderHomeService.GetAllOrderByAdministratorIndetail();
         
            return Ok(result);


          
        }


        [HttpGet]
        [Route("GetAllOrderByBuyerInDetail/UserId/{userId}")]
        public IHttpActionResult GetAllOrderByBuyerInDetail(int userId)
        {
            orderHomeService = new OrderService();
      

            List<SP_OrderByBuyerInDetail_Result> result = orderHomeService.GetAllOrderByBuyerInDetail(userId);
          
            return Ok(result);


        }

        [HttpPost]
        [Route("InsertOrder")]
        public IHttpActionResult InsertOrder(OrderRequest orderReq)
        {
            orderHomeService = new OrderService();
      

            bool result = orderHomeService.CreateOrder(orderReq);
            
            return Ok(result);


          
        }


        [HttpPut]
        [Route("UpdateOrder")]
        public IHttpActionResult UpdateOrder(UpdateOrderRequest updateOrderReq)
        {
            orderHomeService = new OrderService();
           

            bool result = orderHomeService.UpdateOrder(updateOrderReq);
           
            return Ok(result);


        
        }

        [HttpDelete]
        [Route("DeleteOrder/OrderId/{orderId}")]
        public IHttpActionResult DeleteOrder(int orderId)
        {
            orderHomeService = new OrderService();
           

            bool result = orderHomeService.DeleteOrder(orderId);
         
            return Ok(result);


        }


    }
}
