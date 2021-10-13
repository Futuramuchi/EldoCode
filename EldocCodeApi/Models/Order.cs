
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace EldocCodeApi.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Order
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Order()
    {

        this.ProductOrder = new HashSet<ProductOrder>();

    }


    public int Id { get; set; }

    public int WorkerId { get; set; }

    public System.DateTime DateCreated { get; set; }

    public int StatusId { get; set; }

    public Nullable<int> NotificationId { get; set; }

    public Nullable<int> ClientId { get; set; }



    public virtual Client Client { get; set; }

    public virtual Notification Notification { get; set; }

    public virtual Status Status { get; set; }

    public virtual Worker Worker { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ProductOrder> ProductOrder { get; set; }

}

}
