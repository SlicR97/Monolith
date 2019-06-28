using MonolithBurgers.Modules.Overview.ViewModels;

namespace MonolithBurgers.Modules.Overview.Views
{
   /// <summary>
   /// Interaction logic for CartViewModel.xaml
   /// </summary>
   public partial class CartView
   {
      public CartView(CartViewModel vm)
      {
         InitializeComponent();
         DataContext = vm;
      }
   }
}
