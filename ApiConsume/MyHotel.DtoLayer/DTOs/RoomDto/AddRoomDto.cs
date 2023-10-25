using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.DtoLayer.DTOs.RoomDto
{
    public class AddRoomDto
    {
        [Required]
        public string RoomNumber { get; set; }

        public string RoomImage { get; set; }

        [Required]
        public int Price { get; set; }

        public string Title { get; set; }

        public string BedCount { get; set; }

        public string BathCount { get; set; }

        public string Wifi { get; set; }

        public string Description { get; set; }
    }
}
