using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Core.Helper.Enums
{
    public static class PerfumeOnlineStoreLookups
    {
        public enum UserType
        {
            Admin,
            Employee,
            Supplier,
            Delivery,
            Client
        }
        public enum Gendear
        {
            Male,
            Female
        }
        public enum CartStatus
        {
            Processing,
            SavedForLater,
            Completed,
            Cancelled
        }
        public enum OrderStatus
        {
            Processing,
            Completed,
            Delivered,
            Cancelled
        }
        public enum City
        {
            Amman,
            Irbid,
            Zarqa,
            Madaba,
            Aqaba,
            Salt,
            Ajloun,
            Jerash,
            Mafraq,
            Karak,
            Tafilah,
            Balqa,
            Ramtha,
            DeadSea
        }
        public enum PaymentMethod
        {
            Cash,
            CreditCard,
            Cliq,
            BankTransfer,
            WalletTransfer,
            PayPal,
            Check,
            InstallmentPlans
        }
        public enum Category
        {
            ForHim,
            ForHer,
            ForKids,
            Unisex
        }
        public enum SizeUnite
        {
            ml,
            g
        }
        /*
        public enum ProductSize : int
        {
       5,
       8,
       90,
       20,
       25,
       50,
       50,
       50,
       80,
       90,
       100,
       120,
       125,
       150,
       180,
       200,
       300
        }
                public enum ProductType
        {
            Perfume,
            MoisturizerCleaners,
            Scrubs,
            SerumsOils,
            SunProtection,
            EyeCream,
            FacialTreatments,
            BodyLotion,
            BodyAndHandCream,
            BodyTreatments,
            DeodorantAndBodySpray,
            HairAndBodyMist,
            ShowerGel,
            ShowerOil,
            SoapBath,
            AfterShave,
            SkinCare
        }
        public enum Section
        {
            Fragrances,
            SkinCare,
            BodyCare
        }
        */
    }
}
