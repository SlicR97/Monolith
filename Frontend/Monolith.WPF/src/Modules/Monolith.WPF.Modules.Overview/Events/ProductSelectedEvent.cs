using MonolithBurgers.Modules.Overview.Models;
using Prism.Events;

namespace MonolithBurgers.Modules.Overview.Events
{
   class ProductSelectedEvent : PubSubEvent<ProductModel> { }
}
