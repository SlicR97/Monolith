using MonolithBurgers.Modules.Overview.ViewModels;

namespace MonolithBurgers.Modules.Overview.Views
{
   /// <summary>
   /// Interaction logic for MenuView.xaml
   /// </summary>
   public partial class MenuView
   {
      public MenuView(MenuViewModel vm)
      {
         InitializeComponent();
         DataContext = vm;
      }
   }
}
