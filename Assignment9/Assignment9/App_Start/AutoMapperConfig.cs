using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assignment9
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // AutoMapper create map statements - using AutoMapper static API
            // Mapper.Initialize(cfg => cfg.CreateMap< FROM , TO >());
            // Add map creation statements here
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();
                cfg.CreateMap<Controllers.ArtistAdd, Models.Artist>();
                cfg.CreateMap<Models.Genre, Controllers.GenreBase>();
                cfg.CreateMap<Models.Artist, Controllers.ArtistBase>();

                cfg.CreateMap<Models.Album, Controllers.AlbumBase>();
                cfg.CreateMap<Controllers.AlbumAdd, Models.Album>();

                cfg.CreateMap<Models.Track, Controllers.TrackBase>();


                // Add more below...

            });
        }
    }
}