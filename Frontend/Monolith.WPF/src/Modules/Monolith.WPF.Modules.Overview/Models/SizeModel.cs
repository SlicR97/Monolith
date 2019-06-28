namespace MonolithBurgers.Modules.Overview.Models
{
   public class SizeModel
   {
      public int Id { get; set; }

      public string Name { get; set; }
      public double FillSize { get; set; }
      public double CostMultiplier { get; set; }

      public string SizeName => $"{Name} ({FillSize}L)";
   }
}
