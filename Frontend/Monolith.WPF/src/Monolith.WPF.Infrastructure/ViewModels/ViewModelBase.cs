using Prism.Mvvm;
using System.Windows.Input;

namespace MonolithBurger.Infrastructure.ViewModels
{
   public class ViewModelBase: BindableBase
   {
      public ICommand InitializeCommand { get; set; }
      public bool IsInitialized { get; set; }
   }
}
