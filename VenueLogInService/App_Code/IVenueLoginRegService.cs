using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVenueLoginRegService" in both code and config file together.
[ServiceContract]
public interface IVenueLoginRegService
{
    [OperationContract]
    bool RegisterVenue(VenueUser v);

    [OperationContract]
    int VenueLogin(string userName, string password);

    [OperationContract]
    bool AddShow(Show s, int venueKey);

    [OperationContract]
    bool AddShowDetail(string showName, string artistName, System.TimeSpan artistStartTime);

    [OperationContract]
    bool AddArtist(Artist art);

}




[DataContract]
public class VenueUser{    
    [DataMember]
    public int VenueKey { get; set; }
    [DataMember]
    public string VenueName { get; set; }
    [DataMember]
    public string VenueAddress { get; set; }
    [DataMember]
    public string VenueCity { get; set; }
    [DataMember]
    public string VenueState { get; set; }
    [DataMember]
    public string VenueZipCode { get; set; }
    [DataMember]
    public string VenuePhone { get; set; }
    [DataMember]
    public string VenueEmail { get; set; }
    [DataMember]
    public string VenueWebPage { get; set; }
    [DataMember]
    public Nullable<int> VenueAgeRestriction { get; set; }
    [DataMember]
    public Nullable<System.DateTime> VenueDateAdded { get; set; }
    [DataMember]
    public virtual ICollection<VenueLogin> VenueLogins { get; set; }
    [DataMember]
    public string VenueUsername { set; get; }
    [DataMember]
    public string VenuePassWord { set; get; }
}

