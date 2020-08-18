using System.Net.Http;
using System.Threading.Tasks;


namespace BookSearch
{
    public static class BookSearch
    {
        private static string bookApi = "https://www.googleapis.com/books/v1/volumes?q=";

        public static async Task<string> Search(string searchParameter, string fieldRestriction)
        {

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(bookApi + searchParameter + fieldRestriction);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();

        }
    }
}
