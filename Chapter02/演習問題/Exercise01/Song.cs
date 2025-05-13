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
       public String Title { get; set; } 
        public String ArtistName { get; set; } 
        public int Length { get; set; } 
        //2.1.2
        public Song (string Title, string ArtistName,int Length) {
            this.Title = Title;
            this.ArtistName = ArtistName;
            this.Length = Length;
        }

    }



}
