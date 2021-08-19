using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssoxApiConnector.Models.Request
{

    public class EssoxProposal
    {

        [MaxLength(255)]
        public string firstName { get; set; }


        [MaxLength(255)]
        public string surname { get; set; }

        /// <summary> prefix vcetne + </summary>
        [MaxLength(50)]
        public string mobilePhonePrefix { get; set; }

        /// <summary> Telefon zákazníka </summary>      
        [MaxLength(50)]
        public string mobilePhoneNumber { get; set; }


        public string email { get; set; }

        /// <summary> Financovaná částka</summary>
        public decimal price { get; set; }

        /// <summary> Nastavení výchozí produktu při zobrazení v GUI (ID produktu Essox, dodává Essox) </summary>
        public int productId { get; set; }

        /// <summary>
        /// Číslo objednávky partnera, formát alfanumerické znaky, doporučená délka 50 znaků(volitelně)
        /// </summary>
        [MaxLength(50)]
        public string orderId { get; set; }

        /// <summary>
        /// Číslo zakaznika partnera(volitelně)
        /// </summary>
        public string customerId { get; set; }

        /// <summary> Unikátní identifikátor transakce partnera(volitelně) </summary>
        [MaxLength(255)]
        public string transactionId { get; set; }


        //shippingAddress	{...}  !!!!!
        public shippingAddress shippingAddress { get; set; }


        /// <summary> Url pro vrácení výsledku eshopu </summary>
        public string callbackUrl { get; set; }


        /// <summary> Rozliseni jestli je pozadovana rozlozena platba splatek. Viz dokumentace! </summary>
        public bool spreadedInstalments { get; set; } = false;
    }

    public class shippingAddress
    {
        /// <summary>
        /// Název ulice
        /// </summary>
        [MaxLength(255)]
        public string street { get; set; }

        /// <summary>
        /// Číslo popisné/orientační
        /// </summary>
        [MaxLength(20)]
        public string houseNumber { get; set; }

        /// <summary>
        /// Město/obec
        /// </summary>
        [MaxLength(20)]
        public string city { get; set; }

        /// <summary>
        /// Poštovní směrovací číslo
        /// </summary>
        public string zip { get; set; }
    }
}
