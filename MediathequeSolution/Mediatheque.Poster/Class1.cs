using RestSharp.Authenticators;
using RestSharp;
using System.Threading;

namespace Mediatheque.Poster

{
    public class PosterManager

    {
        public async Task<string> GetPosterAsync(string titre)
        {
         
            var client = new RestClient();
            var request = new RestRequest($"https://www.omdbapi.com/?s={titre}&apikey=JeBzKi?");
            // The cancellation token comes from the caller. You can still make a call without it.
            var taskResponse = client.GetAsync<OmdbResponse>(request);
            OmdbResponse response = taskResponse.Result;
            return response.Search[0].Poster;
        }
    }
    
}
