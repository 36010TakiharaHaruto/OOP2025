using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01{
    //2.1.1
  public  class Song{
        public String Title { get; private set; } = string.Empty;
        public String ArtistName { get; private set; } = string.Empty;
        public int Length { get; private set; }
        //2.1.2
        public Song (string Title, string ArtistName,int Length) {
            this.Title = Title;
            this.ArtistName = ArtistName;
            this.Length = Length;
        }
    }
}
