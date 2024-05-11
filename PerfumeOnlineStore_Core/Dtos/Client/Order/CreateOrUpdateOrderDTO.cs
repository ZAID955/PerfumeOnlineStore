using PerfumeOnlineStore_Core.Dtos.Client.CartItem;
using PerfumeOnlineStore_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Client.Order
{
    public class CreateOrUpdateOrderDTO
    {
        public int? Id { get; set; }
        public string Title
        {
            get
            {
                return ("Order-" + Id + " " + DateTime.Now);
            }
        }
        public City DeliveryCity { get; set; }
        public string Address { get; set; }
        public float DelievryPrice 
        {
            get
            {
                var x = 0f;
                switch (DeliveryCity)
                {
                    case City.Zarqa:
                    case City.Amman:
                        x = 3f;
                        break;
                    case City.Mafraq:
                    case City.Madaba:
                    case City.Salt:
                        x = 4f;
                        break;
                    case City.Irbid:
                    case City.Jerash:
                    case City.Ajloun:
                        x = 5f;
                        break;
                    default:
                        x = 6f;
                        break;
                }
                return x;
            }
        }
        public float DiscountAmount { get; set; }
        public string? PromoCodeName { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Note { get; set; }
        public List<SelectItemDTO> Items { get; set; }
    }
}
