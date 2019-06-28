namespace MonolithBurger.Infrastructure.Managers.Interface
{
   public interface IRegionChangeManager
   {
      void SwitchRegion<View>(View view, string regionName);
      void SwitchRegion<View>(string regionName);
      View GetView<View>();
   }
}
