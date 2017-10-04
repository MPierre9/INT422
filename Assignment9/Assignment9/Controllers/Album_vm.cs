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
    public class AlbumBase
    {
        public AlbumBase()
        {
            ReleaseDate = DateTime.Now;
            Artists = new List<ArtistBase>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReleaseDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(200)]
        public string UrlAlbum { get; set; }

        [Required]
        public string Genre { get; set; }

        // User name who looks after the album
        [Required, StringLength(200)]
        public string Coordinator { get; set; }

        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        public string Depiction { get; set; }

        public IEnumerable<ArtistBase> Artists { get; set; }



    }

    public class AlbumAdd
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(200)]
        public string UrlAlbum { get; set; }

       
        public string Genre { get; set; }

        // User name who looks after the album
        [StringLength(200)]
        public string Coordinator { get; set; }

        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        public string Depiction { get; set; }



        public int GenreId { get; set; }

        public string ArtistName { get; set; }



    }
    public class AlbumAddForm : AlbumAdd
    {
        public AlbumAddForm()
        {
           ReleaseDate = DateTime.Parse("2017-12-30");
        }

        [Display(Name = "Album Name")]
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Release date (MM/dd/yyyy)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReleaseDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Display(Name = "URL to album image (cover art)")]
        [Required, StringLength(200)]
        public string UrlAlbum { get; set; }


        public string Genre { get; set; }

        // User name who looks after the album
        [StringLength(200)]
        public string Coordinator { get; set; }

        [StringLength(10000)]
        [Display(Name = "Album depiction")]
        [DataType(DataType.MultilineText)]
        public string Depiction { get; set; }

        public int GenreId { get; set; }

        [Display(Name = "Album Genre")]
        public SelectList GenreList { get; set; }


        public string ArtistName { get; set; }


    }

}