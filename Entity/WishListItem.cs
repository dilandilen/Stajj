using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Kullanıcının kimliği
        public int ProductId { get; set; } // Wishlist'e eklenen ürünün kimliği
        public DateTime AddedDate { get; set; } // Wishlist'e eklenme tarihi

        // Diğer özellikler ve ilişkiler buraya eklenebilir
    }

}
