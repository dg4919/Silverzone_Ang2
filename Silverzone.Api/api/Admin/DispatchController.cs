using Silverzone.Data;
using Silverzone.Entities;
using Silverzone.Api.ViewModel.Site;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace Silverzone.Api.api.Admin
{
    public class DispatchController : ApiController
    {
        IUserShippingAddressRepository userShippingAddressRepository;
        IOrderDetailRepository orderDetailRepository;
        IOrderRepository orderRepository;
        IDispatchRepository dispatchRepository;
        private IErrorLogsRepository errorLogsRepository;
        private ICourierRepository courierRepository;
        private ICourierModeRepository courierModeRepository;

        [HttpGet]
        public IHttpActionResult getordersInfo(DateTime date, int orderType) // 0 > Not printed || 1 > Printed
        {
            if (orderType == 0)
            {
                var _result = from Order in orderRepository.GetAll()
                              join dispatch in dispatchRepository.GetAll()
                              on Order.Id equals dispatch.OrderId
                              into Dispatch_join
                              from myDispatch in Dispatch_join.DefaultIfEmpty()           // to create left join with dispatch Table
                              where myDispatch.Packet_Id == null && Order.OrderDate >= date
                              select new
                              {
                                  Id = Order.Id,
                                  OrderNumber = Order.OrderNumber,
                                  orderAmount = Order.Total_Shipping_Amount + Order.Total_Shipping_Charges,
                                  OrderDate = Order.OrderDate,
                                  Payment_Mode = Order.Payment_ModeType.ToString(),
                                  custmer_name = Order.UserShippingAddress.Username,
                                  packetNumber = myDispatch.Packet_Id
                              };

                return Ok(new { result = _result });
            }
            else
            {
                var _result = from Order in orderRepository.GetAll()
                              join dispatch in dispatchRepository.GetAll()
                              on Order.Id equals dispatch.OrderId
                              where Order.OrderDate >= date
                              select new
                              {
                                  Id = Order.Id,
                                  OrderNumber = Order.OrderNumber,
                                  orderAmount = Order.Total_Shipping_Amount + Order.Total_Shipping_Charges,
                                  OrderDate = Order.OrderDate,
                                  Payment_Mode = Order.Payment_ModeType.ToString(),
                                  custmer_name = Order.UserShippingAddress.Username,
                                  packetNumber = dispatch.Packet_Id
                              };

                return Ok(new { result = _result });
            }
        }

        [HttpGet]
        public IHttpActionResult create_orderLabel(int orderId)
        {
            using (var transaction = dispatchRepository.BeginTransaction())
            {
                try
                {
                    var packetInfo = dispatchRepository.GetByorderId(orderId);
                    string _status = "exist";

                    if (packetInfo == null)
                        _status = "success";

                    // return new Id > but data still not save in DB bcoz of transaction :)
                    packetInfo = dispatchRepository.Create(new Dispatch()
                    {       
                        OrderId = orderId       // data will be insert if already exist or not
                    });

                    packetInfo.Packet_Id = dispatchRepository.get_Packet_Number(packetInfo.Id);
                    packetInfo.Invoice_No = dispatchRepository.get_Invoice_Number(packetInfo.Id);
                    dispatchRepository.Update(packetInfo);


                    var orderInfo = orderDetailViewModel.Parse(
                           orderRepository.GetById(orderId)
                           );

                    Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                    var barCodeImg = barcode.Draw(packetInfo.Packet_Id, 50);

                    var _result = new
                    {
                        packetInfo = new { packetInfo.Invoice_No, packetInfo.Id, packetInfo.Packet_Id, packetInfo.CreationDate, imgBase = getbase64(barCodeImg) },     // new objects
                        orderInfo = orderInfo,
                        status = _status
                    };

                    transaction.Commit();
                    return Ok(new { result = _result });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    errorLogsRepository.logError(ex);
                    return Ok(new { result = "error" });
                }
            }
        }

        [HttpPost]
        public IHttpActionResult update_orderLabael(int Id, string reason)
        {
            var packetInfo = dispatchRepository.FindById(Id);
            packetInfo.print_reason = reason;

            dispatchRepository.Update(packetInfo);

            return Ok();
        }

        //******************************  Dispatch Wheight  ******************************

        [HttpGet]
        public IHttpActionResult get_printedOrder(DateTime date, int wheightType) // 0 > Not printed || 1 > Printed
        {
            var list = dispatchRepository.GetAll();

            var _result = from dispatch in dispatchRepository.GetAll()
                          where (wheightType == 0 ? dispatch.Packet_Wheight == null : dispatch.Packet_Wheight != null)      // a single condison inside braket
                          && dispatch.UpdationDate >= date
                          select new
                          {
                              Id = dispatch.Id,
                              packetNumber = dispatch.Packet_Id,
                              wheight = dispatch.Packet_Wheight,
                              createBy = dispatch.UpdatedBy,
                              createDate = dispatch.UpdationDate
                          };

            return Ok(new { result = _result });
        }

        [HttpPut]
        public IHttpActionResult add_packetWheight(string packetNumber, decimal wheight)
        {
            var packetInfo = dispatchRepository.GetBypacketId(packetNumber);
            if (packetInfo != null)
            {
                using (var transaction = dispatchRepository.BeginTransaction())
                {
                    try
                    {
                        packetInfo.Packet_Wheight = wheight;

                        dispatchRepository.Update(packetInfo);
                        transaction.Commit();       // it must be there if want to save record :)

                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        errorLogsRepository.logError(ex);      // to log this error & go to global error handler
                        return InternalServerError(ex);
                    }
                }
            }

            // go in error of ajax & return object 
            //return Content(HttpStatusCode.NotFound, "Any object");

            return Ok(new { result = "notfound" });
        }


        //******************************  Dispatch consignment  ******************************

        [HttpGet]
        public IHttpActionResult get_wheightedOrder(DateTime date, int consignmentType)
        {
            var list = dispatchRepository.GetAll();

            var _result = from dispatch in dispatchRepository.GetAll()
                          where (consignmentType == 0 ? dispatch.Packet_Consignment == null : dispatch.Packet_Consignment != null)      // a single condison inside braket
                          && dispatch.Packet_Wheight != null && dispatch.UpdationDate >= date
                          select new
                          {
                              Id = dispatch.Id,
                              packetNumber = dispatch.Packet_Id,
                              packetConsignmentNo = dispatch.Packet_Consignment,
                              createBy = dispatch.UpdatedBy,
                              createDate = dispatch.UpdationDate
                          };

            return Ok(new { result = _result });
        }

        [HttpPut]
        public IHttpActionResult add_consignment(int dispatchId, string consignmentNo, int courierMode)
        {
            if(dispatchRepository.GetByConsignment(consignmentNo, dispatchId))
                return Ok(new { result = "exist" });

            var packetInfo = dispatchRepository.FindById(dispatchId);

            if (packetInfo == null)
                return Ok(new { result = "notfound" });


            using (var transaction = dispatchRepository.BeginTransaction())
            {
                try
                {
                    packetInfo.Packet_Consignment = consignmentNo;
                    packetInfo.CourierModeId = courierMode;
                    packetInfo.Dispatch_Date = dispatchRepository.get_DateTime();

                    // to change status of order
                    var order = orderRepository.FindById(packetInfo.OrderId);
                    order.Order_Deliver_StatusType = orderStatusType.Dipatched;

                    
                    // to throw error
                    // throw new Exception("Custom Exception");

                    dispatchRepository.Update(packetInfo);
                    orderRepository.Update(order);

                    transaction.Commit();       // it must be there if want to save record :)

                    return Ok(new { result = "success" });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    errorLogsRepository.logError(ex);      // to log this error & go to global error handler
                    return Ok(new { result = "error" });
                }
            }
        }

        [HttpGet]
        public IHttpActionResult get_couriers()
        {
            var list = courierRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Courier_name
            });

            return Ok(new { result = list });
        }

        [HttpGet]
        public IHttpActionResult get_courierMode_by_courierId(int courierId)
        {
            var list = courierModeRepository.GetByCourierId(courierId).Select(x => new
            {
                x.Id,
                x.Courier_Mode
            });

            return Ok(new { result = list });
        }

        //******************************  Track Order  ******************************

        [HttpGet]
        public IHttpActionResult get_orderTrackList(DateTime date)
        {
            var list = dispatchRepository
                .FindBy(x => x.Packet_Consignment != null && x.UpdationDate >= date)
                .Select(x => new
                {
                    x.Id,
                    x.Order.OrderNumber,
                    order_Source = x.Order.orderSourceType.ToString(),
                    total_Amount = x.Order.Total_Shipping_Amount + x.Order.Total_Shipping_Charges,
                    x.Packet_Id,
                    x.Packet_Consignment,
                    x.CourierMode.Courier.Courier_name,
                    x.CourierMode.Courier_Mode,
                    x.Dispatch_Date,
                    dispatch_Status = x.Order.Order_Deliver_StatusType.ToString(),
                    trackLink = x.CourierMode.Courier.Id == 4           // create URL for for fedex 
                              ? x.CourierMode.Courier.Courier_Link + "?action=track&trackingnumber="+ x.Packet_Consignment + "&cntry_code=us"
                              : x.CourierMode.Courier.Courier_Link
                });

            return Ok(new { result = list });
        }


        internal string getbase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }

        }

        public DispatchController(
            IUserShippingAddressRepository _userShippingAddressRepository,
            IOrderDetailRepository _orderDetailRepository,
            IOrderRepository _orderRepository,
            IDispatchRepository _dispatchRepository,
            IErrorLogsRepository _errorLogsRepository,
            ICourierRepository _courierRepository,
            ICourierModeRepository _courierModeRepository
            )
        {
            userShippingAddressRepository = _userShippingAddressRepository;
            orderDetailRepository = _orderDetailRepository;
            orderRepository = _orderRepository;
            dispatchRepository = _dispatchRepository;
            errorLogsRepository = _errorLogsRepository;
            courierRepository = _courierRepository;
            courierModeRepository = _courierModeRepository;
        }

    }
}
