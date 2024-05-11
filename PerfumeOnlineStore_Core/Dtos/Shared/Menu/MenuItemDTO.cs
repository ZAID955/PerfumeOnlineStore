using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore_Core.Dtos.Shared.Menu
{
    public class MenuItemtDTO
    {
        /*
         
            public List<MenuPackageDTO> Packages { get; set; }

            public List<MenuProductDTO> Productes { get; set; }

            public int Quntity { get; set; }

        */
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public float Price { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Quntity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
