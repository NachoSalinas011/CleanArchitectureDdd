using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext _streamerDbContext = new();

//await AddNewRecords();
//await AddNewStreamerWithVideo();
//await AddNewDirectorWithVideo();
//await AddNewStreamerWithVideoId();


await MultipleEntitiesQuery();


async Task MultipleEntitiesQuery()
{

}


async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = 5
    };

    await _streamerDbContext.AddAsync(director);
    await _streamerDbContext.SaveChangesAsync();
}


async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "Pitt"
    };

    await _streamerDbContext.AddAsync(actor);
    await _streamerDbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };

    await _streamerDbContext.AddAsync(videoActor);
    await _streamerDbContext.SaveChangesAsync();

}



async Task AddNewStreamerWithVideoId()
{
    var batmanForever = new Video
    {
        Nombre = "batman forever",
        StreamerId = 1
    };

    await _streamerDbContext.AddAsync(batmanForever);
    await _streamerDbContext.SaveChangesAsync();

}



async Task AddNewStreamerWithVideo()
{
    var pantaya = new Streamer
    {
        Nombre = "Pantaya"
    };

    var hungerGames = new Video
    {
        Nombre = "Hunger Games",
        Streamer = pantaya
    };

    await _streamerDbContext.AddAsync(hungerGames);
    await _streamerDbContext.SaveChangesAsync();

}



async Task TrackingAndNotTracking()
{

    var streamerWithTracking = await _streamerDbContext!.Streamers!.FirstOrDefaultAsync(x => x.Id == 1);
    var streamerWithNoTracking = await _streamerDbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 3);


    streamerWithTracking.Nombre = "Netflix Super";
    streamerWithNoTracking.Nombre = "Amazon Plus";
    await _streamerDbContext!.SaveChangesAsync();

}



async Task QueryLinq()
{
    Console.WriteLine($"Ingrese el servicio de streaming");
    var streamerNombre = Console.ReadLine();

    var streamers = await (from i in _streamerDbContext.Streamers
                           where EF.Functions.Like(i.Nombre, $"%{streamerNombre}%")
                           select i).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }


}


async Task QueryMethods()
{
    var streamer = _streamerDbContext!.Streamers!;

    var firstAsync = await streamer.Where(y => y.Nombre.Contains("a")).FirstAsync();

    var firstOrDefaultAsync = await streamer.Where(y => y.Nombre.Contains("a")).FirstOrDefaultAsync();

    var firstOrDefault_v2 = await streamer.FirstOrDefaultAsync(y => y.Nombre.Contains("a"));



    var singleAsync = await streamer.Where(y => y.Id == 1).SingleAsync();
    var singleOrDefaultAsync = await streamer.Where(y => y.Id == 1).SingleOrDefaultAsync();


    var resultado = await streamer.FindAsync(1);

    var count = await streamer.CountAsync();
    var longAccount = await streamer.LongCountAsync();
    var min = await streamer.MinAsync();
    var max = await streamer.MaxAsync();

}

async Task QueryFilter()
{
    Console.WriteLine($"Ingrese una compania de streaming:");
    var streamingNombre = Console.ReadLine();
    var streamers = await _streamerDbContext!.Streamers!.Where(x => x.Nombre.Equals(streamingNombre)).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} -  {streamer.Nombre}");
    }

    //var streamerPartialResults = await _streamerDbContext!.Streamers!.Where(x => x.Nombre.Contains(streamingNombre)).ToListAsync();
    var streamerPartialResults = await _streamerDbContext!.Streamers!.Where(x => EF.Functions.Like(x.Nombre, $"%{streamingNombre}%")).ToListAsync();
    foreach (var streamer in streamerPartialResults)
    {
        Console.WriteLine($"{streamer.Id} -  {streamer.Nombre}");
    }



}

void QueryStreaming()
{
    var streamers = _streamerDbContext!.Streamers!.ToList();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

}

async Task AddNewRecords()
{

    Streamer streamer = new()
    {
        Nombre = "disney",
        Url = "https://www.disney.com"
    };

    _streamerDbContext!.Streamers!.Add(streamer);

    await _streamerDbContext.SaveChangesAsync();


    var movies = new List<Video>
{
    new Video{
       Nombre = "La Cenicienta",
       StreamerId = streamer.Id
    },
    new Video{
       Nombre = "1001 dalmatas",
       StreamerId = streamer.Id
    },
    new Video{
       Nombre = "El Jorobado de Notredame",
       StreamerId = streamer.Id
    },
    new Video{
       Nombre = "Star Wars",
       StreamerId = streamer.Id
    },
};


    await _streamerDbContext.AddRangeAsync(movies);
    await _streamerDbContext.SaveChangesAsync();
}