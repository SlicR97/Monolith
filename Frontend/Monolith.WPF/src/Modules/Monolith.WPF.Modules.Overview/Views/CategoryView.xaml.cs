using MonolithBurgers.Modules.Overview.ViewModels;

namespace MonolithBurgers.Modules.Overview.Views
{
   /// <summary>
   /// Interaction logic for CategoryView.xaml
   /// </summary>
   public partial class CategoryView
   {
      public CategoryView(CategoryViewModel vm)
      {
         InitializeComponent();
         DataContext = vm;
      }
   }
}
