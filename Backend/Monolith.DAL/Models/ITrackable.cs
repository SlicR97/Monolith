using System;

namespace Monolith.DAL.Models
{
   internal interface ITrackable
   {
      DateTime CreatedAt { get; set; }
      DateTime ModifiedAt { get; set; }
   }
}
