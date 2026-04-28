namespace Integrasys.RouteManager.Models;

public class Item
{
   public int Id { get; set; }
   public string Title { get; set; }
   public int Uc{ get; set; }
   public string Upc { get; set; }
   public int Stock { get; set; }
   public int Cases { get; set; }

   public ItemToViewModelDto ToDto()
   {
      return new ItemToViewModelDto(Id, Title, Uc, Upc, Stock, Cases);
   }
}