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

    public static Client ToClientFromCreateDto(this CreateClientDto clientDto)
    {
        return new Client
        {
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName,
            CompanyName = clientDto.CompanyName,
            Area = clientDto.Area,
            ContactEmail = clientDto.ContactEmail,
            ContactPhone = clientDto.ContactPhone
        };
    }

    public static Client UpdateClientFromDto(this Client client, UpdateClientDto updateClientDto)
    {
        client.FirstName = updateClientDto.FirstName;
        client.LastName = updateClientDto.LastName;
        client.CompanyName = updateClientDto.CompanyName;
        client.Area = updateClientDto.Area;
        client.ContactEmail = updateClientDto.ContactEmail;
        client.ContactPhone = updateClientDto.ContactPhone;
        
        return client;
    }
    
}