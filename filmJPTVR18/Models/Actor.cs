//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace filmJPTVR18.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Actor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actor()
        {
            this.FilmActors = new HashSet<FilmActor>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FullName { get; set; }
        public byte[] Image { get; set; }
        public string ImageType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilmActor> FilmActors { get; set; }
    }
}
