using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportExcel.Models.DTO
{
    public class RoomBooking
    {
        
        public string roomBookingID { get; set; }
        public string resourceId { get; set; }
        public string meetingRoomID { get; set; }
        public string title { get; set; }
        public string department { get; set; }
        public string DateCreate { get; set; }
        public string DatetimeCreate { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string isCancel { get; set; }
        public string DatetimeUpdate { get; set; }
        public string dateStart { get; set; }
        public string dateEnd { get; set; }

    }
}