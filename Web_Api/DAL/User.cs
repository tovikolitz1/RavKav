
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DAL
{

using System;
    using System.Collections.Generic;
    
public partial class User
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public User()
    {

        this.Transits = new HashSet<Transit>();

    }


    public int id { get; set; }

    public string fName { get; set; }

    public string lName { get; set; }

    public string email { get; set; }

    public bool isManager { get; set; }

    public string pass { get; set; }

    public string ravkavNum { get; set; }

    public Nullable<int> profileId { get; set; }



    public virtual Profile Profile { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Transit> Transits { get; set; }

}

}
