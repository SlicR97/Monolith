using MonolithBurger.Infrastructure.Constants;
using MonolithBurger.Infrastructure.Managers.Interface;
using MonolithBurger.Infrastructure.ViewModels;
using MonolithBurgers.Modules.Overview.Models;
using MonolithBurgers.Modules.Overview.Service.Interfaces;
using MonolithBurgers.Modules.Overview.Views;
using Prism.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace MonolithBurgers.Modules.Overview.ViewModels
{
   public class CategoryViewModel : ViewModelBase
   {
      private readonly ICategoryService _categoryService;
      private readonly IRegionChangeManager _regionChangeManager;
      private IEnumerable<CategoryModel> _categories;

      public CategoryViewModel(ICategoryService categoryService, IRegionChangeManager regionChangeManager)
      {
         _categoryService = categoryService;
         _regionChangeManager = regionChangeManager;

         InitializeCommand = new DelegateCommand(OnInitializeCommandExecute, OnInitializeCommandCanExecute);
         SelectCategoryCommand = new DelegateCommand<CategoryModel>(OnSelectCategoryCommandExecute, OnSelectCategoryCommandCanExecute);
      }

      public ICommand SelectCategoryCommand { get; set; }

      public IEnumerable<CategoryModel> Categories 
      {
         get => _categories;
         set => SetProperty(ref _categories, value);
      }

      private async void OnInitializeCommandExecute()
      {
         IsInitialized = true;
         Categories = await _categoryService.GetCategoriesAsync();
      }

      private bool OnInitializeCommandCanExecute()
         => !IsInitialized;

      private void OnSelectCategoryCommandExecute(CategoryModel category)
      {
         var menuView = _regionChangeManager.GetView<MenuView>();
         ((MenuViewModel)menuView.DataContext).Category = category;
         _regionChangeManager.SwitchRegion(menuView, RegionNames.Menu);
      }

      private bool OnSelectCategoryCommandCanExecute(CategoryModel category)
         => category != null;
   }
}
