using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class ImagemErrata
    {
        public ImagemErrata()
        {
           
        }
        public Guid Id { get; set; }
        public Guid ErratasId { get; set; }
        public Errata Erratas { get; set; }
        public string CaminhoImagem { get; set; }
    }
}
