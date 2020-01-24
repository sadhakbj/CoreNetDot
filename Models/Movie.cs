using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace movies.Models
{

    public class Movie
    {
        public int id { get; set; }

        [JsonPropertyName("name")]
        [StringLength(5)]
        public string Name { get; set; }

        [JsonPropertyName("ticketPrice")]
        public decimal TicketPrice { get; set; }
    }

}