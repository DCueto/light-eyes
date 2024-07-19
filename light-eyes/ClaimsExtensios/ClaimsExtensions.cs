// using System.Security.Claims;
//
// namespace light_eyes.ClaimsExtensios;
//
// public static class ClaimsExtensions
// {
//     public static string GetSections(this ClaimsPrincipal section)
//     {
//         var claim =section.Claims.SingleOrDefault(x =>
//             x.Type.Equals(ClaimTypes.Name) || x.Type.Equals(ClaimTypes.GivenName));
//
//         if (claim == null)
//             throw new InvalidOperationException("CLAIM FOR GIVEN NAME NOT FOUND");
//             
//             Console.WriteLine($"Claim got with user logged: Claim Type: {claim.Type}; Claim Value: {claim.Value}");
//
//             return claim.Value;
//         
//     }
// }