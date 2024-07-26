using light_eyes.DTOs.Client;
using light_eyes.Models;

namespace light_eyes.Mappers;

public static class ClientMappers
{
    public static ClientDtoForReportDto ToClientDtoForReportDto(this Client client)
    {
        return new ClientDtoForReportDto
        {
            Id = client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            CompanyName = client.CompanyName,
            Area = client.Area,
            ContactEmail = client.ContactEmail,
            ContactPhone = client.ContactPhone,
        };
    }
    
}