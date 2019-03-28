using HnC.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HnC.Repository.EntityFrameworkCore
{
    public class Service : IService
    {
        private readonly Context _context;

        public Service(Context dbContext)
        {
            _context = dbContext;
        }

        //public async Task<Outcome.Upsert> AddOrUpdateUsersRatingAsync(int UserId, int FilmId, int RatingTypeId)
        //{
        //    if (!_context.Films.Any(x => x.FilmId == FilmId))
        //        return Outcome.Upsert.EntityNotFound;

        //    if (!_context.Users.Any(x => x.UserId == UserId))
        //        return Outcome.Upsert.EntityNotFound;

        //    var upperBoundOfEnum = (int)Enum.GetValues(typeof(Rating.RatingType)).Cast<Rating.RatingType>().Max();
        //    var lowerBoundOfEnum = (int)Enum.GetValues(typeof(Rating.RatingType)).Cast<Rating.RatingType>().Min();

        //    if (RatingTypeId > upperBoundOfEnum || RatingTypeId < lowerBoundOfEnum)
        //        return Outcome.Upsert.ParameterOutOfBounds;

        //    Film film = _context.Films.FirstOrDefault(x => x.Ratings.Any(y => y.UserId == UserId
        //                && y.FilmId == FilmId));

        //    // Record exists, do update
        //    if (film != null)
        //    {
        //        film.Ratings.FirstOrDefault(x => x.UserId == UserId).TypeId = (Rating.RatingType)RatingTypeId;
        //        await _context.SaveChangesAsync();
        //        return Outcome.Upsert.Updated;
        //    }

        //    //No record, so insert a new one            
        //    film = _context.Films.FirstOrDefault(y => y.FilmId == FilmId);
        //    film.Ratings.Add(new Rating
        //    {
        //        FilmId = FilmId,
        //        TypeId = (Rating.RatingType)RatingTypeId,
        //        UserId = UserId
        //    });

        //    await _context.SaveChangesAsync();
        //    return Outcome.Upsert.Added;
        //}

        //public async Task<IEnumerable<FilmAndAverageRating>> GetFilmsAndAverageRatingsAsync(string title, DateTime yearOfRelease, List<int> genres)
        //{
        //    return await Task.FromResult(GetFilmsAndAverageRatings(title, yearOfRelease, genres));
        //}

        //private IEnumerable<FilmAndAverageRating> GetFilmsAndAverageRatings(string title, DateTime yearOfRelease, List<int> genres)
        //{
        //    //Query DB
        //    var matches = _context.Films.Where(
        //        x =>
        //            x.YearOfRelease.Year == yearOfRelease.Year
        //            ||
        //            (x.Genres == null) ? false : x.Genres.Any(y => (genres == null) ? false : genres.Contains((int)y.TypeId))
        //            ||
        //            x.Title.ToLowerInvariant().Contains(title.ToLowerInvariant())
        //        ).ToList();

        //    //Action to perform averaging
        //    decimal CalculateAverage(List<Rating> ratings)
        //    {
        //        if (ratings.Count == 0)
        //            return 0;

        //        decimal average = ratings.Sum(x => (int)x.TypeId) / ratings.Count;
        //        return Math.Round(average, 2, MidpointRounding.AwayFromZero);
        //    }

        //    //Formulate response
        //    var response = matches.Select(x => new FilmAndAverageRating
        //    {
        //        Id = x.FilmId,
        //        Title = x.Title,
        //        YearOfRelease = x.YearOfRelease.Year,
        //        RunningTime = x.RunningTime,
        //        AverageRating = CalculateAverage(x.Ratings)
        //    });

        //    return response;
        //}

        //public async Task<IEnumerable<FilmAndAverageTotalRating>> GetTop5FilmsByTotalUserRatingsAsync()
        //{
        //    return await Task.FromResult(GetTop5FilmsByTotalUserRatings());
        //}

        //private IEnumerable<FilmAndAverageTotalRating> GetTop5FilmsByTotalUserRatings()
        //{
        //    //Query DB
        //    var matches = _context.Films.ToList();

        //    //Action to perform averaging
        //    decimal CalculateAverage(List<Rating> ratings)
        //    {
        //        if (ratings.Count == 0)
        //            return 0;

        //        decimal average = ratings.Sum(x => (int)x.TypeId) / ratings.Count;
        //        average = (Math.Round(average * 2, MidpointRounding.AwayFromZero) / 2);
        //        return average;
        //    }

        //    //Action to perform summing
        //    decimal CalculateTotal(List<Rating> ratings)
        //    {
        //        if (ratings.Count == 0)
        //            return 0;

        //        decimal sum = ratings.Sum(x => (int)x.TypeId);
        //        return sum;
        //    }

        //    //Formulate response
        //    return matches.Select(x => new FilmAndAverageTotalRating
        //    {
        //        Id = x.FilmId,
        //        Title = x.Title,
        //        YearOfRelease = x.YearOfRelease.Year,
        //        RunningTime = x.RunningTime,
        //        AverageRating = CalculateAverage(x.Ratings),
        //        TotalRating = CalculateTotal(x.Ratings)
        //    })
        //    .OrderByDescending(y => y.TotalRating)
        //    .ThenBy(z => z.Title)
        //    .Take(5);
        //}

        //public async Task<IEnumerable<FilmAndAverageTotalRating>> GetTop5UsersFilmsByTotalUserRatingsAsync(int userId)
        //{
        //    return await Task.FromResult(GetTop5UsersFilmsByTotalUserRatings(userId));
        //}

        //private IEnumerable<FilmAndAverageTotalRating> GetTop5UsersFilmsByTotalUserRatings(int userId)
        //{
        //    //Query DB
        //    var matches = _context.Films.Where(x => x.Ratings.Any(y => y.UserId == userId)).ToList();

        //    //Action to perform averaging
        //    decimal CalculateAverage(List<Rating> ratings)
        //    {
        //        if (ratings.Count == 0)
        //            return 0;

        //        decimal average = ratings.Sum(x => (int)x.TypeId) / ratings.Count;
        //        average = (Math.Round(average * 2, MidpointRounding.AwayFromZero) / 2);
        //        return average;
        //    }

        //    //Action to perform summing
        //    decimal CalculateTotal(List<Rating> ratings)
        //    {
        //        if (ratings.Count == 0)
        //            return 0;

        //        decimal sum = ratings.Sum(x => (int)x.TypeId);
        //        return sum;
        //    }

        //    //Formulate response
        //    return matches.Select(x => new FilmAndAverageTotalRating
        //    {
        //        Id = x.FilmId,
        //        Title = x.Title,
        //        YearOfRelease = x.YearOfRelease.Year,
        //        RunningTime = x.RunningTime,
        //        AverageRating = CalculateAverage(x.Ratings),
        //        TotalRating = CalculateTotal(x.Ratings)
        //    })
        //    .OrderByDescending(y => y.TotalRating)
        //    .ThenBy(z => z.Title)
        //    .Take(5);
        //}
    }
}
