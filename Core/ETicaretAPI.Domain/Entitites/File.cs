using System.ComponentModel.DataAnnotations.Schema;
using ETicaretAPI.Domain.Entitites.Common;

namespace ETicaretAPI.Domain.Entitites
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }          
        public string Path { get; set; }
        public string Storage { get; set; }
        [NotMapped]
        public override DateTime? UpdatedDate { get; set; }
        
    }
}
