using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VenueLoginRegService" in code, svc and config file together.
public class VenueLoginRegService : IVenueLoginRegService
{
    ShowTrackerEntities db = new ShowTrackerEntities();

    public bool AddArtist(Artist art)
    {
        Artist artist = new Artist();
        artist.ArtistName = art.ArtistName;
        artist.ArtistDateEntered = DateTime.Now;
        bool result = true;
        try
        {
            db.Artists.Add(artist);
            db.SaveChanges();
        }
        catch(Exception ex)
        {
            result = false;
        }
        return result;
    }

    public bool AddShow(Show s, int venueKey)
    {
        Show show = new Show();
        show.ShowName = s.ShowName;
        show.ShowDate = s.ShowDate;
        show.ShowDateEntered = DateTime.Now;
        show.ShowTicketInfo = s.ShowTicketInfo;
        show.ShowDate = s.ShowDate;
        show.ShowTime = s.ShowTime;
        show.VenueKey = venueKey;

        bool result = true;
        
        try
        {
            db.Shows.Add(show);
            db.SaveChanges();
        }
        catch
        {
            result = false;
        }

        return result;
    }

    public bool AddShowDetail(string showName, string artistName, System.TimeSpan artistStartTime)
    {
        ShowDetail showdetail = new ShowDetail();
        Artist artist = db.Artists.FirstOrDefault(x => x.ArtistName.Equals(artistName));
        Show sh = db.Shows.FirstOrDefault(x => x.ShowName.Equals(showName));

        showdetail.ArtistKey = artist.ArtistKey;
        showdetail.ShowKey = sh.ShowKey;
        showdetail.ShowDetailArtistStartTime = artistStartTime;

        bool result = true;

        try
        {
            db.ShowDetails.Add(showdetail);
            db.SaveChanges();
        }
        catch
        {
            result = false;
        }

        return result;

    }

    public bool RegisterVenue(VenueUser v)
    {
        bool result = true;

        int pass = db.usp_RegisterVenue(v.VenueName, v.VenueAddress, v.VenueCity, v.VenueState, v.VenueZipCode, v.VenuePhone, v.VenueEmail, v.VenueWebPage, v.VenueAgeRestriction, v.VenueUsername, v.VenuePassWord);
        if(pass == -1)
        {
            result = false;
        }

        return result;
    }

    public int VenueLogin(string userName, string password)
    {
        int venueKey = 0;
        int result = db.usp_venueLogin(userName, password);
        if(result != -1)
        {
            var key = (from v in db.VenueLogins
                       where v.VenueLoginUserName.Equals(userName)
                       select new {v.VenueLoginKey}).FirstOrDefault();

            venueKey = key.VenueLoginKey;
        }

        return venueKey;
    }
}
