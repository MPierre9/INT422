using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web.Mvc;
namespace Assignment9.Controllers
{
    public class ArtistBase
    {
        public ArtistBase()
        {
            Albums = new List<AlbumBase>();
        }

        public int Id { get; set; }

        // For an individual, can be birth name, or a stage/performer name
        // For a duo/band/group/orchestra, will typically be a stage/performer name
        [Required, StringLength(100)]
        public string Name { get; set; }

        // For an individual, a birth name
        [Display(Name = "Artist's Birth Name")]
        public string BirthName { get; set; }

        // For an individual, a birth date
        // For all others, can be the date the artist started working together
        [Display(Name = "Birth date, or start date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthOrStartDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Display(Name = "Artist Photo")]

        public string UrlArtist { get; set; }

        [Display(Name = "Artists's primary genre")]
        public string Genre { get; set; }

        // User name who looks after this artist
        [Required, StringLength(200)]
        public string Executive { get; set; }

        [StringLength(10000)]
        public string Portrayal { get; set; }

        public IEnumerable<AlbumBase> Albums { get; set; }
    }

    public class ArtistAdd
    {
        public ArtistAdd()
        {

        }

        [Required, StringLength(100)]
        public string Name { get; set; }

        // For an individual, a birth name
        [StringLength(100)]
        public string BirthName { get; set; }

        // For an individual, a birth date
        // For all others, can be the date the artist started working together

        [Display(Name = "Birth date, or start date (/dd/yyyy)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthOrStartDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(200)]
        public string UrlArtist { get; set; }

        public string Genre { get; set; }

        // User name who looks after this artist
        [StringLength(200)]
        public string Executive { get; set; }

        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        public string Portrayal { get; set; }

        public int GenreId { get; set; }

    }

    public class ArtistAddForm
    {
        public ArtistAddForm()
        {
            BirthOrStartDate = DateTime.Parse("2017-12-30");
        }

        [Required, StringLength(100)]
        public string Name { get; set; }

        // For an individual, a birth name
        [StringLength(100)]
        public string BirthName { get; set; }

        // For an individual, a birth date
        // For all others, can be the date the artist started working together

        [Display(Name = "Birth date, or start date (mm/dd/yyyy)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthOrStartDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(200)]
        public string UrlArtist { get; set; }

    

        // User name who looks after this artist
        [StringLength(200)]
        public string Executive { get; set; }

        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        public string Portrayal { get; set; }
        public int GenreId { get; set; }

        public SelectList GenreList { get; set; }


    }
}