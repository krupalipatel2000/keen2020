using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeenConveyance.Areas.Admin.Models
{
    public class JoinViewAll
    {
        public tblAdmin admin { get; set; }
        public tblBidding bid { get; set; }
        public tblBill bil { get; set; }
        public tblBooking book { get; set; }
        public tblComplaint complaint { get; set; }
        public tblConsignment consignment { get; set; }
        public tblConSignmentImage conimage { get; set; }
        public tblDriver driver { get; set; }
        public tblFeedback feedback { get; set; }
        public tblInquiry inquiry { get; set; }
        public tblPriceList price { get; set; }
        public tblService comservice { get; set; }
        public tblTracking tracking { get; set; }
        public tblTransportCompany company { get; set; }
        public tblUser user { get; set; }
        public tblVehicle vehicle { get; set; }
        public tblVehicleType vehicletype { get; set; }
        public tblAddress address { get; set; }
        public tblCMSPage page { get; set; }
        public CityMaster city { get; set; }
        public StateMaster state { get; set; }
        public CountryMaster country { get; set; }
        public IEnumerable<JoinViewAll> joinViewAlls { get; set; }
    }
}