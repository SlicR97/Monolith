using MonolithBurgers.Modules.Overview.ViewModels;

namespace MonolithBurgers.Modules.Overview.Views
{
   /// <summary>
   /// Interaction logic for ProductDetailView.xaml
   /// </summary>
   public partial class ProductDetailView
   {
      public ProductDetailView(ProductDetailViewModel vm)
      {
         InitializeComponent();
         DataContext = vm;
      }
   }
}
